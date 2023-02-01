using System;
using System.Collections.ObjectModel;
using mobile_library.Models;
using mobile_library.Services;

namespace mobile_library.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {

        public ObservableCollection<Book> BooksbySearch{ get; set; }


        public SearchViewModel()
        {
        }

        public SearchViewModel(string search)
        {
            var SelectedSearch = search;
            BooksbySearch = new ObservableCollection<Book>();

            GetBooksbyAuthor(SelectedSearch);
            GetBooksbyTitle(SelectedSearch);
        }

        private async void GetBooksbyTitle(string search)
        {
            var data = await new BookDataServices().GetBooksbyTitleAsync(search);
            BooksbySearch.Clear();
            foreach (var item in data)
            {
                BooksbySearch.Add(item);
            }
        }

        private async void GetBooksbyAuthor(string author)
        {
            var data = await new BookDataServices().GetBooksbyAuthorAsync(author);
            BooksbySearch.Clear();
            foreach (var item in data)
            {
                BooksbySearch.Add(item);
            }
        }
    }
}
