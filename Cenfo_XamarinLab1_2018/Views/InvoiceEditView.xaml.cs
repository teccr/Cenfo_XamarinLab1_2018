using System;
using System.Collections.Generic;
using Cenfo_XamarinLab1_2018.ViewModels;

using Xamarin.Forms;

namespace Cenfo_XamarinLab1_2018.Views
{
    public partial class InvoiceEditView : ContentPage
    {
        public InvoiceEditView()
        {
            InitializeComponent();

            BindingContext = PersonViewModel.GetInstance();
        }
    }
}
