using MyList.Models;
using MyList.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyList.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService, IDataStore<Item> DataStore)
            : base(navigationService, DataStore)
        {
            Title = "Main Page";
        }
    }
}
