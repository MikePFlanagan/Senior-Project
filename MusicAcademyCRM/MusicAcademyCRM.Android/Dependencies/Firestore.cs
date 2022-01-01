using Android.Gms.Tasks;
using Android.Runtime;
using Firebase.Firestore;
using Java.Interop;
using Java.Util;
using MusicAcademyCRM.Helpers;
using MusicAcademyCRM.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;


[assembly: Dependency(typeof(MusicAcademyCRM.Droid.Dependencies.Firestore))]
namespace MusicAcademyCRM.Droid.Dependencies
{
    public class Firestore : Java.Lang.Object, IFirestore, IOnCompleteListener
    {
        List<Student> students;
        bool hasReadStudents = false;
        public Firestore()
        {
            students = new List<Student>();
           
        }

      

        public async Task<bool> Delete(Student student)
        {

            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("students");
                collection.Document(student.Id).Delete();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public bool Insert(Student student)
        {
            try
            {
                var studentDocument = new Dictionary<string, Java.Lang.Object>
                {
                    { "name", student.Name},
                    { "phone", student.Phone},
                    { "email", student.Email},
                    { "address", student.Address},
                    { "city", student.City},
                    { "state", student.State},
                    { "zipcode", student.Zipcode},
                    { "company", student.Company},
                    { "leadsource", student.Leadsource},
                    { "notes", student.Notes},
                    { "userId", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid},
                };

                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("students");
                collection.Add(new HashMap(studentDocument));

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

      
        public void OnComplete(Android.Gms.Tasks.Task task)
        {
           
            if (task.IsSuccessful)
            {
                var snapshot = (QuerySnapshot)task.Result;

                
                students.Clear();
                if(!snapshot.IsEmpty)
                {
                    var documents = snapshot.Documents;

                    students.Clear();
                    foreach (DocumentSnapshot item in documents)
                    {
                        Student newStudent = new Student()
                        {
                            Name = (string)item.Get("name"),
                            Phone = (string)item.Get("phone"),
                            Email = (string)item.Get("email"),
                            Address = (string)item.Get("address"),
                            City = (string)item.Get("city"),
                            State = (string)item.Get("state"),
                            Zipcode = (string)item.Get("zipcode"),
                            Company = (string)item.Get("company"),
                            Leadsource = (string)item.Get("leadsource"),
                            Notes = (string)item.Get("notes"),
                            UserId = (string)item.Get("userId"),
                            Id = item.Id, 


                            //Name = item.Get("name").ToString() != null ? item.Get("name").ToString() : "",
                            //Phone = item.Get("phone").ToString() != null ? item.Get("phone").ToString() : "",
                            //newStudent.Email = item.Get("email").ToString() != null ? item.Get("email").ToString() : "";
                            //newStudent.Address = item.Get("address").ToString() != null ? item.Get("address").ToString() : "";
                            //newStudent.City = item.Get("city").ToString() != null ? item.Get("city").ToString() : "";
                            //newStudent.State = item.Get("state").ToString() != null ? item.Get("state").ToString() : "";
                            //newStudent.Zipcode = item.Get("zipcode").ToString() != null ? item.Get("zipcode").ToString() : "";
                            //newStudent.Company = item.Get("company").ToString() != null ? item.Get("company").ToString() : "";
                            //newStudent.Leadsource = item.Get("leadsource").ToString() != null ? item.Get("leadsource").ToString() : "";
                            //newStudent.Notes = item.Get("notes").ToString() != null ? item.Get("notes").ToString() : "";
                            //newStudent.UserId = item.Get("userId").ToString() != null ? item.Get("userId").ToString() : "";
                            //newStudent.Id = item.Id != null ? item.Id: "";
                        };
                        students.Add(newStudent);
                    }
                }
            }
            else
            {
                students.Clear();
            }
            hasReadStudents = true;
        }





        public async Task<List<Student>> Read()
        {
            try
            {
                hasReadStudents = false;
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("students");
                var query = collection.WhereEqualTo("userId", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid);               
                query.Get().AddOnCompleteListener(this);

                for (int i = 0; i < 50; i++)
                {
                    await System.Threading.Tasks.Task.Delay(100);
                    if (hasReadStudents)
                        break;

                }

                return students;
            }
            catch (Exception ex)
            {
                return students;
            }
        }



        public Task<bool> Update(Student student)
        {
            try
            {
                var studentDocument = new Dictionary<string, Java.Lang.Object>
                {
                    { "name", student.Name },
                    { "phone", student.Phone  },
                    { "email", student.Email },
                    { "address", student.Address },
                    { "city", student.City },
                    { "state", student.State},
                    { "zipcode", student.Zipcode },
                    { "company", student.Company},
                    { "leadsource", student.Leadsource},
                    { "notes", student.Notes },
                    { "userid", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid },
                };

                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("students");
                collection.Document(student.Id).Update(studentDocument);

                return System.Threading.Tasks.Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return System.Threading.Tasks.Task.FromResult(false);
            }
        }

        
    }
}
