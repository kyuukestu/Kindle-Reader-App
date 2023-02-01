using System;
using System.IO;
using mobile_library.Models;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(mobile_library.Droid.SQLite_Android))]
namespace mobile_library.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFileName = "MyDatabase.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFileName);
            var cn = new SQLiteConnection(path);

            return cn;
        }
    }
}
