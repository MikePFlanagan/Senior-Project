using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using MusicAcademyCRM.Model;
using Xamarin.Forms;

namespace MusicAcademyCRM
{
    /// Represents collection of appointments.   
    /// </summary> 
    public class ViewModel
    {
        public ObservableCollection<Meeting> Meetings { get; set; }
        List<string> eventNameCollection;
        List<Color> colorCollection;

        public ViewModel()
        {
            this.Meetings = new ObservableCollection<Meeting>();
            this.CreateEventNameCollection();
            this.CreateColorCollection();
            this.CreateAppointments();
        }

        /// <summary>
        /// Creates meetings and stores in a collection.  
        /// </summary>
        private void CreateAppointments()
        {
            Random randomTime = new Random();
            List<Point> randomTimeCollection = GetTimeRanges();
            DateTime date;
            DateTime DateFrom = DateTime.Now.AddDays(-10);
            DateTime DateTo = DateTime.Now.AddDays(10);
            DateTime dataRangeStart = DateTime.Now.AddDays(-3);
            DateTime dataRangeEnd = DateTime.Now.AddDays(3);

            for (date = DateFrom; date < DateTo; date = date.AddDays(1))
            {
                if ((DateTime.Compare(date, dataRangeStart) > 0) && (DateTime.Compare(date, dataRangeEnd) < 0))
                {
                    for (int appointmentIndex = 0; appointmentIndex < 3; appointmentIndex++)
                    {

                        Meeting meeting = new Meeting();

                        int hour = (randomTime.Next((int) randomTimeCollection[appointmentIndex].X,
                            (int) randomTimeCollection[appointmentIndex].Y));

                        meeting.BeginTime = new DateTime(date.Year, date.Month, date.Day, hour, 0, 0);

                        meeting.EndTime = (meeting.BeginTime.AddHours(1));

                        meeting.EventName = eventNameCollection[randomTime.Next(3)];

                        meeting.Color = colorCollection[randomTime.Next(3)];

                        if (appointmentIndex % 3 == 0)

                            meeting.IsAllDay = true;

                        Meetings.Add(meeting);
                    }
                }
                else
                {
                    Meeting meeting = new Meeting();

                    meeting.BeginTime = new DateTime(date.Year, date.Month, date.Day, randomTime.Next(9, 11), 0, 0);
                    meeting.EndTime = (meeting.BeginTime.AddHours(1));

                    meeting.EventName = eventNameCollection[randomTime.Next(3)];

                    meeting.Color = colorCollection[randomTime.Next(3)];

                    Meetings.Add(meeting);
                }
            }

            this.Meetings[1].RecurrenceRule = "FREQ=DAILY;INTERVAL=1;COUNT=5";
        }

        /// <summary>  
        /// Creates event names collection.  
        /// </summary>  
        private void CreateEventNameCollection()
        {

            eventNameCollection = new List<string>();

            eventNameCollection.Add("General Meeting");

            eventNameCollection.Add("Plan Execution");

            eventNameCollection.Add("Project Plan");
        }

        /// <summary>  
        /// Creates color collection.  
        /// </summary>  
        private void CreateColorCollection()
        {

            colorCollection = new List<Color>();

            colorCollection.Add(Color.FromHex("#FF339933"));

            colorCollection.Add(Color.FromHex("#FF00ABA9"));

            colorCollection.Add(Color.FromHex("#FFE671B8"));
        }

        /// <summary>
        /// Gets the time ranges.
        /// </summary>
        private List<Point> GetTimeRanges()
        {
            List<Point> randomTimeCollection = new List<Point>();

            randomTimeCollection.Add(new Point(9, 11));
            randomTimeCollection.Add(new Point(12, 14));

            randomTimeCollection.Add(new Point(15, 17));
            return randomTimeCollection;
        }
    }
}