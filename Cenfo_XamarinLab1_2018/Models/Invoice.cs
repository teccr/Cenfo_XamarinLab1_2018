using System;
using System.ComponentModel;

namespace Cenfo_XamarinLab1_2018.Models
{
    public class Invoice : INotifyPropertyChanged
    {
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

        private string _description = String.Empty;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        private int _id;
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        private DateTime _invoiceDate;
        public DateTime InvoceDate
        {
            get
            {
                return _invoiceDate;
            }
            set
            {
                _invoiceDate = value;
                OnPropertyChanged("InvoiceDate");
            }
        }

        private double _amount;
        public double Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
                OnPropertyChanged("Amount");
            }
        }

        private string _invoiceType = String.Empty;
        public string InvoiceType
        {
            get;
            set;
        }

        public Person Customer
        {
            get;
            set;
        }

        public void CopyFromInvoice(Invoice invoice)
        {
            this.Id = invoice.Id;
            this.Description = invoice.Description;
            this.Amount = invoice.Amount;
            this.InvoiceType = invoice.InvoiceType;
        }

        public Invoice Duplicate()
        {
            return new Invoice()
            {
                Amount = this.Amount,
                Customer = this.Customer,
                Description = this.Description,
                Id = this.Id,
                InvoceDate = this.InvoceDate,
                InvoiceType = this.InvoiceType
            };
        }
    }
}