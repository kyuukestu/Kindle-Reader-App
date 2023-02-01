using System;
using System.Collections.Generic;
using mobile_library.Helpers;

using Xamarin.Forms;

namespace mobile_library.ViewsPages
{
    public partial class SettingsView : ContentPage
    {
        public SettingsView()
        {
            InitializeComponent();
        }

        async void GenreButton_Clicked(System.Object sender, System.EventArgs e)
        {
            var AddGenreData = new AddGenreData();
            await AddGenreData.AddGenreAsync();
        }

        async void BookButton_Clicked(System.Object sender, System.EventArgs e)
        {
            var AddBookData = new AddBookData();
            await AddBookData.AddBookDataAsync();
        }

        async void ChapterButton_Clicked(System.Object sender, System.EventArgs e)
        {
            var AddChapterData = new AddChapterData();
            await AddChapterData.AddChapterAsync();
        }

        void LibraryButton_Clicked(System.Object sender, System.EventArgs e)
        {
            var createlibrarytable = new CreateLibraryTable();
            if(createlibrarytable.CreateTable())
            {
                DisplayAlert("Success", "Library Table Created", "OK");
            }
            else
            {
                DisplayAlert("Error", "Error while creating table", "OK");
            }
        }
    }
}
