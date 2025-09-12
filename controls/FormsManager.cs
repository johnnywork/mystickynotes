using MyStickyNotes.models;
using MyStickyNotes.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStickyNotes.controls
{
    internal class FormsManager
    {
        private NotesManager notesManager;
        private frmMain mdiParent;
        private List<FormEnhancedStickyNote> noteForms;

        public FormsManager(frmMain mdiParent, NotesManager notesManager)
        {
            this.mdiParent = mdiParent;
            this.noteForms = new List<FormEnhancedStickyNote>(50);
            this.notesManager = notesManager;
        }

        public void suspendLayout()
        {
            foreach (FormEnhancedStickyNote frm in noteForms)
            {
                frm.SuspendLayout();
            }
        }
        public void resumeLayout()
        {
            foreach (FormEnhancedStickyNote frm in noteForms)
            {
                frm.ResumeLayout(false);
            }
        }

        public FormEnhancedStickyNote createNoteForm(StickyNoteContent noteContent)
        {
            FormEnhancedStickyNote frmNote = new FormEnhancedStickyNote(noteContent, notesManager);
            frmNote.StickyNoteSaved += this.mdiParent.FrmNote_StickyNoteSaved;
            frmNote.MdiParent = this.mdiParent;

            noteForms.Add(frmNote);

            return frmNote;
        }

        public void createNoteForms(List<StickyNoteContent> notes)
        {
            foreach (StickyNoteContent note in notes) 
            { 
                createNoteForm(note);
            }
        }

        public int count()
        {
            return noteForms.Count;
        }
        public FormEnhancedStickyNote get(int index)
        {
            return noteForms[index];
        }
    }
}
