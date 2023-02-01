using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using mobile_library.Models;
using mobile_library.ViewModels;
using Xamarin.Forms;

namespace mobile_library.ViewsPages
{
    public partial class AddChapterView : ContentPage
    {
        FirebaseClient client = new FirebaseClient("https://mobilelibraryapp-default-rtdb.firebaseio.com/");

        AddChapterViewModel acvm;
        public AddChapterView(string bookID)
        {
            InitializeComponent();
            acvm = new AddChapterViewModel(bookID);
            this.BindingContext = acvm;
        }

        async void SaveChapter_Clicked(System.Object sender, System.EventArgs e)
        {
            int value = int.Parse(ChapterNumber.Text);

            await client.Child("Chapters").PostAsync(new Chapter()
            {
                BookID = BookID.Text,
                ChapterID = value,
                ChapterName = ChapterTitle.Text,
                ChapterContent = ChapterContent.Text,
            });

            await DisplayAlert("Success","Chapter Saved successfully" ,"OK");
        }

        async void HomeButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new MainTabbedView());
        }
    }
}
