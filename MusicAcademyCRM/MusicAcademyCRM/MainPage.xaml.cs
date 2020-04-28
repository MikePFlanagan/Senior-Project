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

       
        private void LoginButton_Clicked(object sender, EventArgs e)
        {
           bool isEmailEmpty = string.IsNullOrEmpty(EmailEntry.Text);
           bool isPasswordEmpty = string.IsNullOrEmpty(PasswordEntry.Text);

           if (isEmailEmpty || isPasswordEmpty)
           {

           }
           else
           {
               Navigation.PushAsync(new HomePage());
           }
        }

        private void RegisterUserButton_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
