using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ExpensesTracker.Models
{
    public class Income
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public string Category { get; set; }
        public string Note { get; set; }
        public Income(){}
    }
}
