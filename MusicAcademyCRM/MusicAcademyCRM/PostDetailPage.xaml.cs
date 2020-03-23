using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class PostDetailPage : ContentPage
    {
        private Post selectedPost;
        public PostDetailPage(Post selectedPost)
        {
            InitializeComponent();
            this.selectedPost = selectedPost;
            nameEntry.Text = selectedPost.Name;
            phoneEntry.Text = selectedPost.Phone;
            emailEntry.Text = selectedPost.Email;
            addressEntry.Text = selectedPost.Address;
            cityEntry.Text = selectedPost.City;
            stateEntry.Text = selectedPost.State;
            zipcodeEntry.Text =selectedPost.Zipcode;
            companyEntry.Text = selectedPost.Company;
            leadsourceEntry.Text = selectedPost.Leadsource;
            notesEntry.Text = selectedPost.Notes;
        }

        

        private void UpdateButton_Clicked(object sender, EventArgs e)
        {
            selectedPost.Name = nameEntry.Text;
            selectedPost.Phone = phoneEntry.Text;
            selectedPost.Email = emailEntry.Text;
            selectedPost.Address = addressEntry.Text;
            selectedPost.City = cityEntry.Text;
            selectedPost.State = stateEntry.Text;
            selectedPost.Zipcode = zipcodeEntry.Text;
            selectedPost.Company = companyEntry.Text;
            selectedPost.Leadsource = leadsourceEntry.Text;
            selectedPost.Notes = notesEntry.Text;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {

                conn.CreateTable<Post>();

                int rows = conn.Update(selectedPost);


                if (rows > 0)
                    DisplayAlert("Success", "Name Successfully Updated", "OK");
                else
                    DisplayAlert("Failure", "Name Failed to be Updated", "OK");
            }
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {

                conn.CreateTable<Post>();

                int rows = conn.Delete(selectedPost);


                if (rows > 0)
                    DisplayAlert("Success", "Name Successfully Deleted", "OK");
                else
                    DisplayAlert("Failure", "Name Failed to be Deleted", "OK");
            }
        }
    }
}