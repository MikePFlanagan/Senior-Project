using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MusicAcademyCRM.Model
{
    public class Lesson
    {
        public string Id { get; set; }        
        public string StudentName { get; set; }
        public string TeacherName { get; set; }
        public string Instrument { get; set; }       
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        //public TimeSpan From { get; set; }
        //public TimeSpan To { get; set; }
        

        
        
        ////public DateTime To { get; set; }
        //public string To { get; set; }

        public string Amount { get; set; }
        
        //public bool AllDay { get; set; }
        //public Color Color { get; set; }
        public string UserId { get; set; }

       
    }
}
