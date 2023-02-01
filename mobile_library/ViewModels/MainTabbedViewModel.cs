using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using mobile_library.Models;
using mobile_library.Services;
using mobile_library.ViewsPages;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace mobile_library.ViewModels
{
    public class MainTabbedViewModel : BaseViewModel
    {
        private string _Username;
        public string Username
        {
            set
            {
                _Username = value;
                OnPropertyChanged();
            }

            get
            {
                return _Username;
            }
        }

        private int _UserLibraryBookCount;
        public int UserLibraryBookCount
        {
            set
            {
                _UserLibraryBookCount = value;
                OnPropertyChanged();
            }


            get
            {
                return _UserLibraryBookCount;
            }
        }

        private string _Selection;
        public string Selection
        {
            set
            {
                _Selection = value;
                OnPropertyChanged();
            }

            get
            {
                return _Selection;
            }
        }

        //Maintains 'Genres' Section of Main Page.
        public ObservableCollection<Genre> Genres { get; set; }

        //Maintains 'Latest Chapters' Section of Main Page.
        public ObservableCollection<Chapter> LatestChapters { get; set; }

        //Maintains 'Latest Books' Section of Main page.
        public ObservableCollection<Book> LatestBooks { get; set; }


        //Chapter view command should be used to get user from tabbed pages to chapter
        public Command ViewLibraryCommand { get; set; }
        public Command LogoutCommand { get; set; }



        public MainTabbedViewModel()
        {
            var username = Preferences.Get("Username", String.Empty);
            if(String.IsNullOrEmpty(username))
            {
                Username = "Guest";
            }
            else
            {
                Username = username;
            }


            UserLibraryBookCount = new LibraryServices().GetUserBookCount();

            Genres = new ObservableCollection<Genre>();
            LatestChapters = new ObservableCollection<Chapter>();
            LatestBooks = new ObservableCollection<Book>();

            ViewLibraryCommand = new Command(async () => await ViewLibraryAsync());
            LogoutCommand = new Command(async () => await LogoutAsync());


            GetGenre();
            GetLatestChapters();
            GetLatestBooks();

        }

       
        //Function to Logout
        private async Task LogoutAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new LogoutView());
        }

        //Fuction to take user to Library view
        private async Task ViewLibraryAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new LibraryView());
        }

        //Gets Genre for Genres Section
        private async void GetGenre()
        {
            var data = await new GenreDataServices().GetGenreAsync();
            Genres.Clear();

            foreach (var item in data)
            {
                Genres.Add(item);
            }
        }

        //Get Chapters for Latest Chapters Section
        private async void GetLatestChapters()
        {
            var data = await new ChapterDataServices().GetlastestChapter3Async();
            LatestChapters.Clear();
            foreach (var item in data)
            {
                LatestChapters.Add(item);
            }
        }

        //Gets Books for Latest Books Sections
        private async void GetLatestBooks()
        {
            var data = await new BookDataServices().GetLatestBooks();
            LatestBooks.Clear();
            foreach (var item in data)
            {
                LatestBooks.Add(item);
            }
        }

    }
}
