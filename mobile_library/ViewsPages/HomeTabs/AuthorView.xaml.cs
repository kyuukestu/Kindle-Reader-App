using System;
using System.Collections.Generic;
using System.Linq;
using Firebase.Database;
using Firebase.Database.Query;
using mobile_library.Helpers;
using mobile_library.Models;
using mobile_library.Services;
using mobile_library.ViewModels;
using Xamarin.Forms;

namespace mobile_library.ViewsPages
{
    public partial class AuthorView : ContentPage
    {
        FirebaseClient client = new FirebaseClient("https://mobilelibraryapp-default-rtdb.firebaseio.com/");

        AuthorViewModel avm;
        public AuthorView()
        {
            InitializeComponent();

            avm = new AuthorViewModel();
            this.BindingContext = avm;
            //((AuthorViewModel)this.BindingContext).BookAuthor = "userone";
        }

        async void WriteNewBook_Clicked(System.Object sender, System.EventArgs e)
        {
            string holdBookID = Guid.NewGuid().ToString();

            await client.Child("Books").PostAsync(new Book()
            {
                BookAuthor = AuthorName.Text,
                BookName = BookName.Text,
                BookDescription = BookDescription.Text,
                GenreID = GenreID.Text,
                CoverImageUrl = CoverImageUrl.Text,
                BookID = holdBookID,
            });

            //var Variable = await (new BookDataServices().GetBookAsync());

            BookName.Text = null;
            BookDescription.Text = null;
            GenreID.Text = null;
            CoverImageUrl.Text = null;

            await Navigation.PushModalAsync(new AddChapterView(holdBookID));
        }

         async void MyBooksButton_Clicked(System.Object sender, System.EventArgs e)
        {
            var author = AuthorName.Text;

            await Navigation.PushModalAsync(new AuthoredBooksView(author));
        }
    }
}
