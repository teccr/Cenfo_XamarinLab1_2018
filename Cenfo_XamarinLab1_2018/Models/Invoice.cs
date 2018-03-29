using System;

namespace Cenfo_XamarinLab1_2018.Models
{
    public class Invoice
    {
        public string Description
        {
            get;
            set;
        }

        public int Id
        {
            get;
            set;
        }

        public DateTime InvoceDate
        {
            get;
            set;
        }

        public double Amount
        {
            get;
            set;
        }

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
    }
}