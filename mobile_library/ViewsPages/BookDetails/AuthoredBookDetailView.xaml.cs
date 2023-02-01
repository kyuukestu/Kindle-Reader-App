using System;
using System.Collections.Generic;
using System.Linq;
using Firebase.Database;
using Firebase.Database.Query;
using mobile_library.Models;
using mobile_library.ViewModels;
using Xamarin.Forms;

namespace mobile_library.ViewsPages.BookDetails
{
    public partial class AuthoredBookDetailView : TabbedPage
    {
        FirebaseClient client = new FirebaseClient("https://mobilelibraryapp-default-rtdb.firebaseio.com/");

        AuthoredBookDetailsViewModel abdvm;
        public AuthoredBookDetailView(Book book)
        {
            InitializeComponent();
            abdvm = new AuthoredBookDetailsViewModel(book);
            this.BindingContext = abdvm;
        }

        async void BookChapters_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            var SelectedChapter = e.CurrentSelection.FirstOrDefault() as Chapter;
            if (SelectedChapter == null)
            {
                return;
            }

            await Navigation.PushModalAsync(new AuthorReadingView(SelectedChapter));
            ((CollectionView)sender).SelectedItem = null;
        }

        async void EditBookDetails_Clicked(System.Object sender, System.EventArgs e)
        {
            var UpdateBookDetails = (await client
                .Child("Books")
                .OnceAsync<Book>()).FirstOrDefault
                (a => a.Object.BookID == BookID.Text);

            UpdateBookDetails.Object.BookName = BookName.Text;
            UpdateBookDetails.Object.BookDescription = BookDescription.Text;
            UpdateBookDetails.Object.GenreID = BookGenre.Text;

            await client
                .Child("Books")
                .Child(UpdateBookDetails.Key)
                .PutAsync(UpdateBookDetails.Object);

            await DisplayAlert("Success", "Book Details have been edited", "Ok");
        }

        async void BackButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
