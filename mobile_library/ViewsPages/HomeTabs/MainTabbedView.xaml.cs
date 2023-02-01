using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mobile_library.Helpers;
using mobile_library.Models;
using mobile_library.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile_library.ViewsPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainTabbedView : TabbedPage
    {
        MainTabbedViewModel mtvm;
        public MainTabbedView()
        {
            InitializeComponent();

            mtvm = new MainTabbedViewModel();
            this.BindingContext = mtvm;

        }

        async void GenreCollection_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            var genre = e.CurrentSelection.FirstOrDefault() as Genre;
            if (genre == null)
            {
                return;
            }

            await Navigation.PushModalAsync(new GenreView(genre));

            ((CollectionView)sender).SelectedItem = null;
            
        }

        async void LastestSeriesCollection_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            var selectedBook = e.CurrentSelection.FirstOrDefault() as Book;
            if (selectedBook == null)
            {
                return;
            }
            else
            {
                await Navigation.PushModalAsync(new BookDetailsView(selectedBook));
                ((CollectionView)sender).SelectedItem = null;
            }
           
        }

        async void latestchapters_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            var SelectedChapter = e.CurrentSelection.FirstOrDefault() as Chapter;
            if (SelectedChapter == null)
            {
                return;
            }

            await Navigation.PushModalAsync(new ReadingView(SelectedChapter));
            ((CollectionView)sender).SelectedItem = null;
        }

        async void LogoutButton_Clicked(System.Object sender, System.EventArgs e)
        {
            await Navigation.PushModalAsync(new LogoutView());
        }

         void SearchBar_SearchButtonPressed(System.Object sender, System.EventArgs e)
        {
            //await Navigation.PushModalAsync(new SearchView(SearchBar.Text));
        }
    }
}
