using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicAcademyCRM.Model;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicAcademyCRM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void registerButton_Clicked(object sender, EventArgs e)
        {
            if (passwordEntry.Text == comfirmPasswordEntry.Text){
                
                Users user = new Users()
                {
                    Email = emailEntry.Text,
                    Password = passwordEntry.Text
                };

               await App.client.GetTable<Users>().InsertAsync(user);
            }
            else
            {
                await DisplayAlert("Error", "Confirm Password doesn't match!", "Ok");
            }
        }
    }
}