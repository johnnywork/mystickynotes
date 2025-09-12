using MyStickyNotes.models;
using MyStickyNotes.services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyStickyNotes.controls
{
    public partial class FormEnhancedStickyNote : Form
    {
        private static string TITLE = "Note";
        private static string DATETIME_FORMAT = "yyyy-MM-dd HH:mm:ss";

        public event EventHandler? StickyNoteSaved;
        public delegate void StickyNoteSavedEventHandler(object sender, StickyNoteSavedEventArgs e);

        private bool OnInitMode = false;
        private bool PendingSave = false;
        public StickyNoteContent? NoteContent { get; set; }
        private NotesManager? NotesManager { get; set; }

        private FormEnhancedStickyNote()
        {
            OnInitMode = true;
            InitializeComponent();
            this.NoteContent = null;
            this.NotesManager = null;
        }

        public FormEnhancedStickyNote(StickyNoteContent cnt, NotesManager notesManager) : this()
        {
            this.NoteContent = cnt;
            this.NotesManager = notesManager;
        }

        //--------------------------------------------------------------------------------
        // CONTROL METHODS
        //--------------------------------------------------------------------------------

        private void FormEnhancedStickyNote_Load(object sender, EventArgs e)
        {
            init();
            OnInitMode = false;
            adjustArchivalText();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            save();
        }

        private void txtContent_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process p = new();
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.FileName = "chrome.exe";
            p.StartInfo.Arguments = e.LinkText;
            p.Start();
        }

        private void txtContent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S && e.Control)
            {
                save();
            }
            else if (e.KeyCode == Keys.B && e.Control)
            {
                handleBold();
            }
            else if (e.KeyCode == Keys.U && e.Control)
            {
                handleUnderline();
            }
            if (e.KeyCode == Keys.G && e.Control)
            {
                handleGreenText();
            }
            if (e.KeyCode == Keys.R && e.Control)
            {
                handleRedText();
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.WindowState = this.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
            }
        }

        private void btnManageArchival_Click(object sender, EventArgs e)
        {
            try
            {
                if (NoteContent.IsArchived)
                {
                    NoteContent.IsArchived = false;
                }
                else
                {
                    NoteContent.IsArchived = true;
                }

                save();
                adjustArchivalText();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //--------------------------------------------------------------------------------
        // EVENT METHODS
        //--------------------------------------------------------------------------------

        protected virtual void OnNoteSaved(StickyNoteSavedEventArgs e)
        {
            StickyNoteSaved?.Invoke(this, e);
        }

        //--------------------------------------------------------------------------------
        // LOCAL METHODS
        //--------------------------------------------------------------------------------

        private void init()
        {
            this.txtContent.Rtf = this.NoteContent.FormattedText;
            this.txtTitle.Text = this.NoteContent.Title;
            this.txtTitle.SelectionStart = 0;
            this.txtTitle.SelectionLength = 0;
        }

        public void focusForEdit()
        {
            this.txtContent.Focus();
        }

        private void save()
        {
            this.NoteContent.Title = txtTitle.Text;
            this.NoteContent.PlainText = txtContent.Text;
            this.NoteContent.FormattedText = txtContent.Rtf;

            this.txtTitle.BackColor = Color.Orange;
            this.NotesManager.saveNote(this.NoteContent);
            this.txtTitle.BackColor = Color.LightGray;
            this.Text = TITLE + " - [" + DateTime.Now.ToString(DATETIME_FORMAT) + "]";

            txtTitle.BackColor = Color.FromArgb(223, 235, 209);

            StickyNoteSavedEventArgs stickyNoteSavedEventArgs = new StickyNoteSavedEventArgs();
            stickyNoteSavedEventArgs.StickyNoteContent = this.NoteContent;

            OnNoteSaved(stickyNoteSavedEventArgs);
        }

        private void adjustArchivalText()
        {
            btnManageArchival.Text = NoteContent.IsArchived ? "Restore" : "Archive";
        }

        private void handleBold()
        {
            Font existing = this.txtContent.SelectionFont;
            Font toApply = null;

            if (existing.Style == FontStyle.Regular)
            {
                toApply = new Font(existing, FontStyle.Bold);
            }
            else
            {
                toApply = new Font(existing, FontStyle.Regular);
            }

            this.txtContent.SelectionFont = toApply;
        }

        private void handleUnderline()
        {
            Font existing = this.txtContent.SelectionFont;
            Font toApply = null;

            if (existing.Style == FontStyle.Regular)
            {
                toApply = new Font(existing, FontStyle.Underline);
            }
            else
            {
                toApply = new Font(existing, FontStyle.Regular);
            }

            this.txtContent.SelectionFont = toApply;
        }
        
        private void handleGreenText()
        {
            if (this.txtContent.SelectionColor != Color.Green)
            {
                this.txtContent.SelectionColor = Color.Green;
            }
            else
            {
                this.txtContent.SelectionColor = Color.Black;
            }
        }

        private void putInEditMode()
        {
            if (!this.OnInitMode)
            {
                PendingSave = true;
                txtTitle.BackColor = Color.FromArgb(255,224,201);
            }    
        }

        private void txtContent_TextChanged(object sender, EventArgs e)
        {
            putInEditMode();
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            putInEditMode();
        }
        private void handleRedText()
        {
            if (this.txtContent.SelectionColor != Color.Red)
            {
                this.txtContent.SelectionColor = Color.Red;
            }
            else
            {
                this.txtContent.SelectionColor = Color.Black;
            }
        }
    }
}
