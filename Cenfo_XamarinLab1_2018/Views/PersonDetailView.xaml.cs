using System;
using System.Collections.Generic;
using Cenfo_XamarinLab1_2018.Models;
using Xamarin.Forms;

namespace Cenfo_XamarinLab1_2018.Views
{
    public partial class PersonDetailView : ContentPage
    {
        public PersonDetailView()
        {
            InitializeComponent();

            Person person = new Person()
            {
                Id = 1001,
                Address = "Somewhere in the galaxy...",
                CreditLimit=10000,
                Email="darkside4ever@inlook.com",
                Name="Luke",
                LastName="Jones",
                MothersName="Atreides"
            };

            person.Invoices = new List<Invoice>();
            person.Invoices.Add( new Invoice() { Id=10001, Amount=2000, Customer=person, Description="Screen shields", InvoceDate=DateTime.Now } );
            person.Invoices.Add(new Invoice() { Id = 10002, Amount = 2000, Customer = person, Description = "Chargers", InvoceDate = DateTime.Now });
            person.Invoices.Add(new Invoice() { Id = 10003, Amount = 3000, Customer = person, Description = "Cellphone cases", InvoceDate = DateTime.Now });
            person.Invoices.Add(new Invoice() { Id = 10004, Amount = 1600, Customer = person, Description = "Tablet cases", InvoceDate = DateTime.Now });
            person.Invoices.Add(new Invoice() { Id = 10005, Amount = 5540, Customer = person, Description = "Maps", InvoceDate = DateTime.Now });
            person.Invoices.Add(new Invoice() { Id = 10006, Amount = 3890, Customer = person, Description = "Fans", InvoceDate = DateTime.Now });
            person.Invoices.Add(new Invoice() { Id = 10007, Amount = 7003, Customer = person, Description = "Energy Drinks", InvoceDate = DateTime.Now });
            person.Invoices.Add(new Invoice() { Id = 10008, Amount = 2000, Customer = person, Description = "Doritos", InvoceDate = DateTime.Now });
            BindingContext = person;
        }
    }
}
