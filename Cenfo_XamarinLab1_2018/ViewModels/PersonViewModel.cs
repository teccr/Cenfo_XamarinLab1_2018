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
            if(instance != null)
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

        private async void InitClass()
        {
            PersonsList = await Person.CreatePersonsList();
        }

        #region Commands

        private void InitCommands()
        {
            ViewPersonDetailsCommand = new Command<int>(ViewPersonDetails);
        }

        public ICommand ViewPersonDetailsCommand 
        {
            get;
            set;
        }

        private void ViewPersonDetails(int Id)
        {
            CurrentPerson = PersonsList.Where(person => person.Id == Id).FirstOrDefault();
            App.Current.MainPage = new PersonDetailView();
        }

        #endregion

        #region INotifyPropertyChanged Interface Implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if(!string.IsNullOrEmpty(propertyName) && PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}
