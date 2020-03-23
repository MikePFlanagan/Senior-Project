using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Text;
using SQLite;
using Xamarin.Essentials;

namespace MusicAcademyCRM.Model
{
    public class Post
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(75)]
        public string Name { get; set; }

        [MaxLength(15)]
        public string Phone { get; set; }
        
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(75)]
        public string Address { get; set; }

        [MaxLength(15)]
        public string City { get; set; }

        [MaxLength(50)]
        public string State { get; set; }
        [MaxLength(10)]
        public string Zipcode{ get; set; }
        [MaxLength(75)]
        public string Company { get; set; }

        [MaxLength(15)]
        public string Leadsource { get; set; }

        [MaxLength(250)]
        public string Notes { get; set; }






       
        
        
       
    }
}
