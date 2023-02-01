using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using mobile_library.Models;

namespace mobile_library.Services
{
    public class ChapterDataServices
    {
        FirebaseClient client;

        public ChapterDataServices()
        {
            client = new FirebaseClient("https://mobilelibraryapp-default-rtdb.firebaseio.com/");
        }

        //Gets all chapters in database
        public async Task<List<Chapter>> GetChapterAsync()
        {
            //var allBooks = await new BookDataServices().GetBookAsync();
            var allchapters = (await client.Child("Chapters")
                .OnceAsync<Chapter>())
                .Select(c => new Chapter
                {
                    ChapterID = c.Object.ChapterID,
                    ChapterName = c.Object.ChapterName,
                    ChapterContent = c.Object.ChapterContent,
                    BookID = c.Object.BookID
                }).ToList();

            return allchapters;
        }

        //Gets all chapters and joins them to Books on BookID
        public async Task<List<Chapter>> GetChaptersJoinBooksAsync()
        {
            var allBooks = await new BookDataServices().GetBookAsync();
            var allchapters = (await client.Child("Chapters")
                .OnceAsync<Chapter>())
                .Select(c => new Chapter
                {
                    ChapterID = c.Object.ChapterID,
                    ChapterName = c.Object.ChapterName,
                    ChapterContent = c.Object.ChapterContent,
                    BookID = c.Object.BookID
                }).ToList();

            var ListChapters = from allC in allchapters
                               join allB in allBooks
                               on allC.BookID equals allB.BookID
                               where allC.BookID == allB.BookID
                               select allC;

            return ListChapters.ToList();
        }

        //Gets the latest 3 chapters posted to the database
        public async Task<ObservableCollection<Chapter>> GetlastestChapter3Async()
        {
            var LatestChapters = new ObservableCollection<Chapter>();
            var chapters = (await GetChapterAsync()).OrderByDescending(c => c.ChapterID).Take(3);
            foreach (var chapter in chapters)
            {
                LatestChapters.Add(chapter);
            }
            return LatestChapters;
        }

        public async Task<List<Chapter>> GetChaptersbyBookID(string BookID)
        {
            var ChaptersbyBookID = new List<Chapter>();
            var chapters = (await GetChapterAsync())
                .Where(p => p.BookID == BookID)
                .ToList();
            foreach (Chapter book in chapters)
            {
                ChaptersbyBookID.Add(book);
            }
            return ChaptersbyBookID;
        }

        //public async Task<List<Chapter>> GetChaptersForBookAsync(string BookID)
        //{
        //    var ChaptersbyBookID = (await new ChapterDataServices().GetChaptersbyBookID(BookID));
        //    foreach (Chapter chapter in ChaptersbyBookID)
        //    {
        //        ChaptersbyBookID.Add(chapter);
        //    }
        //    return ChaptersbyBookID;

            //var allBooks = (await new BookDataServices().GetBookbyID(BookID));
        //}

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


        //public async Task<ObservableCollection<Chapter>> GetAllChaptersAsync(string BookID)
        //{
        //    var ChaptersbyBookID = new ObservableCollection<Chapter>();
        //    var chapters = (await GetChapterAsync()).Where(c => c.BookID == BookID);
        //    foreach (var chapter in chapters)
        //    {
        //        ChaptersbyBookID.Add(chapter);
        //    }
        //    return ChaptersbyBookID;
        //}



        //public async Task<ObservableCollection<Chapter>> GetCobalChaptersAsync()
        //{
        //    var CobelChapters = new ObservableCollection<Chapter>();
        //    var chapters = (await GetChapterAsync()).Where(c => c.BookID == "1");
        //    foreach (var chapter in chapters)
        //    {
        //        CobelChapters.Add(chapter);
        //    }
        //    return CobelChapters;
        //}

    }
}
