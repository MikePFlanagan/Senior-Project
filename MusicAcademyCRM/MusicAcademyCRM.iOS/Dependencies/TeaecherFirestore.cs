using MusicAcademyCRM.Model;
using MusicAcademyCRM.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Foundation;


[assembly: Dependency(typeof(MusicAcademyCRM.iOS.Dependencies.TeacherFirestore))]
namespace MusicAcademyCRM.iOS.Dependencies
{
    public class TeacherFirestore : ITeacherFirestore
    {
        public TeacherFirestore()
        {
        }

        public async Task<bool> Delete(Teacher teacher)
        {
            try
            {
                var collection = Firebase.CloudFirestore.Firestore.SharedInstance.GetCollection("teachers");
                await collection.GetDocument(teacher.Id).DeleteDocumentAsync();
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
                var keys = new[]
                {
                    new NSString("name"),
                    new NSString("phone"),
                    new NSString("email"),
                    new NSString("address"),
                    new NSString("city"),
                    new NSString("state"),
                    new NSString("zipcode"),
                    new NSString("company"),
                    new NSString("leadsource"),
                    new NSString("notes"),
                    new NSString("userId")
    };
                var values = new NSObject[]
                {
                    new NSString(teacher.Name),
                    new NSString(teacher.Phone),
                    new NSString(teacher.Email),
                    new NSString(teacher.Address),
                    new NSString(teacher.City),
                    new NSString(teacher.State),
                    new NSString(teacher.Zipcode),
                    new NSString(teacher.Company),
                    new NSString(teacher.Leadsource),
                    new NSString(teacher.Notes),
                    new NSString(Firebase.Auth.Auth.DefaultInstance.CurrentUser.Uid)
                };

                var document = new NSDictionary<NSString, NSObject>(keys, values);

                var collection = Firebase.CloudFirestore.Firestore.SharedInstance.GetCollection("teachers");
                collection.AddDocument(document);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        

        public async Task<List<Teacher>> Read()
        {
            try { 
            var collection = Firebase.CloudFirestore.Firestore.SharedInstance.GetCollection("teachers");
            var query = collection.WhereEqualsTo("userId", Firebase.Auth.Auth.DefaultInstance.CurrentUser.Uid);
            var documents = await query.GetDocumentsAsync();

            List<Teacher> teachers = new List<Teacher>();
            foreach (var doc in documents.Documents)
            {
                var dictionary = doc.Data;

                var newTeacher = new Teacher()
                {
                    Name = dictionary.ValueForKey(new NSString("name")) as NSString,
                    Phone = dictionary.ValueForKey(new NSString("phone")) as NSString,
                    Email = dictionary.ValueForKey(new NSString("email")) as NSString,
                    Address = dictionary.ValueForKey(new NSString("address")) as NSString,
                    City = dictionary.ValueForKey(new NSString("city")) as NSString,
                    State = dictionary.ValueForKey(new NSString("state")) as NSString,
                    Zipcode = dictionary.ValueForKey(new NSString("zipcode")) as NSString,
                    Company = dictionary.ValueForKey(new NSString("company")) as NSString,
                    Leadsource = dictionary.ValueForKey(new NSString("leadsource")) as NSString,
                    Notes = dictionary.ValueForKey(new NSString("notes")) as NSString,
                    UserId = dictionary.ValueForKey(new NSString("userId")) as NSString,
                    Id = doc.Id
                };
                teachers.Add(newTeacher);
            }
            return teachers;
        }
        catch(Exception ex)
        {
            return new List<Teacher>();
        }
    }

        public async Task<bool> Update(Teacher teacher)
        {
            try
            {
                var keys = new[]
                {
                    new NSString("name"),
                    new NSString("phone"),
                    new NSString("email"),
                    new NSString("address"),
                    new NSString("city"),
                    new NSString("state"),
                    new NSString("zipcode"),
                    new NSString("company"),
                    new NSString("leadsource"),
                    new NSString("notes"),
                    new NSString("userId")
                };

                var values = new NSObject[]
                {
                    new NSString(teacher.Name),                   
                    new NSString(teacher.Phone),
                    new NSString(teacher.Email),
                    new NSString(teacher.Address),
                    new NSString(teacher.City),
                    new NSString(teacher.State),
                    new NSString(teacher.Zipcode),
                    new NSString(teacher.Company),
                    new NSString(teacher.Leadsource),
                    new NSString(teacher.Notes),
                    new NSString(Firebase.Auth.Auth.DefaultInstance.CurrentUser.Uid)
                };

                var document = new NSDictionary<NSObject, NSObject>(keys, values);

                var collection = Firebase.CloudFirestore.Firestore.SharedInstance.GetCollection("teachers");
                await collection.GetDocument(teacher.Id).UpdateDataAsync(document);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

       

       
    }
}