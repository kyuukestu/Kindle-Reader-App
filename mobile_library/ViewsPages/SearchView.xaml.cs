using System;
using System.Collections.Generic;
using System.Linq;
using mobile_library.Models;
using mobile_library.ViewModels;
using Xamarin.Forms;

namespace mobile_library.ViewsPages
{
    public partial class SearchView : ContentPage
    {
        SearchViewModel svm;
        public SearchView(string search)
        {
            InitializeComponent();
            svm = new SearchViewModel(search);
            this.BindingContext = svm;
        }

        async void CollectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
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
