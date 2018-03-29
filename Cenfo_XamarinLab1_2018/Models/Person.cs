using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Cenfo_XamarinLab1_2018.Models
{
    public class Person
    {

        public int Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public string MothersName
        {
            get;
            set;
        }

        public DateTime BirthDate
        {
            get;
            set;
        }

        public string PhoneNumber
        {
            get;
            set;
        }

        public ObservableCollection<Invoice> Invoices
        {
            get;
            set;
        }

        public string ProfilePicture
        {
            get;
            set;
        }

        public string Address
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public decimal CreditLimit
        {
            get;
            set;
        }

        public static Task<ObservableCollection<Person>> CreatePersonsList()
        {
            Task<ObservableCollection<Person>> peopleTask = new Task<ObservableCollection<Person>>(() =>
            {
                ObservableCollection<Invoice> invoices = new ObservableCollection<Invoice>();
                invoices.Add( new Invoice() {  Amount=1000, Description="Cellphone cases" } );
                invoices.Add(new Invoice() { Amount = 4000, Description = "Pillows" });
                invoices.Add(new Invoice() { Amount = 2500, Description = "Screen shields" });
                invoices.Add(new Invoice() { Amount = 3800, Description = "Batteries" });
                invoices.Add(new Invoice() { Amount = 2000, Description = "Snacks" });

                ObservableCollection<Person> result = new ObservableCollection<Person>();

                result.Add(new Person() { Id=1001, Name = "Juan", LastName = "Perez", MothersName = "Rodriguez", PhoneNumber = "33897541", Invoices=invoices });
                result.Add(new Person() { Id = 1002, Name = "Ramon", LastName = "Alfonso", MothersName = "Alvarado", PhoneNumber = "45237892", Invoices = new ObservableCollection<Invoice>() });
                result.Add(new Person() { Id = 1003, Name = "Fulanito", LastName = "Herrera", MothersName = "Hernandez", PhoneNumber = "83499871", Invoices = new ObservableCollection<Invoice>() });
                result.Add(new Person() { Id = 1004, Name = "Mengano", LastName = "Torres", MothersName = "Fonseca", PhoneNumber = "", Invoices = new ObservableCollection<Invoice>() });
                result.Add(new Person() { Id = 1005, Name = "Sultano", LastName = "Alvarado", MothersName = "Rodriguez", PhoneNumber = "", Invoices = new ObservableCollection<Invoice>() });
                result.Add(new Person() { Id = 1006, Name = "Pepe", LastName = "Rivera", MothersName = "Obando", PhoneNumber = "", Invoices = new ObservableCollection<Invoice>() });
                result.Add(new Person() { Id = 1007, Name = "Omar", LastName = "Bonaparte", MothersName = "Loria", PhoneNumber = "", Invoices = new ObservableCollection<Invoice>() });
                result.Add(new Person() { Id = 1008, Name = "Rosarito", LastName = "Gonzales", MothersName = "Blanco", PhoneNumber = "", Invoices = new ObservableCollection<Invoice>() });
                result.Add(new Person() { Id = 1009, Name = "Lucerito", LastName = "Chacon", MothersName = "Bonaparte", PhoneNumber = "", Invoices = new ObservableCollection<Invoice>() });
                result.Add(new Person() { Id = 10010, Name = "Danny", LastName = "Damasco", MothersName = "Valerio", PhoneNumber = "", Invoices = new ObservableCollection<Invoice>() });

                Thread.Sleep(4000);

                return result;
            });

            peopleTask.Start();
            return peopleTask;
        }
    }
}
