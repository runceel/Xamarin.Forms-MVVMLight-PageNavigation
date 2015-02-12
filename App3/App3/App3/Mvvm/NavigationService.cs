using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App3.Mvvm
{
    public class NavigationService : INavigationService
    {
        private readonly NavigationPage navigationPage;
        private readonly string pageNameTemplate;

        public NavigationService(NavigationPage page, string pageNameTemplate)
        {
            this.navigationPage = page;
            this.pageNameTemplate = pageNameTemplate;
        }

        public string CurrentPageKey
        {
            get { return this.navigationPage.CurrentPage.GetType().Name; }
        }

        public void GoBack()
        {
            this.navigationPage.Navigation.PopAsync();
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            if (this.navigationPage.CurrentPage != null)
            {
                var prevVM = this.navigationPage.CurrentPage.BindingContext as INavigateAwareViewModel;
                if (prevVM != null)
                {
                    prevVM.NavigateFrom();
                }
            }

            var typeName = string.Format(this.pageNameTemplate, pageKey);
            var pageType = Type.GetType(typeName);
            var page = Activator.CreateInstance(pageType) as Page;

            var nextVM = page.BindingContext as INavigateAwareViewModel;
            if (nextVM != null)
            {
                nextVM.NavigateTo(parameter);
            }

            this.navigationPage.Navigation.PushAsync(page);
        }

        public void NavigateTo(string pageKey)
        {
            this.NavigateTo(pageKey, null);
        }
    }
}
