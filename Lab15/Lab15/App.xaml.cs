using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Lab15.Models;
using Lab15.Views;
using Lab15.Services;

namespace Lab15
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new ShowProducto());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
