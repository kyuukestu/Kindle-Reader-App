using System;
using SQLite;

namespace mobile_library.Models
{
    [Table("LibraryItem")]
    public class LibraryItem
    {
        [PrimaryKey, AutoIncrement]
        public int LibraryBookID { get; set; }
        public string BookID { get; set; }
        public string BookAuthor { get; set; }
        public string CoverImageUrl { get; set; }
        public string BookName { get; set; }
        public string BookDescription { get; set; }
        public string BookRating { get; set; }
        public string BookDetail { get; set; }
        public string GenreID { get; set; }
    }
}
