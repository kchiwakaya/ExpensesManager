using ExpensesTracker.Models;
using ExpensesTracker.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExpensesTracker.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class In_Cat_List : ContentPage
	{
        In_CategoryController In_Cat_database;
        ObservableCollection<IncomeCategories> incomeCategories;
        public In_Cat_List ()
		{
			InitializeComponent ();
            In_Cat_database = new In_CategoryController();
            if (In_Cat_database.GetCategories() != null)
            {
                incomeCategories = new ObservableCollection<IncomeCategories>(In_Cat_database.GetCategories());
            }
            else
            {
                //Insert primary data
                IncomeCategories _incomeCategories = new IncomeCategories()
                {
                    Name = "Salary"
                };
                IncomeCategories _incomeCategories1 = new IncomeCategories()
                {
                    Name = "Business"
                };
                incomeCategories = new ObservableCollection<IncomeCategories>();
                incomeCategories.Add(_incomeCategories);
                incomeCategories.Add(_incomeCategories1);
            }
            _Inc_Cats.ItemsSource = incomeCategories;

        }


        async void Save_In_Cat_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new IncomeCats()));
        }

        async void _Inc_Cats_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var cat = e.SelectedItem as IncomeCategories;
            var response = await DisplayActionSheet("Action", "Cancel", "Delete", "Edit");
           if (response == "Edit")
            {
                //edit
                await Navigation.PushModalAsync(new NavigationPage(new EditIn_Cats(cat)));
            }
            else if (response == "Delete")
            {

                var answer = await DisplayActionSheet("Delete", "Yes", "No", "Do you want to delete?");
                if (answer == "Yes")
                {
                    incomeCategories.Remove(cat);
                    In_Cat_database.DeleteCategory(cat.Id);
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