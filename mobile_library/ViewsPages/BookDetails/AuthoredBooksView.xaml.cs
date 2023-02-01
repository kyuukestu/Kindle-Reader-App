using System;
using System.Collections.Generic;
using System.Linq;
using mobile_library.Models;
using mobile_library.ViewModels;
using mobile_library.ViewsPages.BookDetails;
using Xamarin.Forms;

namespace mobile_library.ViewsPages
{
    public partial class AuthoredBooksView : ContentPage
    {
        AuthoredBooksViewModel abvm;
        public AuthoredBooksView(string author)
        {
            InitializeComponent();
            abvm = new AuthoredBooksViewModel(author);
            this.BindingContext = abvm;
        }

        async void AuthoredBooks_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            var selectedBook = e.CurrentSelection.FirstOrDefault() as Book;
            if (selectedBook == null)
            {
                return;
            }
            else
            {
                await Navigation.PushModalAsync(new AuthoredBookDetailView(selectedBook));
                ((CollectionView)sender).SelectedItem = null;
            }
        }

        async void BackButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();

        }
    }
}
