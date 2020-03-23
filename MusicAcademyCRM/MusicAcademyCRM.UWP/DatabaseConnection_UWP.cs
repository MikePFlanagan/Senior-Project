using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Windows.Storage;
using System.IO;
using MusicAcademyCRM.UWP;

[assembly: Dependency(typeof(DatabaseConnection_UWP))]


namespace MusicAcademyCRM.UWP
{
    public class DatabaseConnection_UWP : IDatabaseConnection
    {
       

        SQLiteConnection IDatabaseConnection.DbConnection()
        {
            var dbName = "academy_db.sqlite";
            var path = Path.Combine(ApplicationData.
                Current.LocalFolder.Path, dbName);
            return new SQLiteConnection(path);
        }
    }
}
