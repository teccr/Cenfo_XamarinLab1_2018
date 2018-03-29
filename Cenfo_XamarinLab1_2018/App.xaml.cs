﻿using Cenfo_XamarinLab1_2018.Views;
using Xamarin.Forms;

namespace Cenfo_XamarinLab1_2018
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Master detail view require una forma dfiferente de inicializar la pagina pricipal
            /*
             MainPage = new MasterDetailPage
            {
                Master = new MenuView(),
                Detail = new PersonListView()
            };
            */
            MainPage = new MasterView();
                
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
