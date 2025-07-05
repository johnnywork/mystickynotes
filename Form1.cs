using MyStickyNotes.controls;
using MyStickyNotes.models;
using MyStickyNotes.services;
using System.Collections;
using System.Windows.Forms;

namespace MyStickyNotes
{
    public partial class frmMain : Form
    {
        private FormsManager formsManager;
        private NotesManager notesManager;
        public string RootFolder { get; set; }

        private static Font FONT_REGULAR_TREE = new Font("Courier New", 9, FontStyle.Regular);
        private static Font FONT_REGULAR_TREEROOT = new Font("Courier New", 10, FontStyle.Bold);
        private static Font FONT_FILTERED_NODE = new Font("Courier New", 9, FontStyle.Bold);

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            MdiScroller.Install(this);

            if (RootFolder == null)
            {
                RootFolder = Application.StartupPath;
            }

            notesManager = new NotesManager(RootFolder);
            formsManager = new FormsManager(this, notesManager);

            formsManager.createNoteForms(notesManager.loadNotes());
            refreshTree(false);

            arrange(true);

            txtFilterNode.Focus();
        }

        private void miNewNote_Click(object sender, EventArgs e)
        {
            createNewNote();
            refreshTree(false);
        }

        private void FrmNote_StickyNoteSaved(object? sender, EventArgs e)
        {
            refreshTree(false);
        }

        private void miArrange_Click(object sender, EventArgs e)
        {
            arrange(false);
        }

        private void tvNotes_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == null) return;
            if (e.Node.Tag == null) return;

            maximizeForm((FormEnhancedStickyNote)e.Node.Tag);
        }

        private void txtFilterNode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string criteria = txtFilterNode.Text.Trim();
                TreeNode rootNode = tvNotes.Nodes[0];
                txtFilterNode.Tag = null;

                foreach (TreeNode node in rootNode.Nodes)
                {
                    if (criteria.Length > 0)
                    {
                        if (node.Text.IndexOf(criteria, StringComparison.CurrentCultureIgnoreCase) > -1)
                        {
                            node.ForeColor = Color.Red;
                            node.NodeFont = FONT_FILTERED_NODE;
                            txtFilterNode.Tag = node.Tag;
                        }
                        else
                        {
                            node.ForeColor = tvNotes.ForeColor;
                            node.NodeFont = FONT_REGULAR_TREE;
                        }
                    }
                    else
                    {
                        node.ForeColor = tvNotes.ForeColor;
                        node.NodeFont = FONT_REGULAR_TREE;
                    }
                }
            }
            catch (Exception ex) { }
        }

        private void txtFilterNode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtFilterNode.Tag != null)
                {
                    maximizeForm((FormEnhancedStickyNote) txtFilterNode.Tag);
                }
            }
            else if(e.KeyCode == Keys.Escape)
            {
                txtFilterNode.Text = "";
            }
        }

        //--------------------------------------------------------------------------------
        // LOCAL METHODS
        //--------------------------------------------------------------------------------

        private void maximizeForm(FormEnhancedStickyNote frm)
        {
            frm.WindowState = frm.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
            frm.Show();
            frm.focusForEdit();
        }

        private void refreshTree(bool showForms)
        {
            tvNotes.BackColor = Color.LightYellow;
            tvNotes.Nodes.Clear();

            SortedList<string, FormEnhancedStickyNote> sortedByname = new SortedList<string, FormEnhancedStickyNote>();

            tvNotes.BeginUpdate();

            TreeNode tn = new TreeNode();
            tn.Name = "active_notes";
            tn.Text = "Active";
            tn.NodeFont = FONT_REGULAR_TREEROOT;

            //add active
            for (int i = 0; i < formsManager.count(); i++)
            {
                FormEnhancedStickyNote frm = formsManager.get(i);
                if (frm.NoteContent.Title == null)
                {
                    continue;
                }
                sortedByname.Add(frm.NoteContent.Title, frm);

                TreeNode nn = new TreeNode();
                nn.Name = "active_node_" + frm.GetHashCode();
                nn.Text = frm.NoteContent.Title;
                nn.Tag = frm;
                nn.NodeFont = FONT_REGULAR_TREE;
                tn.Nodes.Add(nn);

                if (showForms)
                {
                    frm.Show();
                }
            }

            //add by title
            TreeNode tnByName = new TreeNode();
            tnByName.Name = "active_notes_by_name";
            tnByName.Text = "Active by name";
            tnByName.NodeFont = FONT_REGULAR_TREEROOT;

            for (int i = 0; i < sortedByname.Count; i++)
            {
                FormEnhancedStickyNote frm = sortedByname.GetValueAtIndex(i);

                TreeNode nn = new TreeNode();
                nn.Name = "active_node_by_name_" + frm.GetHashCode();
                nn.Text = frm.NoteContent.Title;
                nn.Tag = frm;
                nn.NodeFont = FONT_REGULAR_TREE;
                tnByName.Nodes.Add(nn);
            }

            tvNotes.Nodes.Add(tnByName);
            tvNotes.Nodes.Add(tn);

            tvNotes.ExpandAll();
            tvNotes.EndUpdate();
        }

        private void createNewNote()
        {
            StickyNoteContent noteContent = new StickyNoteContent();
            FormEnhancedStickyNote frmNote = formsManager.createNoteForm(noteContent);
            frmNote.StickyNoteSaved += FrmNote_StickyNoteSaved;
            frmNote.Show();
        }

        private void arrange(bool showForms)
        {
            int numOfColumns = 3;

            int middle = formsManager.count() / numOfColumns;
            int heightCount = 0;
            int columnLeft = 0;
            int columnMaxLeft = 0;
            for (int iColumn = 0; iColumn <= numOfColumns; iColumn++)
            {
                heightCount = 0;
                columnLeft += columnMaxLeft;
                columnMaxLeft = 0;
                for (int i = 0; i < middle; i++)
                {
                    int formToGet = i + (iColumn * middle);
                    if (formToGet >= formsManager.count())
                    {
                        break;
                    }
                    FormEnhancedStickyNote frm = formsManager.get(formToGet);
                    if (showForms)
                    {
                        frm.Show();
                    }

                    frm.Top = heightCount;
                    frm.Left = columnLeft;

                    heightCount += frm.Height;
                    columnMaxLeft = frm.Width > columnMaxLeft ? frm.Width : columnMaxLeft;
                }
            }
        }
    }
}
