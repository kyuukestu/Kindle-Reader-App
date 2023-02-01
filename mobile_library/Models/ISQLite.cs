using System;
using SQLite;

namespace mobile_library.Models
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
