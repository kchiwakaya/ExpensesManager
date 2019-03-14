using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Xamarin.Forms;
using ExpensesTracker.Models;
using System.IO;
using System.Collections.ObjectModel;
using System.Linq;

namespace ExpensesTracker.ViewModels
{
    public class ExpensesDatabaseController:ObservableCollection<Expense>
    {
        static readonly object Locker = new object();
        SQLiteConnection database;
        
        public ExpensesDatabaseController()
        {
            database = DependencyService.Get<ISqlite>().GetConnection();
            database.CreateTable<Expense>();
            
           
        }

        public Expense GetExpense()
        {
            lock (Locker)
            {
                if (database.Table<Expense>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<Expense>().First();
                }
            }

        }
        public int SaveExpenses(Expense expenses)
        {
            lock (Locker)
            {
                if (expenses.Id != 0)
                {
                    database.Update(expenses);
                    return expenses.Id;
                }
                else
                {
                    
                    return database.Insert(expenses);
                    
                    
                }
            }

        }
        public int DeleteExpense(int ID)
        {
            lock (Locker)
            {
                
                return database.Delete<Expense>(ID);
            }
        }
        public IEnumerable<Expense> GetExpenses()
        {
            lock (Locker)
            {
                return (from c in database.Table<Expense>()
                        select c).Where(d => d.Date.Date == DateTime.Now.Date);
            }
            
        }
        public IEnumerable<Expense> GetAllExpenses()
        {
            lock (Locker)
            {
                return (from c in database.Table<Expense>()
                        select c);
            }
            

        }
        public IEnumerable<Expense> GetAllExpenses(DateTime minDate, DateTime maxDate)
        {
            lock (Locker)
            {
                return (from c in database.Table<Expense>()
                        select c).Where(i => i.Date.Date >= minDate && i.Date.Date <= maxDate);
            }


        }
        public  double Total(int month, int year )
        {
            double total =0;
            foreach(var item in GetAllExpenses())
            {
                if(item.Date.Date.Month == month && item.Date.Date.Year==year)
                {
                    total += item.Amount;
                }
            }
            return total;
        }

        



        //}
    }
}

