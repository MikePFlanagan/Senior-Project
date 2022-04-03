using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicAcademyCRM.Helpers;
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

        private void ToolBarItem_Clicked(object sender, EventArgs e)
        {
            Teacher newTeacher;
            if (!string.IsNullOrWhiteSpace(nameEntry.Text) &&
                !string.IsNullOrWhiteSpace(phoneEntry.Text) &&
                !string.IsNullOrWhiteSpace(emailEntry.Text) &&
                !string.IsNullOrWhiteSpace(addressEntry.Text) &&
                !string.IsNullOrWhiteSpace(cityEntry.Text) &&
                !string.IsNullOrWhiteSpace(stateEntry.Text) &&
                !string.IsNullOrWhiteSpace(zipcodeEntry.Text) &&
                !string.IsNullOrWhiteSpace(instrumentsEntry.Text)) 
                //&& !string.IsNullOrWhiteSpace(notesEntry.Text))
                try
                {
                    {
                        newTeacher = new Teacher()
                        {
                            Name = nameEntry.Text,
                            Phone = phoneEntry.Text,
                            Email = emailEntry.Text,
                            Address = addressEntry.Text,
                            City = cityEntry.Text,
                            State = stateEntry.Text,
                            Zipcode = zipcodeEntry.Text,
                            Instruments = instrumentsEntry.Text,
                            Notes = notesEntry.Text

                        };

                        //using (var conn = new SQLiteConnection(App.DatabaseLocation))
                        //{
                        //    conn.CreateTable<Teacher>();

                        //    int rows = conn.Insert(teacher);


                        //    if (rows > 0)
                        //        DisplayAlert("Success", "Name Successfully inserted", "OK");
                        //    else
                        //        DisplayAlert("Failure", "Name Failed to be inserted", "OK");
                        //}

                        bool result = TeacherFirestore.Insert(newTeacher);
                        if (result)
                        {
                            nameEntry.Text = string.Empty;
                            phoneEntry.Text = string.Empty;
                            emailEntry.Text = string.Empty;
                            addressEntry.Text = string.Empty;
                            cityEntry.Text = string.Empty;
                            stateEntry.Text = string.Empty;
                            zipcodeEntry.Text = string.Empty;
                            instrumentsEntry.Text = string.Empty;
                            notesEntry.Text = string.Empty;


                            DisplayAlert("Success", "Teacher Successfully added", "OK");
                        }
                        else
                            DisplayAlert("Failure", "Teacher Failed to be added", "OK");
                    }
                }
                catch (NullReferenceException nrex)
                {

                }
                catch (Exception ex)
                {

                }
            else
            {
                DisplayAlert("Alert", "Input is not valid. All fields required except for Notes", "OK");
            }
        }
    }
}
