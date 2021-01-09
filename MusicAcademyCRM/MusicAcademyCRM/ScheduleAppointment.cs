using System;
using System.Collections.Generic;
using System.Text;
using Syncfusion.SfSchedule.XForms;
using Xamarin.Forms;

namespace MusicAcademyCRM.Model
{
    public class ScheduleAppointment : ContentPage
    {
        public ScheduleAppointmentCollection AppointmentCollection { get; set; }

        public ScheduleAppointment()
        {
            AppointmentCollection = new ScheduleAppointmentCollection();
            //Creating new event   
            var clientMeeting = new Syncfusion.SfSchedule.XForms.ScheduleAppointment();
            DateTime currentDate = DateTime.Now;
            DateTime startTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 10, 0, 0);
            DateTime endTime = new DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 12, 0, 0);
            clientMeeting.StartTime = startTime;
            clientMeeting.EndTime = endTime;
            clientMeeting.Color = Color.Green;
            clientMeeting.Subject = "ClientMeeting";
            AppointmentCollection.Add(clientMeeting);
		}
    }
}
