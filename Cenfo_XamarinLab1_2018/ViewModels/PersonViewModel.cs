using System;
using Cenfo_XamarinLab1_2018.Models;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Cenfo_XamarinLab1_2018.ViewModels
{
    public class PersonViewModel : INotifyPropertyChanged
    {
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

        public PersonViewModel()
        {
            InitClass();
        }

        private async void InitClass()
        {
            PersonsList = await Person.CreatePersonsList();
        }

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
