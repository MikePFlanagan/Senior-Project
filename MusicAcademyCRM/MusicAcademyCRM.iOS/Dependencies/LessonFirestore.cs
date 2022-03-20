using MusicAcademyCRM.Model;
using MusicAcademyCRM.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Foundation;


[assembly: Dependency(typeof(MusicAcademyCRM.iOS.Dependencies.LessonFirestore))]
namespace MusicAcademyCRM.iOS.Dependencies
{
    public class LessonFirestore : ILessonFirestore
    {
        

        public LessonFirestore()
        {
            
        }

        public async Task<bool> Delete(Lesson lesson)
        {
            try
            {
                var collection = Firebase.CloudFirestore.Firestore.SharedInstance.GetCollection("lessons");
                await collection.GetDocument(lesson.Id).DeleteDocumentAsync();
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
                var keys = new []
                {
                    new NSString("studentname"),
                    new NSString("teachername"),
                    new NSString("instrument"),
                    new NSString("startdate"),
                    new NSString("enddate"),
                    new NSString("starttime"),
                    new NSString("endtime"),
                    new NSString("amount"),
                    new NSString("userId")
                   
                };
                var values = new NSObject[]
                {
                    new NSString(lesson.StudentName),
                    new NSString(lesson.TeacherName),
                    new NSString(lesson.Instrument),
                    new NSString(DateTimeToNSDate(lesson.StartDate).ToString()),
                    new NSString(DateTimeToNSDate(lesson.EndDate).ToString()),
                    new NSString(lesson.StartTime.ToString()),
                    new NSString(lesson.EndTime.ToString()),
                    new NSString(lesson.Amount),
                    new NSString(lesson.UserId),
                    new NSString(Firebase.Auth.Auth.DefaultInstance.CurrentUser.Uid)
                };

                var document = new NSDictionary<NSString, NSObject>(keys, values);

                var collection = Firebase.CloudFirestore.Firestore.SharedInstance.GetCollection("lessons");
                collection.AddDocument(document);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

         
        public static DateTime NSDateToDateTime(NSDate date)
        {
            DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(
                new DateTime(2001, 1, 1, 0, 0, 0));
            return reference.AddSeconds(date.SecondsSinceReferenceDate);
        }

      
        public static NSDate DateTimeToNSDate(DateTime date)
        {
            DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(
                new DateTime(2001, 1, 1, 0, 0, 0));
            return NSDate.FromTimeIntervalSinceReferenceDate(
                (date - reference).TotalSeconds);
        }

        



        public async Task<List<Lesson>> Read()
        {
            try { 
            var collection = Firebase.CloudFirestore.Firestore.SharedInstance.GetCollection("lessons");
            var query = collection.WhereEqualsTo("userId", Firebase.Auth.Auth.DefaultInstance.CurrentUser.Uid);
            var documents = await query.GetDocumentsAsync();

            List<Lesson> lessons = new List<Lesson>();
            foreach (var doc in documents.Documents)
            {
                var dictionary = doc.Data;

                var newLesson = new Lesson()
                {
                    StudentName = dictionary.ValueForKey(new NSString("studentname")) as NSString,
                    TeacherName = dictionary.ValueForKey(new NSString("teachername")) as NSString,
                    Instrument = dictionary.ValueForKey(new NSString("instrument")) as NSString,
                    //StartDate = (DateTime)(dictionary.ValueForKey(new NSString("startdate")) as NSDate),                   
                    //EndDate = (DateTime)(dictionary.ValueForKey(new NSString("enddate"))as NSDate),
                    StartDate = NSDateToDateTime(dictionary.ValueForKey(new NSString("startdate")) as NSDate),
                    EndDate = NSDateToDateTime(dictionary.ValueForKey(new NSString("enddate")) as NSDate),
                    
                    Amount = dictionary.ValueForKey(new NSString("amount")) as NSString,
                    UserId = dictionary.ValueForKey(new NSString("userId")) as NSString,
                    Id = doc.Id
                };
                lessons.Add(newLesson);
            }
            return lessons;
        }
        catch(Exception ex)
        {
            return new List<Lesson>();
        }
    }

        public async Task<bool> Update(Lesson lesson)
        {
            try
            {
                var keys = new[]
                {
                    new NSString("studentname"),
                    new NSString("teachername"),
                    new NSString("instrument"),
                    new NSString("startdate"),
                    new NSString("enddate"),
                    //new NSString("from"),
                    //new NSString("to"),
                    new NSString("amount"),
                    new NSString("userId"),

                };

                var values = new NSObject[]
                {
                    new NSString(lesson.StudentName),                   
                    new NSString(lesson.TeacherName),
                    new NSString(lesson.Instrument),
                    new NSString(lesson.StartTime.ToString()),
                    new NSString(lesson.EndDate.ToString()),
                    //new NSString(lesson.StartDate.Add(lesson.From).ToString()),
                    //new NSString(lesson.EndDate.Add(lesson.To).ToString()),
                    new NSString(lesson.Amount),
                    new NSString(Firebase.Auth.Auth.DefaultInstance.CurrentUser.Uid)
                };

                var document = new NSDictionary<NSObject, NSObject>(keys, values);

                var collection = Firebase.CloudFirestore.Firestore.SharedInstance.GetCollection("lessons");
                await collection.GetDocument(lesson.Id).UpdateDataAsync(document);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

       

       
    }
}