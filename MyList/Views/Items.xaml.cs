using MyList.Models;
using MyList.ViewModels;
using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;
[assembly: ExportFont("fa-solid-900.ttf")]
namespace MyList.Views
{
    public partial class Items : ContentPage
    {
        public ItemsViewModel ViewModel => (ItemsViewModel)BindingContext;
        public Items()
        {
            InitializeComponent();
        }

        //private void OnTapped(object sender, EventArgs e) 
        //{
        //    var a = sender.ToString();
        //}

        //async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //if (e.Item == null)
        //    return;
        //string result = await DisplayPromptAsync("Change Item", "Do you want to change this item?", "OK", "Cancel", null, -1, null, (((ListView)sender).SelectedItem as Item).ItemDescr);
        //if (!String.IsNullOrWhiteSpace(result))
        //{
        //    Item myItem = new Item { ItemId = (((ListView)sender).SelectedItem as Item).ItemId, ItemDescr = result, ItemType = (((ListView)sender).SelectedItem as Item).ItemType, Done = !(((ListView)sender).SelectedItem as Item).Done };
        //    ((ListView)sender).SelectedItem = myItem;

        //    //startShoppings[e.ItemIndex].ItemDescr = result;
        //    //((ListView)sender).SelectedItem = result;
        //}
        //Deselect Item
        //((ListView)sender).SelectedItem = null;
        //}
    }
}
