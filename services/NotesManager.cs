using MyStickyNotes.models;
using MyStickyNotes.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStickyNotes.services
{
    public class NotesManager
    {
        private string rootFolder;
        private XMLUtils xmlUtils;

        public NotesManager(string rootFolder) 
        {
            xmlUtils = new XMLUtils();
            this.rootFolder = rootFolder;
        }        

        public void saveNote(StickyNoteContent note)
        {
            string xml = xmlUtils.serialize(note);
            string fileName = Path.Combine(this.rootFolder, note.ID)+".xml";
            File.WriteAllText(fileName, xml);
        }
    }
}
