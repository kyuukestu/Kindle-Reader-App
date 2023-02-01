using System;
using System.Collections.ObjectModel;
using mobile_library.Models;
using mobile_library.Services;
using Firebase.Database;
using Firebase.Database.Query;

namespace mobile_library.ViewModels
{
    public class ChapterListViewModel : BaseViewModel
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

        public ObservableCollection<Chapter> Chapters { get; set; }

        public ObservableCollection<Chapter> Cobel { get; set; }

        public ChapterListViewModel()
        { }

        FirebaseClient client;

        public ChapterListViewModel(Book book)
        {
            client = new FirebaseClient("https://mobilelibraryapp-default-rtdb.firebaseio.com/");

            SelectedBook = book;

            Chapters = new ObservableCollection<Chapter>();

            //GetChapters(book.BookID);

            //GetCobelChapters();
        }

        //public async Task<ObservableCollection<Chapter>> GetlastestChapterAsync()
        //{
        //    var LatestChapters = new ObservableCollection<Chapter>();
        //    var chapters = (await GetChapterAsync()).OrderByDescending(c => c.ChapterID).Take(3);
        //    foreach (var chapter in chapters)
        //    {
        //        LatestChapters.Add(chapter);
        //    }
        //    return LatestChapters;
        //}

        //private async void GetChapters(string bookID)
        //{
        //    var data = await new ChapterDataServices().GetAllChaptersAsync(bookID);
        //    Chapters.Clear();
        //    foreach(var item in data)
        //    {
        //        Chapters.Add(item);
        //    }
        //}


    }
}
