using System;
using System.Collections.ObjectModel;
using mobile_library.Models;
using mobile_library.Services;
using Xamarin.Forms;

namespace mobile_library.ViewModels
{
    public class AuthoredBookDetailsViewModel : BookDetailsViewModel
    {
        //private Book _SelectedBook;
        //public Book SelectedBook
        //{
        //    set
        //    {
        //        _SelectedBook = value;
        //        OnPropertyChanged();
        //    }

        //    get
        //    {
        //        return _SelectedBook;
        //    }
        //}

        //public ObservableCollection<Chapter> ChaptersbyBookID { get; set; }


        public AuthoredBookDetailsViewModel()
        { }

        public AuthoredBookDetailsViewModel(Book book)
        {
            SelectedBook = book;


            ChaptersbyBookID = new ObservableCollection<Chapter>();
            Book = new ObservableCollection<Book>();

            GetBookChaptersbyBookID(SelectedBook.BookID);

            HomeCommand = new Command(async () => await GoHomeAsync());
        }


    }
}
