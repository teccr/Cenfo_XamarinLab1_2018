using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Cenfo_XamarinLab1_2018.Views
{
    public partial class MenuView : ContentPage
    {
        public class MenuItem {
            public string Title
            {
                get;
                set;
            }

            public string Description
            {
                get;
                set;
            }
        }

        public List<MenuItem> DataItems
        {
            get;
            set;
        }

        public MenuView()
        {
            InitializeComponent();
            List<MenuItem> menuItems = new List<MenuItem>();
            menuItems.Add(new MenuItem() { Title = "Products", Description="Invoices"});
            menuItems.Add(new MenuItem() { Title = "Test", Description = "Test" });
            menuItems.Add(new MenuItem() { Title = "Test2", Description = "Test3" });
            menuItems.Add(new MenuItem() { Title = "Test4", Description = "test4" });;
            DataItems = menuItems;
            BindingContext = this;
        }
    }
}
