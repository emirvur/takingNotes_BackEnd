using System;
using System.Collections.Generic;

namespace teaAPI.Models
{
    public partial class Todo
    {
        public int TodoId { get; set; }
        public string TodoTitle { get; set; }
        public string TodoDescription { get; set; }
        public DateTime TodoDate { get; set; }
        public int IsCompleted { get; set; }
    }
}
