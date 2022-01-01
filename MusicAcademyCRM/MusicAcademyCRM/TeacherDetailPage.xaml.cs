using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicAcademyCRM.Helpers;
using MusicAcademyCRM.Model;
using SQLite;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicAcademyCRM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TeacherDetailPage : ContentPage
    {
        Teacher selectedTeacher;
        public TeacherDetailPage(Teacher selectedTeacher)
        {
            InitializeComponent();
            this.selectedTeacher = selectedTeacher;
            nameEntry.Text = selectedTeacher.Name;
            phoneEntry.Text = selectedTeacher.Phone;
            emailEntry.Text = selectedTeacher.Email;
            addressEntry.Text = selectedTeacher.Address;
            cityEntry.Text = selectedTeacher.City;
            stateEntry.Text = selectedTeacher.State;
            zipcodeEntry.Text = selectedTeacher.Zipcode;
            companyEntry.Text = selectedTeacher.Company;
            leadsourceEntry.Text = selectedTeacher.Leadsource;
            notesEntry.Text = selectedTeacher.Notes;
        }



        async void UpdateButton_Clicked(object sender, EventArgs e)
        {
            selectedTeacher.Name = nameEntry.Text;
            selectedTeacher.Phone = phoneEntry.Text;
            selectedTeacher.Email = emailEntry.Text;
            selectedTeacher.Address = addressEntry.Text;
            selectedTeacher.City = cityEntry.Text;
            selectedTeacher.Zipcode = zipcodeEntry.Text;
            selectedTeacher.Company = companyEntry.Text;
            selectedTeacher.Leadsource = leadsourceEntry.Text;
            selectedTeacher.Notes = notesEntry.Text;

            //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //{

            //    conn.CreateTable<Teacher>();

            //    int rows = conn.Update(selectedTeacher);

            //    if (rows > 0)
            //        DisplayAlert("Success", "Name Successfully Updated", "OK");
            //    else
            //        DisplayAlert("Failure", "Name Failed to be Updated", "OK");
            //}

            bool result = await TeacherFirestore.Update(selectedTeacher);
            if (result)
            {
                DisplayAlert("Success", "Teacher Successfully Updated", "OK");
                Navigation.PopAsync();
            }
            else
                DisplayAlert("Failure", "Teacher Failed to be Updated", "OK");
        }


        async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //{

            //    conn.CreateTable<Student>();

            //    int rows = conn.Delete(selectedStudent);


            //    if (rows > 0)
            //        DisplayAlert("Success", "Name Successfully Deleted", "OK");
            //    else
            //        DisplayAlert("Failure", "Name Failed to be Deleted", "OK");
            //}

            bool result = await TeacherFirestore.Delete(selectedTeacher);
            if (result)
            {
                DisplayAlert("Success", "Teacher Successfully Deleted", "OK");
                Navigation.PopAsync();
            }
            else
                DisplayAlert("Failure", "Teacher Failed to be Deleted", "OK");
        }
    }
}
    