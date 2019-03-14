using ExpensesTracker.Models;
using ExpensesTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditExpenses : ContentPage
    {
        public ObservableCollection<ExpensesCategory> Ex_Cats;
        public Ex_CategoryController ex_cat_database = new Ex_CategoryController();
        public string Cat;
        public ExpensesDatabaseController ExpensesDatabase = new ExpensesDatabaseController();
        ObservableCollection<Expense> _expenses = new ObservableCollection<Expense>();
        public Expense Exp = new Expense();
        public EditExpenses(Expense expense)
        {
            InitializeComponent();
            Ex_Cats = new ObservableCollection<ExpensesCategory>(ex_cat_database.GetCategories());
            Exp = expense;
            BindingContext = expense;
            pickerCatsEx.ItemsSource = Ex_Cats;
            //finding the saved item from categories(workaround)
            int c = 0;
            foreach (var item in Ex_Cats)
            {
                if (item.Name == expense.Category)//where the saved category is the same as on the picker
                {
                    pickerCatsEx.SelectedIndex = c; //get the index and select the item on the picker
                }
                c++; //increase counter on the list
            }

        }

        private void BtnSave_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Ex_Amount.Text))
            {
                Exp.Amount = Convert.ToDouble(Ex_Amount.Text);
                Exp.Date = Ex_Date.Date;
                Exp.Note = Ex_Note.Text;
                Exp.Category = Cat;


                if (ExpensesDatabase.SaveExpenses(Exp) != 0)//add expense to Database
                {
                    _expenses.Add(Exp);//add expense to Obseverbale list
                    DisplayAlert("hey", "Expense saved successfully", "great");
                }
            }
            else
            {
                DisplayAlert("hey", "Please enter the amount", "Ok");//shouldn't be run ever!
            }

        }
    
        
        private void Clear()
        {
            //clear textboxes
            Ex_Amount.Text = "";
            Ex_Note.Text = "";
            Ex_Date.Date = DateTime.Now;
            pickerCatsEx.SelectedIndex = 0;
        }

        async void _Done_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        public void GetSelect(object sender, EventArgs e)
        {
            Cat = pickerCatsEx.Items[pickerCatsEx.SelectedIndex];
            //  Cat = pickerCatsEx.Items[pickerCatsEx.SelectedIndex];
        }
    }
}
