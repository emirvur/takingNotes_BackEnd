using System;
using System.Collections.Generic;

namespace teaAPI.Models
{
    public partial class Note
    {
        public int NoteId { get; set; }
        public string NoteTitle { get; set; }
        public string NoteDescription { get; set; }
        public DateTime NoteDate { get; set; }
    }
}
