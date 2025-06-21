namespace MyStickyNotes
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuMain = new MenuStrip();
            miNewNote = new ToolStripMenuItem();
            miArrange = new ToolStripMenuItem();
            tvNotes = new TreeView();
            menuMain.SuspendLayout();
            SuspendLayout();
            // 
            // menuMain
            // 
            menuMain.Items.AddRange(new ToolStripItem[] { miNewNote, miArrange });
            menuMain.Location = new Point(0, 0);
            menuMain.Name = "menuMain";
            menuMain.Size = new Size(1204, 24);
            menuMain.TabIndex = 0;
            menuMain.Text = "menuStrip1";
            // 
            // miNewNote
            // 
            miNewNote.Name = "miNewNote";
            miNewNote.Size = new Size(70, 20);
            miNewNote.Text = "New note";
            miNewNote.Click += miNewNote_Click;
            // 
            // miArrange
            // 
            miArrange.Name = "miArrange";
            miArrange.Size = new Size(61, 20);
            miArrange.Text = "Arrange";
            miArrange.Click += miArrange_Click;
            // 
            // tvNotes
            // 
            tvNotes.BorderStyle = BorderStyle.FixedSingle;
            tvNotes.Dock = DockStyle.Right;
            tvNotes.Font = new Font("Courier New", 9F);
            tvNotes.Location = new Point(1017, 24);
            tvNotes.Name = "tvNotes";
            tvNotes.Size = new Size(187, 766);
            tvNotes.TabIndex = 2;
            tvNotes.NodeMouseDoubleClick += tvNotes_NodeMouseDoubleClick;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1204, 790);
            Controls.Add(tvNotes);
            Controls.Add(menuMain);
            IsMdiContainer = true;
            MainMenuStrip = menuMain;
            Name = "frmMain";
            Text = "My notes";
            WindowState = FormWindowState.Maximized;
            Load += frmMain_Load;
            menuMain.ResumeLayout(false);
            menuMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuMain;
        private ToolStripMenuItem miNewNote;
        private ToolStripMenuItem miArrange;
        private TreeView tvNotes;
    }
}
