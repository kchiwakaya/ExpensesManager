using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ExpensesTracker.ViewModels;
using ExpensesTracker.Models;
using System.Collections.ObjectModel;

namespace ExpensesTracker.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IncomeList : ContentPage
	{
        IncomeDabataseController IncomeDatabase;
        private double Total = 0;
        
        private List<Income> IncomesList = new List<Income>();
        ObservableCollection<Income> _incomes ;
        public IncomeList ()
		{
			InitializeComponent ();
            IncomeDatabase = new IncomeDabataseController();
            if(IncomeDatabase.GetIncomes() != null)
            {
                _incomes = new ObservableCollection<Income>(IncomeDatabase.GetIncomes());
            }
           
            _IncomeList.ItemsSource = _incomes;
           // GetIncomes();//display incomes
        }
       
       

        async void AddIncome_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new AddIncome()));
        }
        private void GetIncomes()
        {
            //IncomesList = IncomeDatabase.GetIncomes().ToList();
            ObservableCollection<Income> app = new ObservableCollection<Income>(IncomesList);
            _IncomeList.ItemsSource = app;// IncomeDatabase.GetIncomes();
            foreach (var item in IncomeDatabase.GetIncomes())
            {
                Total += item.Amount;
            }
            Tot.Text = "Total Expense       " + Total.ToString();
            Total = 0;//reset total since it's always calculated about

        }

        private void _Inc_Cats_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

      async void _IncomeList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var income = e.SelectedItem as Income;
            var response = await DisplayActionSheet("Action", "Cancel", "Delete", "Edit", "View");
            if(response == "View")
            {
                
                await Navigation.PushModalAsync(new NavigationPage(new IncomeDetails() { BindingContext = income }));
            }
            else if(response=="Edit")
            {
                await Navigation.PushModalAsync(new NavigationPage(new EditIncome(income)));
            }
            else if (response == "Delete")
            {

                var answer = await DisplayActionSheet("Delete", "Yes", "No", "Do you want to delete?");
                if (answer == "Yes")
                {
                    _incomes.Remove(income);
                    IncomeDatabase.DeleteIncome(income.Id);
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