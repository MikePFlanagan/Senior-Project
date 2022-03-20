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
            try
            {
                Student newStudent = new Student()
                {
                    Name = nameEntry.Text,
                    Phone = phoneEntry.Text,
                    Email = emailEntry.Text,
                    Address = addressEntry.Text,
                    City = cityEntry.Text,
                    State = stateEntry.Text,
                    Zipcode = zipcodeEntry.Text,
                    
                    Leadsource = leadsourceEntry.Text,
                    Notes = notesEntry.Text

                };

                //using (var conn = new SQLiteConnection(App.DatabaseLocation))
                //{
                //    conn.CreateTable<Student>();

                //    int rowsAffected = conn.Insert(student);

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
                   
                    leadsourceEntry.Text = string.Empty;
                    notesEntry.Text = string.Empty;


                    DisplayAlert("Success", "Student Successfully inserted", "OK");
                }
                else
                    DisplayAlert("Failure", "Student Failed to be inserted", "OK");
            }
            catch (NullReferenceException nrex) 
            { 

            }
            catch (Exception ex)
            {
            
            }

        }
    }
}