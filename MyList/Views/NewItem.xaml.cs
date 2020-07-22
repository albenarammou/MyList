using System;
using Xamarin.Forms;

namespace MyList.Views
{
    public partial class NewItem : ContentPage
    {
        public NewItem()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            NewItemEntry.Focus();
        }

        private void Entry_Completed(object sender, EventArgs e)
        {
            Entry entry = (Entry)sender;
            if (!String.IsNullOrWhiteSpace(entry.Text))
            { /*startShoppings.Add(entry.Text); */};
        }
        
    }
}
