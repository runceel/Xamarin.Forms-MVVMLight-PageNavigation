using App3.Mvvm;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App3.ViewModels
{
    public class NextPageViewModel : ViewModelBase, INavigateAwareViewModel
    {
        private string message;

        public string Message
        {
            get { return this.message; }
            set { this.Set(ref this.message, value); }
        }


        public void NavigateTo(object parameter)
        {
            this.Message = parameter.ToString();
        }

        public void NavigateFrom()
        {
        }
    }
}
