using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicAcademyCRM.Helpers;
using MusicAcademyCRM.Model;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicAcademyCRM
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddLessons : ContentPage
    {
        DateTime StartTime;
        public AddLessons()
        {
            InitializeComponent();
        }

        void OnDateSelected(object sender, DateChangedEventArgs args)
        {
            Recalculate();
        }
        void Recalculate()
        {
            TimeSpan timeSpan = endDatePicker.Date - startDatePicker.Date;

            
        }
        

       

            private void ToolBarItem_Clicked(object sender, EventArgs e)
        {
            try
            {
                Lesson newLesson = new Lesson()
                {
                    StudentName = studentNameEntry.Text,
                    TeacherName = teacherNameEntry.Text,
                    Instrument = instrumentEntry.Text,
                    StartDate = startDatePicker.Date.Add(startTimePicker.Time),
                    EndDate = endDatePicker.Date.Add(endTimePicker.Time),
                    //From = startTimePicker.Time,
                    //To = endTimePicker.Time,
                    Amount = amountEntry.Text,
                };
                   
           

                    //using (var conn = new SQLiteConnection(App.DatabaseLocation))
                    //{
                    //    conn.CreateTable<Student>();

                    //    int rowsAffected = conn.Insert(student);

                    bool result = LessonFirestore.Insert(newLesson);
                if (result)
                {

                    studentNameEntry.Text = string.Empty;
                    teacherNameEntry.Text = string.Empty;
                    instrumentEntry.Text = string.Empty;
                    startDatePicker.Date = DateTime.Now;
                    endDatePicker.Date = DateTime.Now.AddMinutes(30);
                    startTimePicker.Time = TimeSpan.Zero;
                    endTimePicker.Time = TimeSpan.Zero;

                    amountEntry.Text = string.Empty;



                    DisplayAlert("Success", "Lesson Successfully Saved", "OK");
                }
                else
                    DisplayAlert("Failure", "Lesson Failed to be Saved", "OK");
            }
            catch (NullReferenceException nrex) 
            { 

            }
            catch (Exception ex)
            {
            
            }

        }
    }
}