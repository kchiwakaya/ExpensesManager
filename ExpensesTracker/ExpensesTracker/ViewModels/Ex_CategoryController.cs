using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;
using ExpensesTracker.Models;
using System.Linq;

namespace ExpensesTracker.ViewModels
{
    public class Ex_CategoryController
    {
        static readonly object Locker = new object();
        SQLiteConnection database;
        public Ex_CategoryController()
        {
            database = DependencyService.Get<ISqlite>().GetConnection();
            database.CreateTable<ExpensesCategory>();
        }
        public ExpensesCategory GetCategory()
        {
            lock (Locker)
            {
                if (database.Table<Expense>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<ExpensesCategory>().First();
                }
            }

        }
        public int SaveCategory(ExpensesCategory cat)
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
                return database.Delete<ExpensesCategory>(ID);
            }
        }
        public IEnumerable<ExpensesCategory> GetCategories()
        {
            lock (Locker)
            {
                var expenses= (from c in database.Table<ExpensesCategory>()
                               select c);
                if(expenses.Count() == 0)
                {
                    //seeding
                    

                        ExpensesCategory expensesCategory = new ExpensesCategory()
                        {
                            Name = "Groceries"
                        };
                        ExpensesCategory expensesCategory1 = new ExpensesCategory()
                        {
                            Name = "Fuel"
                        };
                        ExpensesCategory expensesCategory2 = new ExpensesCategory()
                        {
                            Name = "Drinks"
                        };
                        ExpensesCategory expensesCategory3 = new ExpensesCategory()
                        {
                            Name = "Eating Out"
                        };
                        ExpensesCategory expensesCategory4 = new ExpensesCategory()
                        {
                            Name = "Clothes"
                        };
                        SaveCategory(expensesCategory);
                        SaveCategory(expensesCategory1);
                        SaveCategory(expensesCategory2);
                        SaveCategory(expensesCategory3);
                        SaveCategory(expensesCategory4);
                    expenses = (from c in database.Table<ExpensesCategory>()
                                select c);

                }
              
                return expenses;
            }

        }
    }
}
