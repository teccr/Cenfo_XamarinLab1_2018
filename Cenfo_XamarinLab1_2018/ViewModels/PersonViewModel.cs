using Cenfo_XamarinLab1_2018.Models;
using System.ComponentModel;
using System.Linq;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using Cenfo_XamarinLab1_2018.Views;

namespace Cenfo_XamarinLab1_2018.ViewModels
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        #region Singleton Definition

        private static PersonViewModel instance = null;

        public static PersonViewModel GetInstance()
        {
            if (instance == null)
            {

                instance = new PersonViewModel();
            }

            return instance;
        }

        public static void DeleteInstance()
        {
            if (instance != null)
            {
                instance = null;
            }
        }

        public PersonViewModel()
        {
            InitClass();
            InitCommands();
        }

        #endregion

        private ObservableCollection<Person> _personsList;
        public ObservableCollection<Person> PersonsList
        {
            get
            {
                return _personsList;
            }
            set
            {
                _personsList = value;
                OnPropertyChanged("PersonsList");
            }
        }

        private Person _currentPerson;
        public Person CurrentPerson
        {
            get
            {
                return _currentPerson;
            }
            set
            {
                _currentPerson = value;
                OnPropertyChanged("CurrentPerson");
            }
        }

        public Invoice CurrentInvoice
        {
            get;
            set;
        }

        private async void InitClass()
        {
            PersonsList = await Person.CreatePersonsList();
        }

        #region Commands

        private void InitCommands()
        {
            ViewPersonDetailsCommand = new Command<int>(ViewPersonDetails);
            AddInvoiceCommand = new Command(AddInvoiceToCurrentPerson);
            SaveInvoiceToCurrentPersonCommand = new Command(SaveInvoiceToCurrentPerson);
            StartEditInvoiceCommand = new Command<int>(StartEditInvoice);
            SaveEditInvoiceCommand = new Command(SaveEditInvoice);
            DeleteInvoiceCommand = new Command<int>(DeleteInvoice);
        }

        public ICommand ViewPersonDetailsCommand
        {
            get;
            set;
        }

        private void ViewPersonDetails(int Id)
        {
            CurrentPerson = PersonsList.Where(person => person.Id == Id).FirstOrDefault();
            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new PersonDetailView());
        }

        public ICommand AddInvoiceCommand
        {
            get;
            set;
        }

        private void AddInvoiceToCurrentPerson()
        {
            CurrentInvoice = new Invoice();
            System.Random random = new System.Random();
            CurrentInvoice.Id = random.Next(100001, 10000000);
            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync(new InvoiceCreateView());
        }

        public ICommand SaveInvoiceToCurrentPersonCommand
        {
            get;
            set;
        }

        private void SaveInvoiceToCurrentPerson()
        {
            CurrentPerson.Invoices.Add(CurrentInvoice);
            CurrentInvoice = null;
            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PopAsync();
        }

        public ICommand StartEditInvoiceCommand
        {
            get;
            set;
        }

        private void StartEditInvoice(int Id)
        {
            CurrentInvoice = CurrentPerson.Invoices.Where(
                invoice => invoice.Id == Id).FirstOrDefault().Duplicate();
            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PushAsync
                                                    (new InvoiceEditView());
        }

        private void SaveEditInvoice()
        {
            int invoicePosition = CurrentPerson.Invoices.IndexOf(CurrentPerson.Invoices.Where(
                invoice => invoice.Id == CurrentInvoice.Id).FirstOrDefault());
            CurrentPerson.Invoices[invoicePosition] = CurrentInvoice;
            CurrentInvoice = null;
            ((MasterDetailPage)App.Current.MainPage).Detail.Navigation.PopAsync();
        }

        public ICommand SaveEditInvoiceCommand
        {
            get;
            set;
        }

        private async void DeleteInvoice(int Id)
        {
            var continueDeletion = await ((MasterDetailPage)App.Current.MainPage).Detail.DisplayAlert(
                "Delete invoice", "Do you want to delete the invoice?", "Yes", "No");
            if (!continueDeletion) return;
            CurrentInvoice = CurrentPerson.Invoices.Where(invoice => invoice.Id == Id).FirstOrDefault();
            CurrentPerson.Invoices.Remove(CurrentInvoice);
            CurrentInvoice = null;
        }

        public ICommand DeleteInvoiceCommand
        {
            get;
            set;
        }

        #endregion

        #region INotifyPropertyChanged Interface Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (!string.IsNullOrEmpty(propertyName) && PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
