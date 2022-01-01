using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicAcademyCRM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : TabbedPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private void AddStudentsToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddStudents());

        }
        private void AddTeachersToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddTeachers());
        }

        private void AddLessonsToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddLessons());
        }
    }

    
}