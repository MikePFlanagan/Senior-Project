using System;
using MusicAcademyCRM.Helpers;
using MusicAcademyCRM.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicAcademyCRM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LessonDetailPage : ContentPage
    {
        Lesson selectedLesson;
        public LessonDetailPage(Lesson selectedLesson)
        {
            InitializeComponent();
           

            this.selectedLesson = selectedLesson;
            studentNameEntry.Text = selectedLesson.StudentName;
            teacherNameEntry.Text = selectedLesson.TeacherName;
            instrumentEntry.Text = selectedLesson.Instrument;
            startDatePicker.Date = selectedLesson.StartDate.Date;
            
            //endDatePicker.Date = selectedLesson.EndDate;
            startTimePicker.Time = selectedLesson.StartDate.TimeOfDay;
            endTimePicker.Time = selectedLesson.EndDate.TimeOfDay;
            amountEntry.Text = selectedLesson.Amount;

            
            
        }



        async void UpdateButton_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(studentNameEntry.Text) &&
                !string.IsNullOrWhiteSpace(teacherNameEntry.Text) &&
                !string.IsNullOrWhiteSpace(instrumentEntry.Text) &&
                !string.IsNullOrWhiteSpace(amountEntry.Text))
            {
                selectedLesson.StudentName = studentNameEntry.Text;
                selectedLesson.TeacherName = teacherNameEntry.Text;
                selectedLesson.Instrument = instrumentEntry.Text;
                selectedLesson.StartDate = startDatePicker.Date;
                selectedLesson.StartTime = startTimePicker.Time;
                selectedLesson.EndTime = endTimePicker.Time;
                selectedLesson.Amount = amountEntry.Text;


                //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
                //{

                //    conn.CreateTable<Lesson>();

                //    int rows = conn.Update(selectedLesson);

                //    if (rows > 0)
                //        DisplayAlert("Success", "Name Successfully Updated", "OK");
                //    else
                //        DisplayAlert("Failure", "Name Failed to be Updated", "OK");
                //}

                bool result = await LessonFirestore.Update(selectedLesson);
                if (result)
                {
                    DisplayAlert("Success", "Lesson Successfully Updated", "OK");
                    Navigation.PopAsync();
                }
                else
                    DisplayAlert("Failure", "Lesson Failed to be Updated", "OK");
            }
            else
            {
                DisplayAlert("Alert", "Input is not valid. All fields are required to be filled in.", "OK");
            }
        }

    async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //{

            //    conn.CreateTable<Lesson>();

            //    int rows = conn.Delete(selectedLesson);


            //    if (rows > 0)
            //        DisplayAlert("Success", "Name Successfully Deleted", "OK");
            //    else
            //        DisplayAlert("Failure", "Name Failed to be Deleted", "OK");
            //}

            bool result = await LessonFirestore.Delete(selectedLesson);
            if (result)
            {
                DisplayAlert("Success", "Lesson Successfully Deleted", "OK");
                Navigation.PopAsync();
            }
            else
                DisplayAlert("Failure", "Lesson Failed to be Deleted", "OK");
        }

       
    }
}
