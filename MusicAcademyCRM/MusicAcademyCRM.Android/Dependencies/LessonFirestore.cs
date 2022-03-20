using Android.Gms.Tasks;
using Android.Text.Format;
using Firebase;
using Firebase.Firestore;
using Java.Interop;
using Java.Util;
using MusicAcademyCRM.Helpers;
using MusicAcademyCRM.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Globalization;



[assembly: Dependency(typeof(MusicAcademyCRM.Droid.Dependencies.LessonFirestore))]
namespace MusicAcademyCRM.Droid.Dependencies
{

    public class LessonFirestore : Java.Lang.Object, ILessonFirestore, IOnCompleteListener
    {
        List<Lesson> lessons;
        bool hasReadLessons = false;

        public LessonFirestore()
        {
            lessons = new List<Lesson>();
        }

        public async Task<bool> Delete(Lesson lesson)
        {
            try
            {
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("lessons");
                collection.Document(lesson.Id).Delete();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Insert(Lesson lesson)
        {
            try
            {
                var lessonDocument = new Dictionary<string, Java.Lang.Object>
                {
                    {"studentname", lesson.StudentName },
                    {"teachername",lesson.TeacherName },
                    {"instrument", lesson.Instrument },
                    //{"startdate", lesson.StartDate.Date.ToString() },
                    //{"enddate", lesson.EndDate.Date.ToShortDateString() },

                    { "startdate", lesson.StartDate.Add(lesson.StartTime).ToString()},
                    { "enddate", lesson.EndDate.Add(lesson.EndTime).ToString()},
                    {"starttime", lesson.StartTime.ToString() },
                    {"endtime", lesson.EndTime.ToString() },
                    { "amount", lesson.Amount },
                    { "userId",Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid },

                };

                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("lessons");
                collection.Add(new HashMap(lessonDocument));
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

                lessons.Clear();
                if (!snapshot.IsEmpty)
                {
                    var documents = snapshot.Documents;
                    lessons.Clear();

                    foreach (var item in documents)
                    {


                        lessons.Add(new Lesson()
                        {

                            StudentName = (string)item.Get("studentname"),
                            TeacherName = (string)item.Get("teachername"),
                            Instrument = (string)item.Get("instrument"),
                            StartDate = DateTime.Parse((string)item.Get("startdate")),
                            EndDate = DateTime.Parse((string)item.Get("enddate")),
                            //StartTime = TimeSpan.Parse("startdate"),
                            //EndTime = TimeSpan.Parse((string)item.Get("endtime")),
                            //StartTime = TimeSpan.Parse((string)item.Get("from")),
                            //EndTime = TimeSpan.Parse((string)item.Get("to")),
                            Amount = (string)item.Get("amount"),
                            UserId = (string)item.Get("userId"),
                            Id = item.Id,
                        });
                    }
                }
            }
            else
            {
                lessons.Clear();
            }
            hasReadLessons = true;
        }

        public async Task<List<Lesson>> Read()
        {
            try
            {
                hasReadLessons = false;
                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("lessons");
                var query = collection.WhereEqualTo("userId", Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid);
                query.Get().AddOnCompleteListener(this);

                for (int i = 0; i < 50; i++)
                {
                    await System.Threading.Tasks.Task.Delay(100);
                    if (hasReadLessons)
                        break;

                }
                return lessons;
            }
            catch (Exception ex)
            {
                return lessons;
            }
        }
    

        public Task<bool> Update(Lesson lesson)
        {
            try
            {
                var lessonDocument = new Dictionary<string, Java.Lang.Object>
                {
                    {"studentname", lesson.StudentName },
                    {"teachername",lesson.TeacherName },
                    {"instrument", lesson.Instrument },

                    { "startdate", lesson.StartDate.Add(lesson.StartTime).ToString()},
                    { "enddate", lesson.EndDate.Add(lesson.EndTime).ToString()},
                    {"starttime", lesson.StartTime.ToString() },
                    {"endtime", lesson.EndTime.ToString() },
                    { "amount", lesson.Amount },
                    { "userId",Firebase.Auth.FirebaseAuth.Instance.CurrentUser.Uid },

                };




                var collection = Firebase.Firestore.FirebaseFirestore.Instance.Collection("lessons");
                collection.Document(lesson.Id).Update(lessonDocument);

                return System.Threading.Tasks.Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return System.Threading.Tasks.Task.FromResult(false);
            }
        }
    }
}
