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
    public partial class Ex_Cat_List : ContentPage
    {
        Ex_CategoryController Ex_Cat_database;
        ObservableCollection<ExpensesCategory> ExpenseCategories;
        public Ex_Cat_List()
        {
            InitializeComponent();
            Ex_Cat_database = new Ex_CategoryController();
            ExpenseCategories = new ObservableCollection<ExpensesCategory>(Ex_Cat_database.GetCategories());
           
            _Ex_Cats.ItemsSource = ExpenseCategories;
        }
    
            


        private void _Ex_Cats_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            //if (e.Item == null)
            //    return;
            //var exes = e.Item as Income;
            //var answer = await DisplayActionSheet("Delete", "Yes", "No", "Do you want to delete?");
            //if (answer == "Yes")
            //{
            //    _incomes.Remove(exes);
            //    IncomeDatabase.DeleteIncome(exes.Id);
            //    //app.Income_collection.Remove(exes);

            //    //GetIncomes();
            //}
            //else
            //{
            //    return;
            //}
        }

        async void Save_Ex_Cat_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new ExpenseCats()));
        }

        async void _Ex_Cats_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var cat = e.SelectedItem as ExpensesCategory;
            var response = await DisplayActionSheet("Action", "Cancel", "Delete", "Edit");
            
            if (response == "Edit")
            {
                //edit
                await Navigation.PushModalAsync(new NavigationPage(new EditEx_Cats(cat)));
            }
            else if (response == "Delete")
            {

                var answer = await DisplayActionSheet("Delete", "Yes", "No", "Do you want to delete?");
                if (answer == "Yes")
                {
                    ExpenseCategories.Remove(cat);
                    Ex_Cat_database.DeleteCategory(cat.Id);
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