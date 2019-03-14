using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;
using ExpensesTracker.Models;
using System.Linq;

namespace ExpensesTracker.ViewModels
{
    public class In_CategoryController
    {
        static readonly object Locker = new object();
        SQLiteConnection database;
        public In_CategoryController()
        {
            database = DependencyService.Get<ISqlite>().GetConnection();
            database.CreateTable<IncomeCategories>();
        }
        public IncomeCategories GetCategory()
        {
            lock (Locker)
            {
                if (database.Table<IncomeCategories>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<IncomeCategories>().First();
                }
            }

        }
        public int SaveCategory(IncomeCategories cat)
        {
            lock (Locker)
            {
                if (cat.Id != 0)
                {
                    database.Update(cat);
                    return cat.Id;
                }
                else
                {
                    return database.Insert(cat);
                }
            }

        }
        public int DeleteCategory(int ID)
        {
            lock (Locker)
            {
                return database.Delete<IncomeCategories>(ID);
            }
        }
        public IEnumerable<IncomeCategories> GetCategories()
        {
            lock (Locker)
            {
                var incomes = from c in database.Table<IncomeCategories>()
                              select c;
                if(incomes.Count() ==0)
                {
                    IncomeCategories inc1 = new IncomeCategories
                    {
                        Name="Salary"
                    };
                    IncomeCategories inc2 = new IncomeCategories
                    {
                        Name="Stock Options"
                    };
                    SaveCategory(inc1);
                    SaveCategory(inc2);
                    incomes = from c in database.Table<IncomeCategories>()
                              select c;
                }
                return incomes;
            }

        }
    }
}
