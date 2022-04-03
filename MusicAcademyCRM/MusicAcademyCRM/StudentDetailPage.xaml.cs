using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Client;
using MusicAcademyCRM.Helpers;
using MusicAcademyCRM.Model;
using SQLite;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicAcademyCRM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentDetailPage : ContentPage
    {
        Student selectedStudent;
        public StudentDetailPage(Student selectedStudent)
        {
            InitializeComponent();
            this.selectedStudent = selectedStudent;
            nameEntry.Text = selectedStudent.Name;
            phoneEntry.Text = selectedStudent.Phone;
            emailEntry.Text = selectedStudent.Email;
            addressEntry.Text = selectedStudent.Address;
            cityEntry.Text = selectedStudent.City;
            stateEntry.Text = selectedStudent.State;
            zipcodeEntry.Text = selectedStudent.Zipcode;
            instrumentsEntry.Text = selectedStudent.Instruments;
            leadsourceEntry.Text = selectedStudent.Instruments;
            notesEntry.Text = selectedStudent.Notes;
        }

        async void UpdateButton_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(nameEntry.Text) &&
                !string.IsNullOrWhiteSpace(phoneEntry.Text) &&
                !string.IsNullOrWhiteSpace(emailEntry.Text) &&
                !string.IsNullOrWhiteSpace(addressEntry.Text) &&
                !string.IsNullOrWhiteSpace(cityEntry.Text) &&
                !string.IsNullOrWhiteSpace(stateEntry.Text) &&
                !string.IsNullOrWhiteSpace(zipcodeEntry.Text) &&
                !string.IsNullOrWhiteSpace(instrumentsEntry.Text) &&
                !string.IsNullOrWhiteSpace(leadsourceEntry.Text))
                //&& !string.IsNullOrWhiteSpace(notesEntry.Text))
            {
                selectedStudent.Name = nameEntry.Text;
                selectedStudent.Phone = phoneEntry.Text;
                selectedStudent.Email = emailEntry.Text;
                selectedStudent.Address = addressEntry.Text;
                selectedStudent.City = cityEntry.Text;
                selectedStudent.State = stateEntry.Text;
                selectedStudent.Zipcode = zipcodeEntry.Text;
                selectedStudent.Instruments = instrumentsEntry.Text;
                selectedStudent.LeadSource = leadsourceEntry.Text;
                selectedStudent.Notes = notesEntry.Text;

                //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                //{

                //    conn.CreateTable<Student>();

                //    int rows = conn.Update(selectedStudent);

                //    if (rows > 0)
                //        DisplayAlert("Success", "Name Successfully Updated", "OK");
                //    else
                //        DisplayAlert("Failure", "Name Failed to be Updated", "OK");
                //}

                bool result = await Firestore.Update(selectedStudent);
                if (result)
                {
                    await DisplayAlert("Success", "Student Successfully Updated", "OK");
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Failure", "Student Failed to be Updated", "OK");
                    await Navigation.PopAsync();
                }
            }
            else
            {
                DisplayAlert("Alert", "Input is not valid. All fields except Notes are required to be filled in.", "OK");
            }
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

            bool result = await Firestore.Delete(selectedStudent);
            if (result)
            {
                await DisplayAlert("Success", "Student Successfully Deleted", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Failure", "Student Failed to be Deleted", "OK");
                await Navigation.PopAsync();
            }
        }
    }
}
