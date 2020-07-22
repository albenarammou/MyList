using MyList.Models;
using MyList.Services;
using MyList.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyList.ViewModels
{
    public class NewItemViewModel : ViewModelBase
    {
        public DelegateCommand CancelSelectedCommand { get; }
        public DelegateCommand SaveSelectedCommand { get; }


        private IPageDialogService _dialogService;

        public DelegateCommand DeleteSelectedCommand { get; }
        public Item NewShoppingItem { get; set; }
        //private Item _newShoppingItem;
        //public Item? NewShoppingItem

        private string _newShoppingItemDescr;

        public string NewShoppingItemDescr
        {
            get { return _newShoppingItemDescr; }
            set { SetProperty(ref _newShoppingItemDescr, value); }
        }

        public NewItemViewModel(INavigationService navigationService, IDataStore<Item> DataStore, IPageDialogService dialogService)
            : base(navigationService, DataStore)
        {
            CancelSelectedCommand = new DelegateCommand(CancelSelected, CanSave);
            async void CancelSelected()
            {
                _ = await NavigationService.NavigateAsync("/Items");
            }

            SaveSelectedCommand = new DelegateCommand(SaveSelected, CanSave);
            NewShoppingItem = new Item() { ItemDescr = _newShoppingItemDescr, ItemType = "" };
            async void SaveSelected()
            {
                NewShoppingItem.ItemDescr = _newShoppingItemDescr;
                _ = await DataStore.SaveItemAsync(NewShoppingItem);
                _ = await NavigationService.NavigateAsync("/Items");
            }

            _dialogService = dialogService;
            DeleteSelectedCommand = new DelegateCommand(DeleteSelected, CanSave);
            async void DeleteSelected()
            {
                //var answer = _dialogService.DisplayAlertAsync("Alert", "Are you sure you want to delete the item?", "Yes", "No");
                _ = await DataStore.DeleteItemAsync(NewShoppingItem);
                _ = await NavigationService.NavigateAsync("/Items");
            }
            bool CanSave()
            {
                return true;
            }
        }
        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            if (!(parameters["item"] == null))
            {
                NewShoppingItem = parameters["item"] as Item;
                NewShoppingItemDescr = NewShoppingItem.ItemDescr;
            }
        }
        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            parameters.Add("newItem", NewShoppingItem.ToString());
        }

    }
}
