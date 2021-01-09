using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using SQLite;

namespace MusicAcademyCRM.Model
{
    public class Events
    {
      
            [PrimaryKey, AutoIncrement]
            public int EventId { get; set; }

            [MaxLength(100)]
            public string Instrument { get; set; }

            [MaxLength(300)]
            public string Room { get; set; }

            [MaxLength(50)]
            public DateTime StarTime { get; set; }

            [MaxLength(50)]
            public DateTime EndTime { get; set; }

            [MaxLength(10)]
            public string ThemeColor { get; set; }

            

    }
}

