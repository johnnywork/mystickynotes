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

            FormEnhancedStickyNote frm = (FormEnhancedStickyNote)e.Node.Tag;
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
            tn.NodeFont = new Font(tvNotes.Font.FontFamily, 11, FontStyle.Bold);

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
            tnByName.NodeFont = new Font(tvNotes.Font.FontFamily, 11, FontStyle.Bold);

            for (int i = 0; i < sortedByname.Count; i++)
            {
                FormEnhancedStickyNote frm = sortedByname.GetValueAtIndex(i);

                TreeNode nn = new TreeNode();
                nn.Name = "active_node_by_name_" + frm.GetHashCode();
                nn.Text = frm.NoteContent.Title;
                nn.Tag = frm;
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

            //for (int i = 0; i < middle; i++)
            //{
            //    FormEnhancedStickyNote frm = formsManager.get(i);

            //    if (showForms)
            //    {
            //        frm.Show();
            //    }

            //    frm.Top = heightCount;
            //    frm.Left = 0;


            //    heightCount += frm.Height;
            //    maxLeft = frm.Width > maxLeft ? frm.Width : maxLeft;
            //}

            //heightCount = 0;
            //for (int i = middle; i < formsManager.count(); i++)
            //{
            //    FormEnhancedStickyNote frm = formsManager.get(i);
            //    if (showForms)
            //    {
            //        frm.Show();
            //    }

            //    frm.Top = heightCount;
            //    frm.Left = maxLeft;

            //    heightCount += frm.Height;
            //}
        }

        private void txtFilterNode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string criteria = txtFilterNode.Text.Trim();
                TreeNode rootNode = tvNotes.Nodes[0];

                foreach (TreeNode node in rootNode.Nodes)
                {
                    if (criteria.Length > 0)
                    {
                        if (node.Text.IndexOf(criteria, StringComparison.CurrentCultureIgnoreCase) > -1)
                        {
                            node.ForeColor = Color.Red;
                            node.NodeFont = new Font(tvNotes.Font, FontStyle.Bold);
                        }
                        else
                        {
                            node.ForeColor = tvNotes.ForeColor;
                            node.NodeFont = new Font(tvNotes.Font, FontStyle.Regular);
                        }
                    }
                    else
                    {
                        node.ForeColor = tvNotes.ForeColor;
                        node.NodeFont = new Font(tvNotes.Font, FontStyle.Regular);
                    }
                }
            }
            catch (Exception ex){}
        }
    }
}
