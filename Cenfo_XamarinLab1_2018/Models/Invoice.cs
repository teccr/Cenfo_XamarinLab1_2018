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