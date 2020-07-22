using MyList.Models;
using MyList.Services;
using MyList.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace MyList.ViewModels
{
    public class ItemsViewModel : ViewModelBase
    {
        public DelegateCommand AddNewItemCommand { get; }
        public DelegateCommand<object> ItemTappedCommand { get; }
        public Item Item { get; set; }
        public ObservableCollection<Item> AllItems { get; set; }
        public DelegateCommand LoadItemsCommand { get; set; }
        public Command<Item> DeleteCommand { get; set; }
        public Command<Item> CheckCommand { get; set; }


        public ItemsViewModel(INavigationService navigationService, IDataStore<Item> DataStore)
            : base(navigationService, DataStore)
        {
            AddNewItemCommand = new DelegateCommand(() => NavigationService.NavigateAsync("/NewItem"));
            ItemTappedCommand = new DelegateCommand<object>(ItemTapped);
            AllItems = new ObservableCollection<Item>();
            LoadItemsCommand = new DelegateCommand(async () => await ExecuteLoadItemsCommand(DataStore));
            LoadItemsCommand.Execute();

            DeleteCommand = new Command<Item>(async (f) =>
            {
                var item = f as Item;
                if (item == null)
                {
                    return;
                }
                _ = await DataStore.DeleteItemAsync(item);
                _ = await NavigationService.NavigateAsync("Items");
            });

            CheckCommand = new Command<Item>(async (f) =>
            {
                var item = f as Item;
                if (item == null)
                {
                    return;
                }
                item.Done = !item.Done;
                _ = await DataStore.SaveItemAsync(item);
                _ = await NavigationService.NavigateAsync("Items");
            });
        }

        async private void ItemTapped(object obj)
        {
            var item = obj as Item;
            if (item == null)
            {
                return;
            }
            var parameters = new NavigationParameters();
            parameters.Add("item", item);
            await NavigationService.NavigateAsync("/NewItem", parameters);
        }

        async Task ExecuteLoadItemsCommand(IDataStore<Item> DataStore)
        {
            try
            {
                AllItems.Clear();
                List<Item> items = await DataStore.GetItemsAsync();
                foreach (var item in items)
                {
                    AllItems.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
            }
        }


        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            _itemsNewItem = parameters.GetValue<string>("newItem");
        }
        private string _itemsNewItem;
    }
}
