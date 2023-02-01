using System;
using System.Collections.Generic;
using mobile_library.Models;
using mobile_library.ViewModels;
using Xamarin.Forms;

namespace mobile_library.ViewsPages
{
    public partial class ChapterListView : ContentPage
    {
        ChapterListViewModel clvm;
        public ChapterListView(Book book)
        {
            InitializeComponent();
            clvm = new ChapterListViewModel(book);
            this.BindingContext = clvm;
        }

        void BookChapters_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
        }
    }
}
