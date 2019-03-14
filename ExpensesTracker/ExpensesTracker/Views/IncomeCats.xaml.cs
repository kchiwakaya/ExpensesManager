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
	public partial class IncomeCats : ContentPage
	{
        private In_CategoryController In_CategoryController;
        private ObservableCollection<IncomeCategories> _IncomeCats = new ObservableCollection<IncomeCategories>();
        public IncomeCats ()
		{
			InitializeComponent ();
            In_CategoryController = new In_CategoryController();
		}

        private void BtnSave_Clicked(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(In_Cat_Name.Text))
            {
                IncomeCategories incomeCategories = new IncomeCategories
                {
                    Name = In_Cat_Name.Text
                };
                if (In_CategoryController.SaveCategory(incomeCategories) != 0)
                {
                    _IncomeCats.Add(incomeCategories);
                    DisplayAlert("Hey", "Category successfully saved", "great");
                }
            }
            else
            {
                DisplayAlert("Hey", "Please enter a category", "Ok");
            }
            Clear();
           
        }
        private void Clear()
        {
            In_Cat_Name.Text = "";
        }

        private void _Done_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

    }
}