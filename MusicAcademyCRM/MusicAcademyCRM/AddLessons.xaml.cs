using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Drawing;
using MusicAcademyCRM.Annotations;
using MusicAcademyCRM.Model;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace MusicAcademyCRM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddLessons : ContentPage
    {
        public AddLessons()
        {
            InitializeComponent();
        }
        private async void ToolBarItem_Clicked(object sender, EventArgs e)
        {
            
            try
            {
                Lesson lesson = new Lesson()
            {
                Teacher = teacherEntry.Text,
                Student = studentEntry.Text,
                Instrument = instrumentEntry.Text,
                Room = roomEntry.Text,
                StartTime = Convert.ToDateTime(startTimeLabel.Text),
                EndTime = Convert.ToDateTime(endTimeEntry.Text),
                Notes = notesEntry.Text,
                UserId = App.user.Id

            };
                //await App.MobileService.GetTable<Student>().InsertAsync(student);

                Lesson.Insert(lesson);
                await DisplayAlert("Success", "Lesson Successfully inserted", "OK");
            }
            catch (NullReferenceException nre)
            {
                await DisplayAlert("Failure", "Lesson failed to be inserted", "Ok");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Failure", "Lesson failed to be inserted", "Ok");
            }
        }

        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            MainLable.Text = e.NewDate.ToString();
        }
    }
}
