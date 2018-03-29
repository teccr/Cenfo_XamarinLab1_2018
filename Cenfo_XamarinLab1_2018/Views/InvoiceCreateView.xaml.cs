using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Cenfo_XamarinLab1_2018.ViewModels;

namespace Cenfo_XamarinLab1_2018.Views
{
    public partial class InvoiceCreateView : ContentPage
    {
        public InvoiceCreateView()
        {
            InitializeComponent();

            BindingContext = PersonViewModel.GetInstance();
        }
    }
}
