using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using mobile_library.Models;
using mobile_library.Services;
using mobile_library.ViewsPages;
using Xamarin.Forms;

namespace mobile_library.ViewModels
{
    public class LibraryViewModel : BaseViewModel
    {
        

        public ObservableCollection<LibraryItem> LibraryItems { get; set; }

        public Command RemoveAllFromLibraryCommand { get; set; }

        public Command HomeCommand { get; set; }


        public LibraryViewModel() 
        {
            LibraryItems = new ObservableCollection<LibraryItem>();
            LoadItems();

            //RemoveAllBooks();
            RemoveAllFromLibraryCommand = new Command(async () => await RemoveAllBooksAsync());

            HomeCommand = new Command(async () => await GoHomeAsync());

        }



        private async Task RemoveAllBooksAsync()
        {
            var LS = new LibraryServices();
            LS.RemoveBooksFromLibrary();

            await Application.Current.MainPage.DisplayAlert("Success", "All Library Books have been deleted", "OK");
            await Application.Current.MainPage.Navigation.PushModalAsync(new LibraryView());
        }

        private void LoadItems()
        {
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            var items = cn.Table<LibraryItem>().ToList();
            LibraryItems.Clear();
            foreach (var item in items)
            {
                LibraryItems.Add(new LibraryItem()
                {
                    LibraryBookID = item.LibraryBookID,
                    BookID = item.BookID,
                    BookName = item.BookName,
                    CoverImageUrl = item.CoverImageUrl,
                    GenreID = item.GenreID
                });
                    
            }

        }

        private async Task GoHomeAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new MainTabbedView());

            //await Application.Current.MainPage.DisplayAlert("Library", BookAuthor, "OK");

        }
    }
}
