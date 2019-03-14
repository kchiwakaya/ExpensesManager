using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ExpensesTracker.ViewModels;
using System.Timers;
using ExpensesTracker.Views.Reports;

namespace ExpensesTracker.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Home : ContentPage
	{
        //all calculations must occur in real time
        //one way is to let every page notify this class that stuff from their side has changed
        IncomeDabataseController IncomeDatabase;
        ExpensesDatabaseController ExpensesDatabase;
        Timer t = new Timer();
        private double Income_Total = 0;
        private double Expense_Total = 0;
        private double Balance = 0;
        public DateTime today;
        public Home ()
		{
			InitializeComponent ();
            IncomeDatabase = new IncomeDabataseController();
            ExpensesDatabase = new ExpensesDatabaseController();
            GetEverything();
            today = DateTime.Today;

            string _month = "";
            //workaround
            if (today.Date.Month == 1)
            {
                _month = "January";
            }
            else if (today.Date.Month == 2)
            {
                _month = "February";
            }
            else if (today.Date.Month == 3)
            {
                _month = "March";
            }
            else if (today.Date.Month == 4)
            {
                _month = "April";
            }
            else if (today.Date.Month == 5)
            {
                _month = "May";
            }
            else if (today.Date.Month == 6)
            {
                _month = "June";
            }
            else if (today.Date.Month == 7)
            {
                _month = "July";
            }
            else if (today.Date.Month == 8)
            {
                _month = "August";
            }
            else if (today.Date.Month == 9)
            {
                _month = "September";
            }
            else if (today.Date.Month == 10)
            {
                _month = "October";
            }
            else if (today.Date.Month == 11)
            {
                _month = "November";
            }
            else if (today.Date.Month == 12)
            {
                _month = "December";
            }
            month.Text = _month + " " + today.Date.Year.ToString();
            Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            {
                GetEverything();//totals recalculated every 5 seconds just to give an impression of real time calculations
                //the ideal is to have processing done after any change in the calculated figures...I'm too tired for that!

                return true; // True = Repeat again, False = Stop the timer
            });

        }


        private void Add_Expense_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new AddExpense()));
        }

        private void Add_Income_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new AddIncome()));
        }
        private void GetEverything()
        {
           

                foreach (var item in IncomeDatabase.GetIncomes())
                {
                    Income_Total += item.Amount;
                }
                Inc_Total.Text = Income_Total.ToString();



                foreach (var item in ExpensesDatabase.GetExpenses())
                {
                    Expense_Total += item.Amount;

                }
                Ex_Total.Text = Expense_Total.ToString();

                Balance = Income_Total - Expense_Total;
                if (Balance > 0)
                {
                    Total_Balance.Text = Balance.ToString();
                    Total_Balance.TextColor = Color.Green;
                }
                else
                {
                    Total_Balance.Text = Balance.ToString();
                    Total_Balance.TextColor = Color.Red;
                }
          
                Income_Total = 0;//reset total since it's always calculated about
                Expense_Total = 0;
            
            
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new All_Reports()));
        }
    }
}