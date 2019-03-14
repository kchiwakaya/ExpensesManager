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
	public partial class AddIncome : ContentPage
	{
        private IncomeDabataseController IncomeDabatase;
        private In_CategoryController in_CategoryController = new In_CategoryController();
        // private HelperIncome app;
        ObservableCollection<Income> _incomes = new ObservableCollection<Income>();
        ObservableCollection<IncomeCategories> IncomeCategories;
        public AddIncome ()
		{
			InitializeComponent ();
            IncomeDabatase = new IncomeDabataseController();
            IncomeCategories = new ObservableCollection<IncomeCategories>(in_CategoryController.GetCategories());
            List<string> cats = new List<string>();
            foreach (var item in IncomeCategories)
            {
                cats.Add(item.Name);
            }
            CatList.ItemsSource = cats;
		}

        private void BtnSave_Clicked(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(In_Amount.Text))
            {
                Income income = new Income
                {
                    Amount = Convert.ToDouble(In_Amount.Text),
                    Category = CatList.SelectedItem.ToString(),
                    Note = In_Note.Text,
                    Date = In_Date.Date


                };
                if (IncomeDabatase.SaveIncome(income) != 0)
                {
                    _incomes.Add(income);

                    DisplayAlert("hey", "Income saved successfully", "great");
                }
            }
            else
            {
                DisplayAlert("hey", "Please enter the amount", "Ok");
            }
            

           
        }
        private void Clear()
        {
            //clear textboxes
            In_Amount.Text = "";
            CatList.SelectedItem = null;
            In_Note.Text = "";
            In_Date.Date = DateTime.Now;
        }

        async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            
            IncomeList incomeList = new IncomeList
            {
                BindingContext = _incomes
            };
            TabbedPage1 page = new TabbedPage1();

         
            await Navigation.PushModalAsync(page);
        }

      
    }
}