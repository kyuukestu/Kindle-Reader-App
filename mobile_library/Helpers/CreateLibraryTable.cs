using System;
using mobile_library.Models;
using Xamarin.Forms;

namespace mobile_library.Helpers
{
    public class CreateLibraryTable
    {
        public bool CreateTable()
        {
            try
            {
                var cn = DependencyService.Get<ISQLite>().GetConnection();
                cn.CreateTable<LibraryItem>();
                cn.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
