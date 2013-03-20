using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace endnote.Handler
{
    public class NotebookObject
    {
        public int NoteCount { get; set; }
        public string data { get; set; }
        public Dictionary<string, string> attr { get; set; }
        public string icon { get; set; }
    }
}