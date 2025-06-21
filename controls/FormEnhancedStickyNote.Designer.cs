namespace MyStickyNotes.controls
{
    partial class FormEnhancedStickyNote
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlContent = new Panel();
            txtContent = new RichTextBox();
            pnlTop = new Panel();
            txtTitle = new TextBox();
            btnSave = new Button();
            pnlContent.SuspendLayout();
            pnlTop.SuspendLayout();
            SuspendLayout();
            // 
            // pnlContent
            // 
            pnlContent.Controls.Add(txtContent);
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 22);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(329, 248);
            pnlContent.TabIndex = 11;
            // 
            // txtContent
            // 
            txtContent.AcceptsTab = true;
            txtContent.BackColor = Color.FromArgb(255, 255, 192);
            txtContent.BorderStyle = BorderStyle.None;
            txtContent.Dock = DockStyle.Fill;
            txtContent.Font = new Font("Segoe UI", 10F);
            txtContent.Location = new Point(0, 0);
            txtContent.Name = "txtContent";
            txtContent.Size = new Size(329, 248);
            txtContent.TabIndex = 1;
            txtContent.Text = "";
            txtContent.WordWrap = false;
            txtContent.LinkClicked += txtContent_LinkClicked;
            txtContent.KeyDown += txtContent_KeyDown;
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(255, 128, 0);
            pnlTop.Controls.Add(txtTitle);
            pnlTop.Controls.Add(btnSave);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(329, 22);
            pnlTop.TabIndex = 10;
            // 
            // txtTitle
            // 
            txtTitle.BackColor = Color.LightGray;
            txtTitle.BorderStyle = BorderStyle.FixedSingle;
            txtTitle.Dock = DockStyle.Fill;
            txtTitle.Font = new Font("Verdana", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTitle.Location = new Point(0, 0);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(289, 22);
            txtTitle.TabIndex = 0;
            txtTitle.Text = "Note title";
            txtTitle.TextAlign = HorizontalAlignment.Center;
            txtTitle.WordWrap = false;
            // 
            // btnSave
            // 
            btnSave.Dock = DockStyle.Right;
            btnSave.Location = new Point(289, 0);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(40, 22);
            btnSave.TabIndex = 2;
            btnSave.Text = "save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // FormEnhancedStickyNote
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(329, 270);
            Controls.Add(pnlContent);
            Controls.Add(pnlTop);
            MaximizeBox = false;
            Name = "FormEnhancedStickyNote";
            Text = "Sticky message";
            Load += FormEnhancedStickyNote_Load;
            pnlContent.ResumeLayout(false);
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlContent;
        private Panel pnlTop;
        private TextBox txtTitle;
        private Button btnSave;
        private RichTextBox txtContent;
    }
}