using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using SQLite;

namespace MusicAcademyCRM.Model
{
    public class Lesson
    {
      
            [PrimaryKey, AutoIncrement]
            public int EventId { get; set; }

            [MaxLength(100)]
            public string Teacher { get; set; }

            [MaxLength(100)]
            public string Student { get; set; }

            [MaxLength(100)]
            public string Instrument { get; set; }

            [MaxLength(300)]
            public string Room { get; set; }

            [MaxLength(50)]
            public DateTime StartTime { get; set; }

            [MaxLength(50)]
            public DateTime EndTime { get; set; }

            [MaxLength(300)]
            public string Notes { get; set; }

        public static async void Insert(Lesson lesson)
            {
                await App.MobileService.GetTable<Lesson>().InsertAsync(lesson);
            }

    

        public string UserId { get; set; }



    }
}

