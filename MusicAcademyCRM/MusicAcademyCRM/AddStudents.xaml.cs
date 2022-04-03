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
    public partial class AddStudents : ContentPage
    {
        public AddStudents()
        {
            InitializeComponent();
        }


        private void ToolBarItem_Clicked(object sender, EventArgs e)
        {
            Student newStudent;
            if (!string.IsNullOrWhiteSpace(nameEntry.Text) &&
                !string.IsNullOrWhiteSpace(phoneEntry.Text) &&
                !string.IsNullOrWhiteSpace(emailEntry.Text) &&
                !string.IsNullOrWhiteSpace(addressEntry.Text) &&
                !string.IsNullOrWhiteSpace(cityEntry.Text) &&
                !string.IsNullOrWhiteSpace(stateEntry.Text) &&
                !string.IsNullOrWhiteSpace(zipcodeEntry.Text) &&
                !string.IsNullOrWhiteSpace(instrumentsEntry.Text) &&
                !string.IsNullOrWhiteSpace(leadsourceEntry.Text))
                //&& !string.IsNullOrWhiteSpace(notesEntry.Text)))
                try
                {
                    { 
                     
                        newStudent = new Student()
                        {
                            Name = nameEntry.Text,
                            Phone = phoneEntry.Text,
                            Email = emailEntry.Text,
                            Address = addressEntry.Text,
                            City = cityEntry.Text,
                            State = stateEntry.Text,
                            Zipcode = zipcodeEntry.Text,
                            Instruments = instrumentsEntry.Text,
                            LeadSource = leadsourceEntry.Text,
                            Notes = notesEntry.Text
                        };

                        //using (var conn = new SQLiteConnection(App.DatabaseLocation))
                        //{
                        //    conn.CreateTable<Student>();

                        //    int rowsAffected = conn.Insert(student);

                        //    if (rows > 0)
                        //        DisplayAlert("Success", "Name Successfully inserted", "OK");
                        //    else
                        //        DisplayAlert("Failure", "Name Failed to be inserted", "OK");
                        //}

                        bool result = Firestore.Insert(newStudent);
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
                            leadsourceEntry.Text = string.Empty;
                            notesEntry.Text = string.Empty;


                            DisplayAlert("Success", "Student Successfully inserted", "OK");
                        }
                        else
                            DisplayAlert("Failure", "Student Failed to be inserted", "OK");
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