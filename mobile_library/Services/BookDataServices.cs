using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using mobile_library.Models;

namespace mobile_library.Services
{
    public class BookDataServices
    {
        FirebaseClient client;
        

        public BookDataServices()
        {
            client = new FirebaseClient("https://mobilelibraryapp-default-rtdb.firebaseio.com/");

        }

        public async Task<List<Book>> GetBookAsync()
        {
            var books = (await client.Child("Books")
                .OnceAsync<Book>())
                .Select(b => new Book
                {
                    GenreID = b.Object.GenreID,
                    BookID = b.Object.BookID,
                    //BookID = b.Object.BookID = b.Key, //Firebase Key
                    BookAuthor = b.Object.BookAuthor,
                    BookName = b.Object.BookName,
                    BookDescription = b.Object.BookDescription,
                    BookDetail = b.Object.BookDetail,
                    BookRating = b.Object.BookRating,
                    CoverImageUrl = b.Object.CoverImageUrl
                }).ToList();
            return books;
        }

        public async Task<ObservableCollection<Book>> GetBooksbyAuthorAsync(string BookAuthor)
        {
            var BooksbyAuthor = new ObservableCollection<Book>();
            var books = (await GetBookAsync())
                .Where(b => b.BookAuthor == BookAuthor)
                .ToList();
            foreach (Book book in books)
            {
                BooksbyAuthor.Add(book);
            }
            return BooksbyAuthor;
        }

        public async Task<ObservableCollection<Book>> GetBooksbyTitleAsync(string BookName)
        {
            var BooksbyTitle = new ObservableCollection<Book>();
            var books = (await GetBookAsync())
                .Where(b => b.BookName == BookName)
                .ToList();
            foreach(Book book in books)
            {
                BooksbyTitle.Add(book);
            }
            return BooksbyTitle;
        }

        public async Task<ObservableCollection<Book>> GetBooksByGenreAsync(string GenreID)
        {
            var BooksbyGenre = new ObservableCollection<Book>();
            var books = (await GetBookAsync())
                .Where(p => p.GenreID == GenreID)
                .ToList();
            foreach (Book book in books)
            {
                BooksbyGenre.Add(book);
            }
            return BooksbyGenre;
        }

        public async Task<ObservableCollection<Book>> GetBookbyID(string BookID)
        {
            var BookbyID = new ObservableCollection<Book>();
            var books = (await GetBookAsync())
                .Where(p => p.BookID == BookID)
                .ToList();
            foreach (Book book in books)
            {
                BookbyID.Add(book);
            }
            return BookbyID;
        }

        public async Task<ObservableCollection<Book>> GetLatestBook()
        {
            var LatestBook = new ObservableCollection<Book>();
            var Books = (await GetBookAsync()).OrderByDescending(b => b.BookID).Take(1);
            foreach (var book in Books)
            {
                LatestBook.Add(book);
            }
            return LatestBook;
        }

        public async Task<ObservableCollection<Book>> GetLatestBooks()
        {
            var LatestBooks = new ObservableCollection<Book>();
            var Books = (await GetBookAsync()).OrderByDescending(b => b.BookID).Take(3);
            foreach (var book in Books)
            {
                LatestBooks.Add(book);
            }
            return LatestBooks;
        }

    }
}
