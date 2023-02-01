using System;
using System.Collections.Generic;
using System.Linq;
using Firebase.Database;
using Firebase.Database.Query;
using mobile_library.Models;
using mobile_library.ViewModels;
using Xamarin.Forms;

namespace mobile_library.ViewsPages
{
    public partial class AuthorReadingView : ContentPage
    {
        FirebaseClient client = new FirebaseClient("https://mobilelibraryapp-default-rtdb.firebaseio.com/");

        AuthorReadingViewModel arvm;
        public AuthorReadingView(Chapter chapter)
        {
            InitializeComponent();
            arvm = new AuthorReadingViewModel(chapter);
            this.BindingContext = arvm;
        }

        async void EditChapter_Clicked(System.Object sender, System.EventArgs e)
        {
            var UpdateChapterDetails = (await client
                .Child("Chapters")
                .OnceAsync<Chapter>()).FirstOrDefault
                (c => c.Object.ChapterID == int.Parse(ChapterNumber.Text));

            UpdateChapterDetails.Object.ChapterID = int.Parse(ChapterNumber.Text);
            UpdateChapterDetails.Object.ChapterName = ChapterTitle.Text;
            UpdateChapterDetails.Object.ChapterContent = ChapterContent.Text;

            await client
                .Child("Chapters")
                .Child(UpdateChapterDetails.Key)
                .PutAsync(UpdateChapterDetails.Object);

            await DisplayAlert("Success", "Chapter Details have been edited", "Ok");
            await Navigation.PopModalAsync();
        }

        async void BackButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
