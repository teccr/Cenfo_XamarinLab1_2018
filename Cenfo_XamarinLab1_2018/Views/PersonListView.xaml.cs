using Cenfo_XamarinLab1_2018.ViewModels;
using Xamarin.Forms;

namespace Cenfo_XamarinLab1_2018.Views
{
    public partial class PersonListView : ContentPage
    {
        public PersonListView()
        {
            InitializeComponent();

            // Data context
            BindingContext = new PersonViewModel();
        }
    }
}
