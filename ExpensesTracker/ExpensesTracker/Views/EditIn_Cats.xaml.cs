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
	public partial class EditIn_Cats : ContentPage
	{
        private In_CategoryController In_CategoryController;
        private ObservableCollection<IncomeCategories> _IncomeCats = new ObservableCollection<IncomeCategories>();
        IncomeCategories IncomeCategories = new IncomeCategories();
        public EditIn_Cats (IncomeCategories incomeCategories)
		{
			InitializeComponent ();
            In_CategoryController = new In_CategoryController();
            BindingContext = incomeCategories;
            IncomeCategories = incomeCategories;

		}
        private void BtnSave_Clicked(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(In_Cat_Name.Text))
            {
                IncomeCategories.Name = In_Cat_Name.Text;

                if (In_CategoryController.SaveCategory(IncomeCategories) != 0)
                {
                    _IncomeCats.Add(IncomeCategories);
                    DisplayAlert("Hey", "Category successfully saved", "great");
                }
               
            }
            else
            {
                DisplayAlert("Hey", "Category not saved contact admin", "great");
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