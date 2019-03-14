using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Linq;
using ExpensesTracker.Models;
using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace ExpensesTracker.ViewModels
{
    class IncomeDabataseController
    {
        static readonly object Locker = new object();
        SQLiteConnection database;
        //ObservableCollection<Income> _incomes = new ObservableCollection<Income>();
        public IncomeDabataseController()
        {
            database = DependencyService.Get<ISqlite>().GetConnection();
            database.CreateTable<Income>();
        }
        public Income GetIncome()
        {
            lock (Locker)
            {
                if (database.Table<Income>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<Income>().First();
                }
            }

        }
        public int SaveIncome(Income income)
        {
            lock (Locker)
            {
                if (income.Id != 0)
                {
                    database.Update(income);
                    
                    return income.Id;
                }
                else
                {
                   // _incomes.Add(income);
                    return database.Insert(income);

                }
            }
        }
      
        public IEnumerable<Income> GetAllIncomes()
        {

            lock (Locker)
            {

                var incomes = (from c in database.Table<Income>()
                              select c);
                ObservableCollection<Income> incs = new ObservableCollection<Income>(incomes); //this is working
                //  _incomes = incs;
                return incomes;
            }
           
            // return _incomes; not working
        }
        public IEnumerable<Income> GetIncomes()
        {

            lock (Locker)
            {

                var incomes = (from c in database.Table<Income>()
                               select c).Where(i => i.Date.Date.Month == DateTime.Now.Month && i.Date.Date.Year == DateTime.Now.Year);
                ObservableCollection<Income> incs = new ObservableCollection<Income>(incomes); //this is working
                //  _incomes = incs;
                return incomes;
            }

            // return _incomes; not working
        }
        public IEnumerable<Income> GetAllIncomes(DateTime minDate,DateTime maxDate)
        {

            lock (Locker)
            {

                var incomes = (from c in database.Table<Income>()
                               select c).Where(i => i.Date.Date >= minDate && i.Date.Date <= maxDate);
                
                //  _incomes = incs;
                return incomes;
            }

            // return _incomes; not working
        }
        public int DeleteIncome(int ID)
        {
            lock (Locker)
            {

                //var inc = database.Table<Income>().Where(b => b.Id == ID).FirstOrDefault();
               // _incomes.Remove(inc);
                return database.Delete<Income>(ID);
            }
        }
        public double Total(int month, int year)
        {
            double total = 0;
            foreach (var item in GetAllIncomes())
            {
                if (item.Date.Date.Month == month && item.Date.Date.Year == year)
                {
                    total += item.Amount;
                }
            }
            return total;
        }

    }
}
