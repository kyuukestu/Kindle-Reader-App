using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mobile_library.Models;
using mobile_library.Services;
using mobile_library.ViewModels;
using Xamarin.Forms;

namespace mobile_library.ViewsPages
{
    public partial class LibraryView : ContentPage
    {
        LibraryViewModel lvm;
        public LibraryView()
        {
            InitializeComponent();
            lvm = new LibraryViewModel();
            this.BindingContext = lvm;
        }

        async void LibraryCollectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            var selectedBook = e.CurrentSelection.FirstOrDefault() as LibraryItem;
            if (selectedBook == null)
            {
                return;
            }
            else
            {
                var booktransform = new Book();
                booktransform.BookID = selectedBook.BookID;
                booktransform.BookAuthor = selectedBook.BookAuthor;
                booktransform.CoverImageUrl = selectedBook.CoverImageUrl;
                booktransform.BookName = selectedBook.BookName;
                booktransform.BookDescription = selectedBook.BookDescription;
                booktransform.BookRating = selectedBook.BookRating;
                booktransform.BookDetail = selectedBook.BookDetail;
                booktransform.GenreID = selectedBook.GenreID;


                await Navigation.PushModalAsync(new BookDetailsView(booktransform));
                ((CollectionView)sender).SelectedItem = null;
            }

        }

        void LibItemDoubleTapped_Tapped(System.Object sender, System.EventArgs e)
        {

        }

        async void RefreshView_Refreshing(System.Object sender, System.EventArgs e)
        {
            await Task.Delay(3000);
            LibraryViewRefresh.IsRefreshing = false;
            await Navigation.PushModalAsync(new LibraryView());
        }
    }
}
