using System;
using System.Collections.Generic;
using mobile_library.Models;
using mobile_library.ViewModels;
using Xamarin.Forms;

namespace mobile_library.ViewsPages
{
    public partial class ReadingView : ContentPage
    {
        ReadingViewModel rvm;
        public ReadingView(Chapter chapter)
        {
            InitializeComponent();
            rvm = new ReadingViewModel(chapter);
            this.BindingContext = rvm;
        }

        async void BackButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
