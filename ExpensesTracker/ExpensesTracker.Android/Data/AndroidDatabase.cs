using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ExpensesTracker.Models;
using System.IO;
using ExpensesTracker.Droid.Data;


[assembly: Xamarin.Forms.Dependency(typeof(AndroidDatabase))]
namespace ExpensesTracker.Droid.Data
{
    public class AndroidDatabase:ISqlite
    {
        public SQLite.SQLiteConnection GetConnection()
        {
            var SqliteFileName = "Expenses.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
           // string libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(documentsPath, SqliteFileName);
            var con = new SQLite.SQLiteConnection(path);
            return con;
        }
    }
}