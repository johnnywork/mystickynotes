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

        public StickyNoteContent? NoteContent { get; set; }
        private NotesManager? NotesManager { get; set; }

        private FormEnhancedStickyNote()
        {
            InitializeComponent();
            this.NoteContent = null;
            this.NotesManager = null;
        }

        public FormEnhancedStickyNote(StickyNoteContent cnt, NotesManager notesManager) : this()
        {
            this.NoteContent = cnt;
            this.NotesManager = notesManager;
        }

        protected virtual void OnNoteSaved(StickyNoteSavedEventArgs e)
        {
            StickyNoteSaved?.Invoke(this, e);
        }

        private void init()
        {
            this.txtContent.Rtf = this.NoteContent.FormattedText;
            this.txtTitle.Text = this.NoteContent.Title;
            this.txtTitle.SelectionStart = 0;
            this.txtTitle.SelectionLength = 0;
        }

        private void FormEnhancedStickyNote_Load(object sender, EventArgs e)
        {
            init();
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

            StickyNoteSavedEventArgs stickyNoteSavedEventArgs = new StickyNoteSavedEventArgs();
            stickyNoteSavedEventArgs.StickyNoteContent = this.NoteContent;
            OnNoteSaved(stickyNoteSavedEventArgs);
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
        }
    }
}
