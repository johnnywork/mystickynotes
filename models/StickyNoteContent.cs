using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStickyNotes.models
{
    public class StickyNoteContent
    {
        public StickyNoteContent() 
        { 
            CreatedAt = DateTime.Now;
            ID = CreatedAt.GetHashCode().ToString() + "_"+ CreatedAt.ToString("yyyy_mm_dd");
        }

        public string ID { get;  }
        public string? PlainText { get; set; }
        public string? FormattedText { get; set; }

        public string? Title { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? LastUpdatedAt { get; set; }
    }
}
