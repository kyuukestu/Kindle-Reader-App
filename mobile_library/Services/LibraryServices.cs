using System;
using mobile_library.Models;
using Xamarin.Forms;

namespace mobile_library.Services
{
    public class LibraryServices
    {
        public int GetUserBookCount()
        {
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            var count = cn.Table<LibraryItem>().Count();
            cn.Close();
            return count;
        }

        public void RemoveBooksFromLibrary()
        {
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            cn.DeleteAll<LibraryItem>();
            cn.Commit();
            cn.Close();

        }

        public void RemoveBookFromLibrary(string BookID)
        {
            var cn = DependencyService.Get<ISQLite>().GetConnection();
            cn.Delete<LibraryItem>(BookID);
            cn.Commit();
            cn.Close();
        }
    }
}
