using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using mobile_library.Models;
using mobile_library.Services;
using mobile_library.ViewsPages;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace mobile_library.ViewModels
{
    public class AuthorViewModel : BaseViewModel
    {
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

        public ObservableCollection<Book> BooksbyAuthor { get; set; }

        public Command HomeCommand { get; set; }
        public Command GetUserBooksCommand { get; set; }


        public AuthorViewModel()
        {
            
            BooksbyAuthor = new ObservableCollection<Book>();
            //GetUserBooks(BookAuthor);

            var username = Preferences.Get("Username", String.Empty);
            if (String.IsNullOrEmpty(username))
            {
                Username = "Guest";
            }
            else
            {
                Username = username;
            }

            HomeCommand = new Command(async () => await GoHomeAsync());

            //GetUserBooks();
            //GetUserBooksCommand = new Command(async () => await GetUserBooksAsync());

            GetBooksbyAuthor(BookAuthor);
        }

        private async void GetBooksbyAuthor(string bookauthor)
        {
            var data = await new BookDataServices().GetBooksbyAuthorAsync(bookauthor);
            BooksbyAuthor.Clear();
            foreach (var item in data)
            {
                BooksbyAuthor.Add(item);
            }

        }


        private async Task GoHomeAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new MainTabbedView());

            //await Application.Current.MainPage.DisplayAlert("Library", BookAuthor, "OK");

        }
    }
}
