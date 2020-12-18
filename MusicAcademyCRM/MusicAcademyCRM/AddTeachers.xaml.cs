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

        private void ToolBarItem_Clicked(object sender, EventArgs e)
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
                Notes = notesEntry.Text






            };

            using (var conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Teacher>();
                
                int rows = conn.Insert(teacher);
               

                if (rows > 0)
                    DisplayAlert("Success", "Name Successfully inserted", "OK");
                else
                    DisplayAlert("Failure", "Name Failed to be inserted", "OK");
            }
        }
    }
}