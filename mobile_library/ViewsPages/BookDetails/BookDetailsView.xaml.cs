using System;
using System.Collections.Generic;
using System.Linq;
using mobile_library.Models;
using mobile_library.ViewModels;
using Xamarin.Forms;

namespace mobile_library.ViewsPages
{
    public partial class BookDetailsView : TabbedPage
    {
        BookDetailsViewModel bdvm;
        public BookDetailsView(Book book)
        {
            InitializeComponent();
            bdvm = new BookDetailsViewModel(book);
            this.BindingContext = bdvm;
        }

        async void BookChapters_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            var SelectedChapter = e.CurrentSelection.FirstOrDefault() as Chapter;
            if (SelectedChapter == null)
            {
                return;
            }

            await Navigation.PushModalAsync(new ReadingView(SelectedChapter));
            ((CollectionView)sender).SelectedItem = null;
        }

        async void BackButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}
