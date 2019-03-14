using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpensesTracker.ViewModels;
using ExpensesTracker.Models;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace ExpensesTracker.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddExpense : ContentPage
	{
       
        public ExpensesDatabaseController ExpensesDatabase  = new ExpensesDatabaseController();
        ObservableCollection<Expense> _expenses = new ObservableCollection<Expense>();
        Ex_CategoryController catdatabase = new Ex_CategoryController();
        List<string> catList = new List<string>();
        //private App app = new App();
        public AddExpense ()
		{
			InitializeComponent ();
            foreach (var item in catdatabase.GetCategories())
            {
                catList.Add(item.Name);
            }
            ExCatList.ItemsSource = catList;
        }

        private void BtnSave_Clicked(object sender, EventArgs e)
        {

            if(!string.IsNullOrEmpty(Ex_Amount.Text))
            {
                Expense expenses = new Expense
                {
                    Amount = Convert.ToDouble(Ex_Amount.Text),
                    Date = Ex_Date.Date,
                    Category = ExCatList.SelectedItem.ToString(),
                    Note = Ex_Note.Text
                };
                if (ExpensesDatabase.SaveExpenses(expenses) != 0)//add expense to Database
                {
                    _expenses.Add(expenses);//add expense to Obseverbale list
                    DisplayAlert("hey", "Expense saved successfully", "great");
                }
            }
            else
             {
                    DisplayAlert("hey", "Please enter an amount", "Ok");//shouldn't be run ever!
             }
                    Clear();
              
         }
          

            

        private void Clear()
        {
            //clear textboxes
            Ex_Amount.Text = "";
            ExCatList.SelectedItem = null;
            Ex_Note.Text = "";
            Ex_Date.Date = DateTime.Now;
        }

        async void _Done_Clicked(object sender, EventArgs e)
        {

            ExpensesList ExpensesList = new ExpensesList
            {
                BindingContext = _expenses
            };
            TabbedPage1 page = new TabbedPage1();


            await Navigation.PushModalAsync(page);
        }
    }
}