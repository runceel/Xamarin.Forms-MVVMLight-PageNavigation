using App3.Mvvm;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App3.ViewModels
{
    public class MainPageViewModel : ViewModelBase, INavigateAwareViewModel
    {
        private INavigationService navigationService;

        public RelayCommand NavigateCommand { get; private set; }

        public MainPageViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;

            this.NavigateCommand = new RelayCommand(this.NavigateExecute);
        }

        private void NavigateExecute()
        {
            this.navigationService.NavigateTo("Next", DateTime.Now);
        }

        public void NavigateTo(object parameter)
        {
            Debug.WriteLine("MainPageViewModel#NavigateFrom");
        }

        public void NavigateFrom()
        {
            Debug.WriteLine("MainPageViewModel#NavigateTo");
        }
    }
}
