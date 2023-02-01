using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using mobile_library.Models;
using Xamarin.Forms;

namespace mobile_library.Helpers
{
    public class AddBookData
    {
        FirebaseClient client;

       public List<Book> Books { get; set; }

        public AddBookData()
        {
            client = new FirebaseClient("https://mobilelibraryapp-default-rtdb.firebaseio.com/");
            Books = new List<Book>()
            {
                new Book
                {
                    BookID = "1",
                    GenreID = "Act",
                    CoverImageUrl = "Noir.jpg",
                    BookName = "Cobel",
                    BookDescription = "Private Investigator grapples with ghosts from his past.",
                    BookRating = "4.5",
                    BookDetail = "Detective Details",
                    BookAuthor = "userone",
                },

                new Book
                {
                    BookID = "2",
                    GenreID = "Adv",
                    CoverImageUrl = "https://www.kindpng.com/picc/m/64-645772_summer-adventure-png-transparent-png.png",
                    BookName = "Adventuer Time",
                    BookDescription = "Camping.",
                    BookRating = "5.5",
                    BookDetail = "Fiasco",
                    BookAuthor = "userone",
                },

                new Book
                {
                    BookID = "3",
                    GenreID = "Rom",
                    CoverImageUrl = "https://www.pngitem.com/pimgs/m/45-455185_romantic-png-transparent-png.png",
                    BookName = "Romeo & Juliet",
                    BookDescription = "Star-Crossed Lovers",
                    BookRating = "10.0",
                    BookDetail = "Shakespearean",
                    BookAuthor = "userone",
                },

                new Book
                {
                    BookID = "4",
                    GenreID = "His",
                    CoverImageUrl = "https://www.pngmart.com/files/7/War-PNG-Photo.png",
                    BookName = "All Quiet on the Western Front",
                    BookDescription = "Historical Fiction, World War I",
                    BookRating = "9.5",
                    BookDetail = "Tear jerker",
                    BookAuthor = "userone",
                },

                new Book
                {
                    BookID = "5",
                    GenreID = "Com",
                    CoverImageUrl = "https://p1.hiclipart.com/preview/822/467/682/kaguya-sama-wa-kokurasetai-icon-kaguya-sama-wa-kokurasetai-png-icon.jpg",
                    BookName = "Kaguya-sama",
                    BookDescription = "Romantic Comedy",
                    BookRating = "10.0",
                    BookDetail = "Season 3 Release",
                    BookAuthor = "userone",
                },

                new Book
                {
                    BookID = "6",
                    GenreID = "Sci-Fi",
                    CoverImageUrl = "https://purepng.com/public/uploads/large/purepng.com-terminatorterminatorscience-fictionactionfilmjames-cameronthe-terminatorarnold-schwarzeneggercyborgsarah-connor-1701528658823qeqjn.png",
                    BookName = "Terminator",
                    BookDescription = "Murder cop from the future.",
                    BookRating = "7.5",
                    BookDetail = "Pending",
                    BookAuthor = "userone",
                },

                new Book
                {
                    BookID = "7",
                    GenreID = "Adv",
                    CoverImageUrl = "https://pngimg.com/uploads/mario/mario_PNG125.png",
                    BookName = "Super Mario Brothers",
                    BookDescription = "Nintendo Classic.",
                    BookRating = "8.5",
                    BookDetail = "Pending",
                    BookAuthor = "userone",
                },

                new Book
                {
                    BookID = "8",
                    GenreID = "Adv",
                    CoverImageUrl = "https://www.pngmart.com/files/13/Moana-PNG-Transparent-Image.png",
                    BookName = "Moana",
                    BookDescription = "Disney Movie.",
                    BookRating = "6.5",
                    BookDetail = "Pending",
                    BookAuthor = "userone",
                },

                new Book
                {
                    BookID = "9",
                    GenreID = "Adv",
                    CoverImageUrl = "https://esquilo.io/png/thumb/undKnHy1f7WLErH-Spice-And-Wolf-PNG-Photo.png",
                    BookName = "Spice & Wolf",
                    BookDescription = "Adventure and Economics!",
                    BookRating = "8.5",
                    BookDetail = "Pending",
                    BookAuthor = "userone",
                },

                new Book
                {
                    BookID = "10",
                    GenreID = "Fan",
                    CoverImageUrl = "https://images-wixmp-ed30a86b8c4ca887773594c2.wixmp.com/i/f77a4946-8ae3-447e-884b-97fd0e1ddb57/ddinere-ea102d06-0dad-4f19-84f9-10cf399f902e.png",
                    BookName = "Mushoku Tensei",
                    BookDescription = "Reincarnated into another world!",
                    BookRating = "10.0",
                    BookDetail = "Pending",
                    BookAuthor = "userone",
                },

                new Book
                {
                    BookID = "11",
                    GenreID = "Sci-Fi",
                    CoverImageUrl = "https://e1.pngegg.com/pngimages/62/642/png-clipart-transformers-s-optimus-prime-transformer-thumbnail.png",
                    BookName = "Transformers",
                    BookDescription = "Dark of the Moon.",
                    BookRating = "7.5",
                    BookDetail = "Optimus Prime",
                    BookAuthor = "userone",
                },

                new Book
                {
                    BookID = "12",
                    GenreID = "Fan",
                    CoverImageUrl = "https://w7.pngwing.com/pngs/97/348/png-transparent-dragon-of-the-lost-sea-brisingr-eragon-inheritance-cycle-dragon-dragon-author-head-thumbnail.png",
                    BookName = "Eragon",
                    BookDescription = "Dragons, Swords and Magic.",
                    BookRating = "6.5",
                    BookDetail = "High Fantasy",
                    BookAuthor = "userone",
                },

                new Book
                {
                    BookID = "13",
                    GenreID = "Fan",
                    CoverImageUrl = "https://media.discordapp.net/attachments/191374162978144257/966123012581634178/Esther.png?width=762&height=1016",
                    BookName = "Pokemon - Esther",
                    BookDescription = "Young girl's coming of age story in the world or Pokemon",
                    BookRating = "7.5",
                    BookDetail = "Alternate Universe",
                    BookAuthor = "kyuukestu",
                },
            };
        }

        public async Task AddBookDataAsync()
        {
            try
            {
                foreach (var Book in Books)
                {

                    await client.Child("Books").PostAsync(new Book()
                    {
                        BookID = Book.BookID,
                        CoverImageUrl = Book.CoverImageUrl,
                        BookName = Book.BookName,
                        BookDescription = Book.BookDescription,
                        BookRating = Book.BookRating,
                        BookDetail = Book.BookDetail,
                        GenreID = Book.GenreID,
                        BookAuthor = Book.BookAuthor,
                    });
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
        
    }
}
