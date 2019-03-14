using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ExpensesTracker.Views.Reports;

namespace ExpensesTracker.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedPage1 : TabbedPage
    {
        public TabbedPage1 ()
        {
            InitializeComponent();
            this.SizeChanged += TabbedPage1_SizeChanged;
        }

        private async void TabbedPage1_SizeChanged(object sender, EventArgs e)
        {
            if (Width > Height)
            {
                await Navigation.PushModalAsync(new NavigationPage(new MonthlyReport()));
            }
           


        }
       
    }
}