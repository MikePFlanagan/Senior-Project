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
    public partial class Teachers : ContentPage
    {
        public Teachers()
        {
            InitializeComponent();
        }

        private void TeacherListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedTeacher = teacherListView.SelectedItem as Teacher;

            if (selectedTeacher != null)
            {
                Navigation.PushAsync(new TeacherDetailPage(selectedTeacher));
            }
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Teacher>();
                var teachers = conn.Table<Teacher>().ToList();
                teacherListView.ItemsSource = teachers;
            }


        }


     
}
    }
