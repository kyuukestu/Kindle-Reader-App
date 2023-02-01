using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using mobile_library.Models;
using mobile_library.Services;

namespace mobile_library.ViewModels
{
    public class GenreViewModel : BaseViewModel
    {
        private Genre _SelectedGenre;
        public Genre SelectedGenre
        {
            set
            {
                _SelectedGenre = value;
                OnPropertyChanged();
            }

            get
            {
                return _SelectedGenre;
            }
        }

        public ObservableCollection<Book> BooksbyGenre { get; set; }

        private int _TotalBooks;
        public int TotalBooks
        {
            set
            {
                _TotalBooks = value;
                OnPropertyChanged();
            }

            get
            {
                return _TotalBooks;
            }
        }

        //Parameter-less constructor needed in addition to parameterized contstructor.
        public GenreViewModel()
        { }


        public GenreViewModel(Genre genre)
        {
            SelectedGenre = genre;
            BooksbyGenre = new ObservableCollection<Book>();
            GetBooks(genre.GenreID);
        }


        public async void GetBooks(string genreID)
        {
            var data = await new BookDataServices().GetBooksByGenreAsync(genreID);
            BooksbyGenre.Clear();
            foreach (var item in data)
            {
                BooksbyGenre.Add(item);
            }
            TotalBooks = BooksbyGenre.Count;
        }
    }

}