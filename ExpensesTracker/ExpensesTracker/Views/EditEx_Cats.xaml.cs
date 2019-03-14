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
	public partial class EditEx_Cats : ContentPage
	{
        public ObservableCollection<ExpensesCategory> Ex_Cats;
        public Ex_CategoryController ex_cat_database = new Ex_CategoryController();
        ExpensesCategory _ExpensesCategory = new ExpensesCategory();
        public EditEx_Cats (ExpensesCategory expensesCategory)
		{
			InitializeComponent ();
            Ex_Cats = new ObservableCollection<ExpensesCategory>();
            _ExpensesCategory = expensesCategory;
            BindingContext = expensesCategory;
		}

        private void BtnSave_Clicked(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(Ex_Cat_Name.Text))
            {
                _ExpensesCategory.Name = Ex_Cat_Name.Text;

                if (ex_cat_database.SaveCategory(_ExpensesCategory) != 0)
                {
                    Ex_Cats.Add(_ExpensesCategory);
                    DisplayAlert("Hey", "Category successfully saved", "Great");
                }
            }
            else
            {
                DisplayAlert("Hey", "Category is empty", "Sorry");
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