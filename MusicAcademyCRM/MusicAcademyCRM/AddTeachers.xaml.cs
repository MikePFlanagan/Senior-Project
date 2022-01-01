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
            try
            {
                Teacher newTeacher = new Teacher()
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
                    companyEntry.Text = string.Empty;
                    leadsourceEntry.Text = string.Empty;
                    notesEntry.Text = string.Empty;


                    DisplayAlert("Success", "Teacher Successfully added", "OK");
                }
                else
                    DisplayAlert("Failure", "Teacher Failed to be added", "OK");
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
