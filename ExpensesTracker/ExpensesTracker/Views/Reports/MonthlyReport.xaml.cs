using ExpensesTracker.ViewModels;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entry = Microcharts.Entry;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microcharts;

namespace ExpensesTracker.Views.Reports
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MonthlyReport : ContentPage
    {
        public MonthlyReport()
        {
            InitializeComponent();
            SizeChanged += MonthlyReport_SizeChanged;

            ExpensesDatabaseController expenses = new ExpensesDatabaseController();
            IncomeDabataseController income = new IncomeDabataseController();
            var balance = income.Total(DateTime.Now.Month, DateTime.Now.Year) - expenses.Total(DateTime.Now.Month, DateTime.Now.Year);
            List<Entry> entries = new List<Entry>
            {

                new Entry(Convert.ToSingle(expenses.Total(DateTime.Now.Month,DateTime.Now.Year)))
                 {
                    Color = SKColor.Parse("#dc151c"),
                    Label ="Expenses",
                    ValueLabel =expenses.Total(DateTime.Now.Month,DateTime.Now.Year).ToString()
                },
                new Entry(Convert.ToSingle(income.Total(DateTime.Now.Month,DateTime.Now.Year)))
                 {
                    Color = SKColor.Parse("#228B22"),
                    Label ="Income",
                    ValueLabel =income.Total(DateTime.Now.Month,DateTime.Now.Year).ToString()
                },
                 new Entry(Convert.ToSingle(balance))
                 {
                    Color = SKColor.Parse("#7f93ff"),
                    Label ="Balance",
                    ValueLabel = balance.ToString()
                }

            };
            MonthlyChart.Chart = new DonutChart { Entries = entries };
        }

        private void MonthlyReport_SizeChanged(object sender, EventArgs e)
        {
            if (Width < Height)
            {
                chartLayout.Orientation = StackOrientation.Vertical;
                MonthlyChart.HeightRequest = 300;
                MonthlyChart.WidthRequest = 10;
            }
        }

        private async void BtnYearly(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new All_Reports()));
        }

        private async void btnAll(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new All_Transactions()));
        }
        protected override bool OnBackButtonPressed()
        {
            Navigation.PopModalAsync();
            return true;
        }

    }
}