using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
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
            companyEntry.Text = selectedStudent.Company;
            leadsourceEntry.Text = selectedStudent.Leadsource;
            notesEntry.Text = selectedStudent.Notes;
        }



        private async void UpdateButton_Clicked(object sender, EventArgs e)
        {
            try
            {

                selectedStudent.Name = nameEntry.Text;
                selectedStudent.Phone = phoneEntry.Text;
                selectedStudent.Email = emailEntry.Text;
                selectedStudent.Address = addressEntry.Text;
                selectedStudent.City = cityEntry.Text;
                selectedStudent.State = stateEntry.Text;
                selectedStudent.Zipcode = zipcodeEntry.Text;
                selectedStudent.Company = companyEntry.Text;
                selectedStudent.Leadsource = leadsourceEntry.Text;
                selectedStudent.Notes = notesEntry.Text;
            

            await App.MobileService.GetTable<Student>().UpdateAsync(selectedStudent);
            await DisplayAlert("Success", "Student Record Successfully updated", "OK");
        }
        catch (NullReferenceException nre)
        {
            await DisplayAlert("Failure", "Student Record failed to be updated", "Ok");
        }

        catch (Exception ex)
        {
            await DisplayAlert("Failure", "Student failed to be updated", "Ok");
        }
    }



//using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
        //{

        //    conn.CreateTable<Student>();

        //    int rows = conn.Update(selectedStudent);

        //    if (rows > 0)
        //        DisplayAlert("Success", "Name Successfully Updated", "OK");
        //    else
        //        DisplayAlert("Failure", "Name Failed to be Updated", "OK");
        //}



        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                await App.MobileService.GetTable<Student>().DeleteAsync(selectedStudent);
                await DisplayAlert("Success", "Name Successfully Deleted", "OK");
                //{
                //    using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                //    {

                //        conn.CreateTable<Student>();

                //        int rows = conn.Delete(selectedStudent);


                //        if (rows > 0)
                //            DisplayAlert("Success", "Name Successfully Deleted", "OK");
                //        else
                //            DisplayAlert("Failure", "Name Failed to be Deleted", "OK");
                //    }
                //}
            }
            catch (NullReferenceException nre)
            {
                await DisplayAlert("Failure", "Student Record failed to be Deleted", "Ok");
            }

            catch (Exception ex)
            {
                await DisplayAlert("Failure", "Student failed to be Deleted", "Ok");
            }
        }
    }
}


