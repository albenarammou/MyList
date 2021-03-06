﻿using Prism;
using Prism.Ioc;
using MyList.ViewModels;
using MyList.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyList.Services;
using MyList.Models;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MyList
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            //await NavigationService.NavigateAsync("NavigationPage/MainPage");
            await NavigationService.NavigateAsync("Items");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance<IDataStore<Item>>(new DbDataStore());
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<Items, ItemsViewModel>();
            containerRegistry.RegisterForNavigation<NewItem, NewItemViewModel>();
        }
    }
}
