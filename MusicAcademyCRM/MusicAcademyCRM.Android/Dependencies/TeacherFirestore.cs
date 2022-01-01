using Android.Gms.Tasks;
using Firebase.Firestore;
using Java.Interop;
using Java.Util;
using MusicAcademyCRM.Helpers;
using MusicAcademyCRM.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;


[assembly: Dependency(typeof(MusicAcademyCRM.Droid.Dependencies.TeacherFirestore))]
namespace MusicAcademyCRM.Droid.Dependencies
{
    public class TeacherFirestore : Java.Lang.Object, ITeacherFirestore, IOnCompleteListener
    {
        List<Teacher> teachers;
        bool hasReadTeachers = false;
        public TeacherFirestore()
        {
            teachers = new List<Teacher>();
           
        }



        public async Task<bool> Delete(Teacher teacher)
        {

            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("teachers");
                collection.Document(teacher.Id).Delete();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public bool Insert(Teacher teacher)
        {
            try
            {
                var teacherDocument = new Dictionary<string, Java.Lang.Object>
                {
                    { "name", teacher.Name},
                    { "phone", teacher.Phone},
                    { "email", teacher.Email},
                    { "address", teacher.Address},
                    { "city", teacher.City},
                    { "state", teacher.State},
                    { "zipcode", teacher.Zipcode},
                    { "company", teacher.Company},
                    { "leadsource", teacher.Leadsource},
                    { "notes", teacher.Notes},
                    { "userId", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid},
                };

                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("teachers");
                collection.Add(new HashMap(teacherDocument));

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        //public void OnSuccess(Java.Lang.Object result)
        //{
        //    var snapshot = (QuerySnapshot)result;

        //    if(!snapshot.IsEmpty)
        //}

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
           
            if (task.IsSuccessful)
            {
                var snapshot = (QuerySnapshot)task.Result;

                
                teachers.Clear();
                if(!snapshot.IsEmpty)
                {
                    var documents = snapshot.Documents;

                    teachers.Clear();
                    foreach (DocumentSnapshot item in documents)
                    {
                        Teacher newTeacher = new Teacher()
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
                            //newTeacher.Email = item.Get("email").ToString() != null ? item.Get("email").ToString() : "";
                            //newTeacher.Address = item.Get("address").ToString() != null ? item.Get("address").ToString() : "";
                            //newTeacher.City = item.Get("city").ToString() != null ? item.Get("city").ToString() : "";
                            //newTeacher.State = item.Get("state").ToString() != null ? item.Get("state").ToString() : "";
                            //newTeacher.Zipcode = item.Get("zipcode").ToString() != null ? item.Get("zipcode").ToString() : "";
                            //newTeacher.Company = item.Get("company").ToString() != null ? item.Get("company").ToString() : "";
                            //newTeacher.Leadsource = item.Get("leadsource").ToString() != null ? item.Get("leadsource").ToString() : "";
                            //newTeacher.Notes = item.Get("notes").ToString() != null ? item.Get("notes").ToString() : "";
                            //newTeacher.UserId = item.Get("userId").ToString() != null ? item.Get("userId").ToString() : "";
                            //newTeacher.Id = item.Id != null ? item.Id: "";
                        };
                        teachers.Add(newTeacher);
                    }
                }
            }
            else
            {
                teachers.Clear();
            }
            hasReadTeachers = true;
        }





        public async Task<List<Teacher>> Read()
        {
            try
            {
                hasReadTeachers = false;
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("teachers");
                var query = collection.WhereEqualTo("userId", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid);               
                query.Get().AddOnCompleteListener(this);

                for (int i = 0; i < 50; i++)
                {
                    await System.Threading.Tasks.Task.Delay(100);
                    if (hasReadTeachers)
                        break;

                }

                return teachers;
            }
            catch (Exception ex)
            {
                return teachers;
            }
        }



        public Task<bool> Update(Teacher teacher)
        {
            try
            {
                var teacherDocument = new Dictionary<string, Java.Lang.Object>
                {
                    { "name", teacher.Name },
                    { "phone", teacher.Phone  },
                    { "email", teacher.Email },
                    { "address", teacher.Address },
                    { "city", teacher.City },
                    { "state", teacher.State},
                    { "zipcode", teacher.Zipcode },
                    { "company", teacher.Company},
                    { "leadsource", teacher.Leadsource},
                    { "notes", teacher.Notes },
                    { "userid", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid },
                };

                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("teachers");
                collection.Document(teacher.Id).Update(teacherDocument);

                return System.Threading.Tasks.Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return System.Threading.Tasks.Task.FromResult(false);
            }
        }

        
    }
}
