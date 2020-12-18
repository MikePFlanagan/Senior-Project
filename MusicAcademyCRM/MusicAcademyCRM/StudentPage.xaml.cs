using System;
using System.Collections.Generic;
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
    public partial class Students : ContentPage
    {
        public Students()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Student>();
                var students = conn.Table<Student>().ToList();
                conn.Close();
                studentListView.ItemsSource = students;
            }

            
        }


        private void StudentListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedStudent = studentListView.SelectedItem as Student;

            if (selectedStudent != null)
            {
                Navigation.PushAsync(new StudentDetailPage(selectedStudent));
            }
        }
    }
    }
