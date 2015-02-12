using App3.Mvvm;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace App3
{
    public class App : Application
    {
        public App()
        {
            var np = new NavigationPage();

            var c = new UnityContainer();
            var ns = new NavigationService(np, "App3.Views.{0}Page");
            c.RegisterInstance<INavigationService>(ns);
            ViewModelLocator.Initialize(c);
            ns.NavigateTo("Main");
            this.MainPage = np;
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
