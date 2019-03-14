using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ExpensesTracker.Models;
using ExpensesTracker.ViewModels;
using System.Collections.ObjectModel;

namespace ExpensesTracker.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditIncome : ContentPage
	{
        public ObservableCollection<IncomeCategories> In_Cats;
        public In_CategoryController in_cat_database = new In_CategoryController();
        public string Cat;
        IncomeDabataseController IncomesDatabase = new IncomeDabataseController();
        ObservableCollection<Income> _incomes = new ObservableCollection<Income>();
        public Income Inc = new Income();
        public EditIncome(Income income)
        {
            InitializeComponent();

            In_Cats = new ObservableCollection<IncomeCategories>(in_cat_database.GetCategories());
            Inc = income;
            BindingContext = income;
            pickerCatsIn.ItemsSource = In_Cats;


            //finding the saved item from categories(workaround)
            int c = 0;
            foreach (var item in In_Cats)
            {
                if (item.Name == income.Category)//where the saved category is the same as on the picker
                {
                    pickerCatsIn.SelectedIndex = c; //get the index and select the item on the picker
                }
                c++; //increase counter on the list
            }
        }

        private void BtnSave_Clicked(object sender, EventArgs e)
        {
          if(string.IsNullOrEmpty(In_Amount.Text))
            {

                Inc.Amount = Convert.ToDouble(In_Amount.Text);
                Inc.Date = In_Date.Date;
                Inc.Note = In_Note.Text;
                Inc.Category = Cat;


                if (IncomesDatabase.SaveIncome(Inc) != 0)// update income to Database
                {
                    _incomes.Add(Inc);//add Income to Obseverbale list
                    DisplayAlert("hey", "Expense saved successfully", "great");
                }
            }

            else
             {
                 DisplayAlert("hey", "Please enter amount", "Ok");//shouldn't be run ever!
             }
                    Clear();       
               
         
        }
        private void Clear()
        {
            //clear textboxes
            In_Amount.Text = "";
            In_Note.Text = "";
            In_Date.Date = DateTime.Now;
            pickerCatsIn.SelectedIndex = 0;
            // pickerCatsIn.SelectedItem = pickerCatsIn.Title;
            //pickerCatsIn.SelectedItem = "Select Category";
        }

        async void _Done_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void GetSelect(object sender, EventArgs e)
        {
            Cat = pickerCatsIn.Items[pickerCatsIn.SelectedIndex];
        }

       
    }
}
