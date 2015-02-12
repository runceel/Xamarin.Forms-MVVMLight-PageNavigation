using App3.ViewModels;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App3
{
    public static class ViewModelLocator
    {
        public static void Initialize(IUnityContainer c)
        {
            ServiceLocator.SetLocatorProvider(new ServiceLocatorProvider(() => new UnityServiceLocator(c)));
        }

        public static MainPageViewModel MainPageViewModel
        {
            get { return ServiceLocator.Current.GetInstance<MainPageViewModel>(); }
        }

        public static NextPageViewModel NextPageViewModel
        {
            get { return ServiceLocator.Current.GetInstance<NextPageViewModel>(); }
        }
    }
}
