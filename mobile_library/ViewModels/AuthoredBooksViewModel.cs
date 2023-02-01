using System;
using System.Collections.ObjectModel;
using mobile_library.Models;
using mobile_library.Services;
using Xamarin.Forms;

namespace mobile_library.ViewModels
{
    public class AuthoredBooksViewModel : BaseViewModel
    {
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

        public AuthoredBooksViewModel()
        { }

        public AuthoredBooksViewModel(string author)
        {
            BooksbyAuthor = new ObservableCollection<Book>();

            GetBooksbyAuthor(author);


        }

        private async void GetBooksbyAuthor(string author)
        {
            var data = await new BookDataServices().GetBooksbyAuthorAsync(author);
            BooksbyAuthor.Clear();
            foreach (var item in data)
            {
                BooksbyAuthor.Add(item);
            }

            //await Application.Current.MainPage.DisplayAlert("Library", BookAuthor, "OK");
        }
    }
}
