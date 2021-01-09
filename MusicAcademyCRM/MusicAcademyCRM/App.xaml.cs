using System;
using Microsoft.WindowsAzure.MobileServices;
using MusicAcademyCRM.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;

namespace MusicAcademyCRM
{
    public partial class App : Application
    {
        public static string DatabaseLocation = string.Empty;
        public static MobileServiceClient MobileService = 
            new MobileServiceClient(
                "https://musicacademy.azurewebsites.net"
                );

        public static Users user = new Users();

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        

        public App(string databaselocation)
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());

            DatabaseLocation = databaselocation;
        }

       

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

       
    }
}
