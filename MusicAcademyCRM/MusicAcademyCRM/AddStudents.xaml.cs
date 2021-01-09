using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MusicAcademyCRM.Model;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicAcademyCRM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddStudents : ContentPage
    {
        public AddStudents()
        {
            InitializeComponent();
        }

        private async void ToolBarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                Student student = new Student()
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
                await App.MobileService.GetTable<Student>().InsertAsync(student);
                await DisplayAlert("Success", "Name Successfully inserted", "OK");
            }
            catch (NullReferenceException nre)
            {
                await DisplayAlert("Failure", "Student failed to be inserted", "Ok");
            }

            catch (Exception ex)
            {
                await DisplayAlert("Failure", "Student failed to be inserted", "Ok");
            }
        }

    }
}

//else
        //{
        //    await DisplayAlert("Error", "Confirm Password doesn't match!", "Ok");
        //}

    //using (var conn = new SQLiteConnection(App.DatabaseLocation))
    //{
    //    conn.CreateTable<Student>();

    //    int rows = conn.Insert(student);


    //    if (rows > 0)
    //        DisplayAlert("Success", "Name Successfully inserted", "OK");
    //    else
    //        DisplayAlert("Failure", "Name Failed to be inserted", "OK");
    //}

  