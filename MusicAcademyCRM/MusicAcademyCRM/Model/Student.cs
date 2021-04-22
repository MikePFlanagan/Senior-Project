﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using SQLite;


namespace MusicAcademyCRM.Model
{
    public class Student
   
        {
            [PrimaryKey, AutoIncrement]
            public string Id { get; set; }

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
            public string Zipcode { get; set; }
            [MaxLength(75)]
            public string Company { get; set; }

            [MaxLength(15)]
            public string Leadsource { get; set; }

            [MaxLength(250)]
            public string Notes { get; set; }

            public string  UserId { get; set; }


            public static async void Insert(Student student)
            {
            await App.MobileService.GetTable<Student>().InsertAsync(student);

            }

    }
    }

