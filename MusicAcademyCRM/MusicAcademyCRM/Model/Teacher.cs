using System;
using System.Collections.Generic;
using System.Text;

namespace MusicAcademyCRM.Model
{
  
    public class Teacher
    {
       
        public string Id { get; set; }      
        public string Name { get; set; }   
        public string Phone { get; set; }       
        public string Email { get; set; }      
        public string Address { get; set; }    
        public string City { get; set; }     
        public string State { get; set; }        
        public string Zipcode { get; set; }       
        public string Availability { get; set; }
        public string Instruments { get; set; }
        public string Notes { get; set; }
        public string UserId { get; set; }
    }
}

