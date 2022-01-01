using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicAcademyCRM.Helpers;
using MusicAcademyCRM.Model;
using SQLite;
using Xamarin.Forms;


namespace MusicAcademyCRM
{
   
    public partial class Lessons : ContentPage
    {
        

        public Lessons()
        {
            InitializeComponent();
        }

      

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //{
            //    conn.CreateTable<Student>();
            //    var students = conn.Table<Student>().ToList();
            //    conn.Close();
            //    studentListView.ItemsSource = students;
            //}

            lessonListView.ItemsSource = null;
            var lessons = await LessonFirestore.Read();            
            lessonListView.ItemsSource = lessons;

            
        }


        private void lessonListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedLesson = lessonListView.SelectedItem as Lesson;

            if (selectedLesson != null)
            {
                Navigation.PushAsync(new LessonDetailPage(selectedLesson));
            }
        }
    }
    }
