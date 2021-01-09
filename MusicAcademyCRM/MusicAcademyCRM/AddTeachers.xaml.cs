using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicAcademyCRM.Model;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicAcademyCRM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTeachers : ContentPage
    {
        public AddTeachers()
        {
            InitializeComponent();
        }

        private async void ToolBarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                Teacher teacher = new Teacher()
                {
                Name = nameEntry.Text,
                Phone = phoneEntry.Text, 
                Email = emailEntry.Text,
                Address = addressEntry.Text,
                City = cityEntry.Text,
                State = stateEntry.Text,
                Zipcode = zipcodeEntry.Text,
                Company = companyEntry.Text,
                Leadsource = leadsourceEntry.Text,
                Notes = notesEntry.Text,
                UserId = App.user.Id

                };
            await App.MobileService.GetTable<Teacher>().InsertAsync(teacher);
            await DisplayAlert("Success", "Teacher Successfully inserted", "OK");
            }
            catch (NullReferenceException nre)
            {
                await DisplayAlert("Failure", "Teacher failed to be inserted", "Ok");
            }

            catch (Exception ex)
            {
                await DisplayAlert("Failure", "Teacher failed to be inserted", "Ok");
            }
        }

    }
}

            //using (var conn = new SQLiteConnection(App.DatabaseLocation))
            //{
            //    conn.CreateTable<Teacher>();
                
            //    int rows = conn.Insert(teacher);
               

            //    if (rows > 0)
            //        DisplayAlert("Success", "Name Successfully inserted", "OK");
            //    else
            //        DisplayAlert("Failure", "Name Failed to be inserted", "OK");
            //}
//        }
//    }
//}