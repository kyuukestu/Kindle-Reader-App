using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using mobile_library.Models;
using mobile_library.Services;
using mobile_library.ViewsPages;
using Xamarin.Forms;

namespace mobile_library.ViewModels
{
    public class BookDetailsViewModel : BaseViewModel
    {
        private Book _SelectedBook;
        public Book SelectedBook
        {
            set
            {
                _SelectedBook = value;
                OnPropertyChanged();
            }

            get
            {
                return _SelectedBook;
            }
        }

        public Command AddToLibraryCommand { get; set; }
        public Command ViewLibraryCommand { get; set; }
        public Command HomeCommand { get; set; }

        public ObservableCollection<Book> BooksbyAuthor { get; set; }
        public ObservableCollection<Book> Book { get; set; }

        //From ChapterListViewModel
        public ObservableCollection<Chapter> ChaptersbyBookID { get; set; }



        public BookDetailsViewModel()
        { }

        public BookDetailsViewModel(Book book)
        {
            SelectedBook = book;

            AddToLibraryCommand = new Command(() => AddToLibrary());
            ViewLibraryCommand = new Command(async () => await ViewLibraryAsync());
            HomeCommand = new Command(async () => await GoHomeAsync());

            BooksbyAuthor = new ObservableCollection<Book>();
            Book = new ObservableCollection<Book>();

            //CLVM
            ChaptersbyBookID = new ObservableCollection<Chapter>();
            //CLVM


            //convert to observable collection of Book
            GetBookChaptersbyBookID(SelectedBook.BookID);
        }


        //Inherited by AuthoredBookDetailsViewModel
        protected async void GetBookChaptersbyBookID(string bookID)
        {
            var data = await new ChapterDataServices().GetChaptersbyBookID(bookID);
            ChaptersbyBookID.Clear();
            foreach (var item in data)
            {
                ChaptersbyBookID.Add(item);
            }

        }

        //Inherited by AuthoredBookDetailsViewModel
        protected async Task GoHomeAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new MainTabbedView());
        }

        private async Task ViewLibraryAsync()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new LibraryView());
        }

        private void AddToLibrary()
        {
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            try
            {
                LibraryItem li = new LibraryItem()
                {
                    BookID = SelectedBook.BookID,
                    BookName = SelectedBook.BookName,
                    CoverImageUrl = SelectedBook.CoverImageUrl
                };
                var item = cn.Table<LibraryItem>().ToList()
                    .FirstOrDefault(c => c.BookID == SelectedBook.BookID);
                if (item == null)
                {
                    cn.Insert(li);
                    Application.Current.MainPage.DisplayAlert("Library", "Book added to Library", "OK");
                }
                else
                {
                    Application.Current.MainPage.DisplayAlert("Library", "Book already in Library", "OK");
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
          
    }
}
