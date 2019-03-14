using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpensesTracker.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ExpensesTracker.ViewModels;
using System.Collections.ObjectModel;

namespace ExpensesTracker.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ExpensesList : ContentPage
	{
        ExpensesDatabaseController ExpenseDatabase;
       // private double Total = 0;
        ObservableCollection<Expense> _expenses;
        public ExpensesList()
        {
            InitializeComponent();
            
            
                 ExpenseDatabase = new ExpensesDatabaseController();
                if(ExpenseDatabase.GetExpenses() != null)
                {
                    _expenses = new ObservableCollection<Expense>(ExpenseDatabase.GetExpenses());
                }
                
           
           
          
                _ExpensesList.ItemsSource = _expenses;
            
          
           // GetExpenses();//display Expenses
        }
        //async void ExpenseList_ItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    if (e.Item == null)
        //        return;
        //    var exes = e.Item as Expense;
        //    var answer = await DisplayActionSheet("Delete", "Yes", "No", "Do you want to delete?");
        //    if (answer == "Yes")
        //    {
        //        _expenses.Remove(exes);
        //        ExpenseDatabase.DeleteExpense(exes.Id);
                
        //    }
        //    else
        //    {
        //        return;
        //    }
        //}

        async void AddExpense_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AddExpense()));
        }
        //private void GetExpenses()
        //{
        //    _ExpensesList.ItemsSource = ExpenseDatabase.GetExpenses();
        //    foreach (var item in ExpenseDatabase.GetExpenses())
        //    {
        //        Total += item.Amount;
        //    }
        //    //Tot.Text = "Total Expense       " + Total.ToString();
        //    Total = 0;//reset total since it's always calculated about

        //}
        async void AddItem_Clicked (object sender, EventArgs e)
        {
           await Navigation.PushModalAsync(new NavigationPage(new AddExpense()));
        }

        async void _ExpensesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var expense = e.SelectedItem as Expense;
           



            
            var response = await DisplayActionSheet("Action", "Cancel", "Delete", "Edit", "View");
            if (response == "View")
            {

                await Navigation.PushModalAsync(new NavigationPage(new ExpenseDetails() { BindingContext = expense }));
            }
            else if (response == "Edit")
            {
                //edit
                await Navigation.PushModalAsync(new NavigationPage(new EditExpenses(expense)));
            }
            else if (response == "Delete")
            {

                var answer = await DisplayActionSheet("Delete", "Yes", "No", "Do you want to delete?");
                if (answer == "Yes")
                {
                    _expenses.Remove(expense);
                    ExpenseDatabase.DeleteExpense(expense.Id);
                    //app.Income_collection.Remove(exes);

                    //GetIncomes();
                }
                else
                {
                    return;
                }
            }
        }
    }
}