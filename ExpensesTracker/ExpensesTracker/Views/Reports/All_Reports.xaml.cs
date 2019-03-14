using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entry = Microcharts.Entry;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SkiaSharp;
using Microcharts;
using ExpensesTracker.ViewModels;

namespace ExpensesTracker.Views.Reports
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class All_Reports : ContentPage
    {
        public All_Reports()
        {
            InitializeComponent();
            ExpensesDatabaseController expenses = new ExpensesDatabaseController();
            IncomeDabataseController income = new IncomeDabataseController();
            List<Entry> entries = new List<Entry>
            {
                 new Entry(Convert.ToSingle(expenses.Total(1,DateTime.Now.Year)))
                 {
                    Color = SKColor.Parse("#FF0000"),
                    Label ="January",
                    ValueLabel =expenses.Total(1,DateTime.Now.Year).ToString()
                },
                  new Entry(Convert.ToSingle(income.Total(1,DateTime.Now.Year)))
                 {
                    Color = SKColor.Parse("#008000"),
                    
                    ValueLabel =income.Total(1,DateTime.Now.Year).ToString()
                },
                new Entry(Convert.ToSingle(expenses.Total(2,DateTime.Now.Year)))
                 {
                    Color = SKColor.Parse("#FF0000"),
                    Label ="February",
                    ValueLabel =expenses.Total(2,DateTime.Now.Year).ToString()
                },
                 new Entry(Convert.ToSingle(income.Total(2,DateTime.Now.Year)))
                 {
                    Color = SKColor.Parse("#008000"),
                    
                    ValueLabel =income.Total(2,DateTime.Now.Year).ToString()
                },
                  new Entry(Convert.ToSingle(expenses.Total(3,DateTime.Now.Year)))
                 {
                    Color = SKColor.Parse("#FF0000"),
                    Label ="March",
                    ValueLabel =expenses.Total(3,DateTime.Now.Year).ToString()
                },
                     new Entry(Convert.ToSingle(income.Total(3,DateTime.Now.Year)))
                 {
                    Color = SKColor.Parse("#008000"),
                    
                    ValueLabel =income.Total(3,DateTime.Now.Year).ToString()
                },
                new Entry(Convert.ToSingle(expenses.Total(4,DateTime.Now.Year)))
                 {
                    Color = SKColor.Parse("#FF0000"),
                    Label ="April",
                    ValueLabel =expenses.Total(4,DateTime.Now.Year).ToString()
                },
                 new Entry(Convert.ToSingle(income.Total(4,DateTime.Now.Year)))
                 {
                    Color = SKColor.Parse("#008000"),
                    
                    ValueLabel =income.Total(4,DateTime.Now.Year).ToString()
                },
                  new Entry(Convert.ToSingle(expenses.Total(5,DateTime.Now.Year)))
                 {
                    Color = SKColor.Parse("#FF0000"),
                    Label ="May",
                    ValueLabel =expenses.Total(5,DateTime.Now.Year).ToString()
                },
                     new Entry(Convert.ToSingle(income.Total(5,DateTime.Now.Year)))
                 {
                    Color = SKColor.Parse("#008000"),
                    
                    ValueLabel =income.Total(5,DateTime.Now.Year).ToString()
                },
                      new Entry(Convert.ToSingle(expenses.Total(6,DateTime.Now.Year)))
                 {
                    Color = SKColor.Parse("#FF0000"),
                    Label ="June",
                    ValueLabel =expenses.Total(6,DateTime.Now.Year).ToString()
                },
                      new Entry(Convert.ToSingle(income.Total(6,DateTime.Now.Year)))
                 {
                    Color = SKColor.Parse("#008000"),
                    
                    ValueLabel =income.Total(6,DateTime.Now.Year).ToString()
                },
               
                 new Entry(Convert.ToSingle(expenses.Total(7,DateTime.Now.Year)))
                 {
                    Color = SKColor.Parse("#FF0000"),
                    Label ="July",
                    ValueLabel =expenses.Total(7,DateTime.Now.Year).ToString()
                },
                  new Entry(Convert.ToSingle(income.Total(7,DateTime.Now.Year)))
                 {
                    Color = SKColor.Parse("#008000"),
                   
                    ValueLabel =income.Total(7,DateTime.Now.Year).ToString()
                },
                 
                  new Entry(Convert.ToSingle(expenses.Total(8,DateTime.Now.Year)))
                 {
                    Color = SKColor.Parse("#FF0000"),
                    Label ="August",
                    ValueLabel =expenses.Total(8,DateTime.Now.Year).ToString()
                },
                new Entry(Convert.ToSingle(income.Total(8,DateTime.Now.Year)))
                 {
                    Color = SKColor.Parse("#008000"),
                    
                    ValueLabel =income.Total(8,DateTime.Now.Year).ToString()
                },
                
                 new Entry(Convert.ToSingle(expenses.Total(9,DateTime.Now.Year)))
                 {
                    Color = SKColor.Parse("#FF0000"),
                    Label ="September",
                    ValueLabel =expenses.Total(9,DateTime.Now.Year).ToString()
                },
                 new Entry(Convert.ToSingle(income.Total(9,DateTime.Now.Year)))
                 {
                    Color = SKColor.Parse("#008000"),
                    
                    ValueLabel =income.Total(9,DateTime.Now.Year).ToString()
                },
                 
                   new Entry(Convert.ToSingle(expenses.Total(10,DateTime.Now.Year)))
                 {
                    Color = SKColor.Parse("#FF0000"),
                    Label ="October",
                    ValueLabel =expenses.Total(10,DateTime.Now.Year).ToString()
                },
                new Entry(Convert.ToSingle(income.Total(10,DateTime.Now.Year)))
                 {
                    Color = SKColor.Parse("#008000"),
                    
                    ValueLabel =income.Total(10,DateTime.Now.Year).ToString()
                },
               
                 new Entry(Convert.ToSingle(expenses.Total(11,DateTime.Now.Year)))
                 {
                    Color = SKColor.Parse("#FF0000"),
                    Label ="November",
                    ValueLabel =expenses.Total(11,DateTime.Now.Year).ToString()
                },
                new Entry(Convert.ToSingle(income.Total(11,DateTime.Now.Year)))
                 {
                    Color = SKColor.Parse("#008000"),
                    
                    ValueLabel =income.Total(11,DateTime.Now.Year).ToString()
                },
                 
                 
                new Entry(Convert.ToSingle(expenses.Total(12,DateTime.Now.Year)))
                 {
                    Color = SKColor.Parse("#FF0000"),
                    Label ="Decemeber",
                    ValueLabel =expenses.Total(12,DateTime.Now.Year).ToString()
                },
                new Entry(Convert.ToSingle(income.Total(12,DateTime.Now.Year)))
                 {
                    Color = SKColor.Parse("#008000"),
                    
                    ValueLabel =income.Total(12,DateTime.Now.Year).ToString()
                }



            };

            //list income
            //List<Entry> entriesIncome = new List<Entry>
            //{
            //     new Entry(Convert.ToSingle(income.Total(1,DateTime.Now.Year)))
            //     {
            //        Color = SKColor.Parse("#228B22"),
            //        Label ="January",
            //        ValueLabel =income.Total(1,DateTime.Now.Year).ToString()
            //    },
            //    new Entry(Convert.ToSingle(income.Total(2,DateTime.Now.Year)))
            //     {
            //        Color = SKColor.Parse("#530023"),
            //        Label ="February",
            //        ValueLabel =income.Total(2,DateTime.Now.Year).ToString()
            //    },
            //      new Entry(Convert.ToSingle(income.Total(3,DateTime.Now.Year)))
            //     {
            //        Color = SKColor.Parse("#f15277"),
            //        Label ="March",
            //        ValueLabel =income.Total(3,DateTime.Now.Year).ToString()
            //    },
            //    new Entry(Convert.ToSingle(income.Total(4,DateTime.Now.Year)))
            //     {
            //        Color = SKColor.Parse("#551a8b"),
            //        Label ="April",
            //        ValueLabel =income.Total(4,DateTime.Now.Year).ToString()
            //    },
            //      new Entry(Convert.ToSingle(income.Total(5,DateTime.Now.Year)))
            //     {
            //        Color = SKColor.Parse("#7face8"),
            //        Label ="May",
            //        ValueLabel =income.Total(5,DateTime.Now.Year).ToString()
            //    },
            //    new Entry(Convert.ToSingle(income.Total(6,DateTime.Now.Year)))
            //     {
            //        Color = SKColor.Parse("#ab82ff"),
            //        Label ="June",
            //        ValueLabel =income.Total(6,DateTime.Now.Year).ToString()
            //    },
            //      new Entry(Convert.ToSingle(income.Total(7,DateTime.Now.Year)))
            //     {
            //        Color = SKColor.Parse("#00cc66"),
            //        Label ="July",
            //        ValueLabel =income.Total(7,DateTime.Now.Year).ToString()
            //    },
            //    new Entry(Convert.ToSingle(income.Total(8,DateTime.Now.Year)))
            //     {
            //        Color = SKColor.Parse("#d01679"),
            //        Label ="August",
            //        ValueLabel =income.Total(8,DateTime.Now.Year).ToString()
            //    },
            //      new Entry(Convert.ToSingle(income.Total(9,DateTime.Now.Year)))
            //     {
            //        Color = SKColor.Parse("#6464b6"),
            //        Label ="September",
            //        ValueLabel =income.Total(9,DateTime.Now.Year).ToString()
            //    },
            //    new Entry(Convert.ToSingle(income.Total(10,DateTime.Now.Year)))
            //     {
            //        Color = SKColor.Parse("#d4e3ff"),
            //        Label ="October",
            //        ValueLabel =income.Total(10,DateTime.Now.Year).ToString()
            //    },
            //      new Entry(Convert.ToSingle(income.Total(11,DateTime.Now.Year)))
            //     {
            //        Color = SKColor.Parse("#f22232"),
            //        Label ="November",
            //        ValueLabel =income.Total(11,DateTime.Now.Year).ToString()
            //    },
            //    new Entry(Convert.ToSingle(income.Total(12,DateTime.Now.Year)))
            //     {
            //        Color = SKColor.Parse("#241707"),
            //        Label ="Decemeber",
            //        ValueLabel =income.Total(12,DateTime.Now.Year).ToString()
            //    },
            //};


            Chart1.Chart = new BarChart { Entries = entries };//from the xaml end
            
        }
    }

}