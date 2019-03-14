using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace ExpensesTracker.Models
{
    public class ExpensesCategory
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public String Name { get; set; }
    }
}
