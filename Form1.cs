using MyStickyNotes.controls;
using MyStickyNotes.models;
using MyStickyNotes.services;
using System.Collections;

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

            Form frm = (Form)e.Node.Tag;
            frm.WindowState = frm.WindowState == FormWindowState.Maximized? FormWindowState.Normal: FormWindowState.Maximized;
            frm.Show();
        }

        private void refreshTree(bool showForms)
        {
            tvNotes.Nodes.Clear();

            TreeNode tn = new TreeNode();
            tn.Name = "active_notes";
            tn.Text = "Active";

            tvNotes.Nodes.Add(tn);
            for (int i = 0; i < formsManager.count(); i++)
            {
                FormEnhancedStickyNote frm = formsManager.get(i);

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

            tn.ExpandAll();
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
            int middle = formsManager.count() / 2;
            int heightCount = 0;
            int maxLeft = 0;
            for (int i = 0; i < middle; i++)
            {
                FormEnhancedStickyNote frm = formsManager.get(i);

                if (showForms)
                {
                    frm.Show();
                }

                frm.Top = heightCount;
                frm.Left = 0;


                heightCount += frm.Height;
                maxLeft = frm.Width > maxLeft ? frm.Width : maxLeft;
            }

            heightCount = 0;
            for (int i = middle; i < formsManager.count(); i++)
            {
                FormEnhancedStickyNote frm = formsManager.get(i);
                if (showForms)
                {
                    frm.Show();
                }

                frm.Top = heightCount;
                frm.Left = maxLeft;

                heightCount += frm.Height;
            }
        }
    }
}
