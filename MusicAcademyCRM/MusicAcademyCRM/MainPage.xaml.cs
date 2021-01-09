using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using MusicAcademyCRM.Model;
using Xamarin.Forms;

namespace MusicAcademyCRM
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var assembly = typeof(MainPage);

            iconImage.Source = ImageSource.FromResource("MusicAcademyCRM.Assets.Images.pma.jpeg", assembly);
        }

       
        private async void LoginButton_Clicked(object sender, EventArgs e)
        {

            
            bool isEmailEmpty = string.IsNullOrEmpty(EmailEntry.Text);
           bool isPasswordEmpty = string.IsNullOrEmpty(PasswordEntry.Text);

           if (isEmailEmpty || isPasswordEmpty)
           {

           }
           else
           {
               var user = (await App.MobileService.GetTable<Users>().Where(u => u.Email == EmailEntry.Text).ToListAsync()).FirstOrDefault();
               if (user != null)
               {
                   App.user = user;
                   if (user.Password == PasswordEntry.Text)
                   {
                       await Navigation.PushAsync(new HomePage());
                   }
                   else
                   {
                       await DisplayAlert("Error", "Email or Password are incorrect", "Ok");
                   }
               }
               else
               {
                   await DisplayAlert("Error", "There was an error logging you in", "Ok");
               }

               
           }
        }

        private void RegisterUserButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
