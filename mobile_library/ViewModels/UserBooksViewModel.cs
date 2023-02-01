using System;
using System.Collections.ObjectModel;
using mobile_library.Models;
using mobile_library.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace mobile_library.ViewModels
{
    public class UserBooksViewModel : BaseViewModel
    {
        private Book _SelectedBook;
        public Book SelectedBook
        {
            set
            {
                _SelectedBook = value;
                OnPropertyChanged();
            }

            get
            {
                return _SelectedBook;
            }
        }

        private string _BookAuthor;
        public string BookAuthor
        {
            set
            {
                _BookAuthor = value;
                OnPropertyChanged();
            }

            get
            {
                return _BookAuthor;
            }
        }

        private string _Username;
        public string Username
        {
            set
            {
                this._Username = value;
                OnPropertyChanged();
            }
            get
            {
                return this._Username;
            }

        }

        public ObservableCollection<Book> BooksbyAuthor { get; set; }

        public UserBooksViewModel()
        { }

        public UserBooksViewModel(Book book)
        {
            SelectedBook = book;
            BooksbyAuthor = new ObservableCollection<Book>();
            //GetUserBooks(book.BookAuthor);

            var username = Preferences.Get("Username", String.Empty);
            if (String.IsNullOrEmpty(username))
            {
                Username = "Guest";
            }
            else
            {
                Username = username;
            }

        }

        //private async void GetUserBooks(string BookAuthor)
        //{

        //    var data = await new BookDataServices().GetBooksByAuthorAsync(BookAuthor);
        //    BooksbyAuthor.Clear();
        //    foreach (var item in data)
        //    {
        //        BooksbyAuthor.Add(item);
        //    }

        //    //await Application.Current.MainPage.DisplayAlert("Library", BookAuthor, "OK");


        //}
    }
}
