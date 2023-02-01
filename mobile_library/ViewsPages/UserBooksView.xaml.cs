using System;
using System.Collections.Generic;
using System.Linq;
//using Firebase.Database;
using mobile_library.Models;
using mobile_library.ViewModels;
using Xamarin.Forms;

namespace mobile_library.ViewsPages
{
    public partial class UserBooksView : ContentPage
    {

        //FirebaseClient client = new FirebaseClient("https://mobilelibraryapp-default-rtdb.firebaseio.com/");

        UserBooksViewModel ubvm;
        public UserBooksView(Book book)
        {
            InitializeComponent();

            ubvm = new UserBooksViewModel(book);
            this.BindingContext = ubvm;

            ((UserBooksViewModel)this.BindingContext).BookAuthor = User.Text as string;

        }

        async void AuthoredBooksCollection_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            var selectedBook = e.CurrentSelection.FirstOrDefault() as Book;
            if (selectedBook == null)
            {
                return;
            }

            await Navigation.PushModalAsync(new BookDetailsView(selectedBook));
            ((CollectionView)sender).SelectedItem = null;
        }
    }
}
