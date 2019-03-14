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
	public partial class ExpenseCats : ContentPage
	{
        ObservableCollection<ExpensesCategory> expensesCategories = new ObservableCollection<ExpensesCategory>();
        Ex_CategoryController _ex_cat_database;
        public ExpenseCats ()
		{
			InitializeComponent ();
            _ex_cat_database = new Ex_CategoryController();
		}

        private void BtnSave_Clicked(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(Ex_Cat_Name.Text))
            {
                ExpensesCategory expensesCategory = new ExpensesCategory
                {
                    Name = Ex_Cat_Name.Text
                };
                if (_ex_cat_database.SaveCategory(expensesCategory) != 0)
                {
                    expensesCategories.Add(expensesCategory);
                    DisplayAlert("Hey", "Category successfully saved", "Great");
                }
            }
            else
            {
                DisplayAlert("Hey", "Please enter a Category", "Ok");
            }
            Clear();
            
        }
        private void Clear()
        {
            Ex_Cat_Name.Text = "";
        }
        private void _Done_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}