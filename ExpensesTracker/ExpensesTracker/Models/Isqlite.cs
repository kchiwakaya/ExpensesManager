using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ExpensesTracker.Models
{
    public interface ISqlite
    {
        SQLiteConnection GetConnection();
    }
}
