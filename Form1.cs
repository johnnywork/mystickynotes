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

            formsManager = new FormsManager();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            MdiScroller.Install(this);

            if (RootFolder == null)
            {
                RootFolder = Application.StartupPath;
            }

            notesManager = new NotesManager(RootFolder);
        }

        private void refreshTree()
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
            }

            tn.ExpandAll();
        }

        private void miNewNote_Click(object sender, EventArgs e)
        {
            StickyNoteContent noteContent = new StickyNoteContent();

            FormEnhancedStickyNote frmNote = new FormEnhancedStickyNote(noteContent, notesManager);
            frmNote.StickyNoteSaved += FrmNote_StickyNoteSaved;
            formsManager.add(frmNote);

            frmNote.MdiParent = this;
            frmNote.Show();

            refreshTree();
        }

        private void FrmNote_StickyNoteSaved(object? sender, EventArgs e)
        {
            refreshTree();
        }

        private void miArrange_Click(object sender, EventArgs e)
        {
            int middle = formsManager.count() / 2;
            int heightCount = 0;
            int maxLeft = 0;
            for (int i = 0; i < middle; i++)
            {
                FormEnhancedStickyNote frm = formsManager.get(i);
                frm.Top = heightCount;
                frm.Left = 0;

                heightCount += frm.Height;
                maxLeft = frm.Width > maxLeft ? frm.Width : maxLeft;
            }

            heightCount = 0;
            for (int i = middle; i < formsManager.count(); i++)
            {
                FormEnhancedStickyNote frm = formsManager.get(i);
                frm.Top = heightCount;
                frm.Left = maxLeft;

                heightCount += frm.Height;
            }

            refreshTree();
        }

        private void tvNotes_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == null) return;
            if (e.Node.Tag == null) return;

            Form frm = (Form)e.Node.Tag;
            frm.WindowState = frm.WindowState == FormWindowState.Maximized? FormWindowState.Normal: FormWindowState.Maximized;
            frm.Show();
        }
    }
}
