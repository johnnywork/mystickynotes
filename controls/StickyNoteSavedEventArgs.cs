using MyStickyNotes.models;

namespace MyStickyNotes.controls
{
    public class StickyNoteSavedEventArgs : EventArgs
    {
        public StickyNoteContent? StickyNoteContent { get; set; }
    }
}