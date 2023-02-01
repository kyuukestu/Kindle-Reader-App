using System;
using System.Collections.Generic;

namespace mobile_library.Models
{
    public class Library
    {
        public string Username { get; set; }
        public int LibraryID { get; set; }
        public List<LibraryItem> LibraryItems { get; set; }
    }
}
