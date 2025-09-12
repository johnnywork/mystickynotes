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
            panel1 = new Panel();
            txtFilterNode = new TextBox();
            menuMain.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuMain
            // 
            menuMain.ImageScalingSize = new Size(20, 20);
            menuMain.Items.AddRange(new ToolStripItem[] { miNewNote, miArrange });
            menuMain.Location = new Point(0, 0);
            menuMain.Name = "menuMain";
            menuMain.Padding = new Padding(7, 3, 0, 3);
            menuMain.Size = new Size(1376, 30);
            menuMain.TabIndex = 0;
            menuMain.Text = "menuStrip1";
            // 
            // miNewNote
            // 
            miNewNote.Name = "miNewNote";
            miNewNote.Size = new Size(87, 24);
            miNewNote.Text = "New note";
            miNewNote.Click += miNewNote_Click;
            // 
            // miArrange
            // 
            miArrange.Name = "miArrange";
            miArrange.Size = new Size(76, 24);
            miArrange.Text = "Arrange";
            miArrange.Click += miArrange_Click;
            // 
            // tvNotes
            // 
            tvNotes.BorderStyle = BorderStyle.FixedSingle;
            tvNotes.Dock = DockStyle.Fill;
            tvNotes.Font = new Font("Courier New", 9F);
            tvNotes.Location = new Point(0, 27);
            tvNotes.Margin = new Padding(3, 4, 3, 4);
            tvNotes.Name = "tvNotes";
            tvNotes.Size = new Size(261, 996);
            tvNotes.TabIndex = 2;
            tvNotes.NodeMouseDoubleClick += tvNotes_NodeMouseDoubleClick;
            // 
            // panel1
            // 
            panel1.Controls.Add(tvNotes);
            panel1.Controls.Add(txtFilterNode);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(1115, 30);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(261, 1023);
            panel1.TabIndex = 4;
            // 
            // txtFilterNode
            // 
            txtFilterNode.BorderStyle = BorderStyle.FixedSingle;
            txtFilterNode.Dock = DockStyle.Top;
            txtFilterNode.Location = new Point(0, 0);
            txtFilterNode.Margin = new Padding(3, 4, 3, 4);
            txtFilterNode.Name = "txtFilterNode";
            txtFilterNode.Size = new Size(261, 27);
            txtFilterNode.TabIndex = 3;
            txtFilterNode.TextChanged += txtFilterNode_TextChanged;
            txtFilterNode.KeyDown += txtFilterNode_KeyDown;
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1376, 1053);
            Controls.Add(panel1);
            Controls.Add(menuMain);
            IsMdiContainer = true;
            MainMenuStrip = menuMain;
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmMain";
            Text = "My notes";
            WindowState = FormWindowState.Maximized;
            Load += frmMain_Load;
            KeyDown += frmMain_KeyDown;
            menuMain.ResumeLayout(false);
            menuMain.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuMain;
        private ToolStripMenuItem miNewNote;
        private ToolStripMenuItem miArrange;
        private TreeView tvNotes;
        private Panel panel1;
        private TextBox txtFilterNode;
    }
}
