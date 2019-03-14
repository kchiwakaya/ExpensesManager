using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ExpensesTracker.ViewModels;
using ExpensesTracker.Models;

namespace ExpensesTracker.Views.Reports
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class All_Transactions : ContentPage
	{
       ExpensesDatabaseController expenses = new ExpensesDatabaseController();
        IncomeDabataseController IncomeDabataseController = new IncomeDabataseController();
        public All_Transactions ()
		{
			InitializeComponent ();
           
          
                _expensesList.ItemsSource = expenses.GetAllExpenses();
                _incomeList.ItemsSource = IncomeDabataseController.GetAllIncomes();
            
        }
       
        private void _expensesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void _incomeList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        private void StartDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            _expensesList.ItemsSource = expenses.GetAllExpenses(StartDate.Date, EndDate.Date.Date);
            _incomeList.ItemsSource = IncomeDabataseController.GetAllIncomes(StartDate.Date, EndDate.Date);
        }

        private void EndDate_DateSelected(object sender, DateChangedEventArgs e)
        {
            _expensesList.ItemsSource = expenses.GetAllExpenses(StartDate.Date, EndDate.Date);
            _incomeList.ItemsSource = IncomeDabataseController.GetAllIncomes(StartDate.Date, EndDate.Date);
        }
    }
}