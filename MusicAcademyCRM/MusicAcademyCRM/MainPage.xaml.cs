using MusicAcademyCRM.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                // authenticate
                bool result = await Auth.LoginUser(EmailEntry.Text, PasswordEntry.Text);

                if(result)
                await Navigation.PushAsync(new HomePage());
           }
        }

        //private async void LoginButton_Clicked(object sender, EventArgs e)
        //{
        //   bool isEmailEmpty = string.IsNullOrEmpty(EmailEntry.Text);
        //   bool isPasswordEmpty = string.IsNullOrEmpty(PasswordEntry.Text);
        //    bool isValidEmail = EmailEntry.Text.Contains("@");
        //    int passwordCharCount = PasswordEntry.Text.Count();
        //    bool isValidPasswordCount;
        //    if (passwordCharCount >= 6)
        //        isValidPasswordCount = true;

        //   if (isEmailEmpty)
        //   {

        //        await App.Current.MainPage.DisplayAlert("Failure", "Please fill in the email address field", "OK");
        //    }else if (isPasswordEmpty)
        //    {
        //        await App.Current.MainPage.DisplayAlert("Failure", "Please fill in the password field", "OK");
        //    }
        //    else if (!isValidEmail)
        //    {
        //        await App.Current.MainPage.DisplayAlert("Failure", "Please use a fully qualified email address(must include @ symbol)", "OK");
        //    }
        //    else if (passwordCharCount < 6)
        //    {
        //        await App.Current.MainPage.DisplayAlert("Failure", "Please make sure your Password is at least 6 characters", "OK");
        //    }
        //    else
        //   {
        //        // authenticate
        //        bool result = await Auth.LoginUser(EmailEntry.Text, PasswordEntry.Text);

        //        if(result)
        //        await Navigation.PushAsync(new HomePage());
        //   }

        private void RegisterUserButton_OnClicked(object sender, EventArgs e)
        {
           
            
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
