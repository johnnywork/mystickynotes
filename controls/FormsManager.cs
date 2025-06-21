using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStickyNotes.controls
{
    internal class FormsManager
    {
        private List<FormEnhancedStickyNote> noteForms { get; set; }

        public FormsManager()
        {
            noteForms = new List<FormEnhancedStickyNote>(50);
        }

        public void add(FormEnhancedStickyNote frmNote)
        {
            noteForms.Add(frmNote);
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
