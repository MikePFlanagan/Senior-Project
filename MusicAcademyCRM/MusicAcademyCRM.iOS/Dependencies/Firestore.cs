using MusicAcademyCRM.Model;
using MusicAcademyCRM.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Foundation;


[assembly: Dependency(typeof(MusicAcademyCRM.iOS.Dependencies.Firestore))]
namespace MusicAcademyCRM.iOS.Dependencies
{
    public class Firestore : IFirestore
    {
        public Firestore()
        {

        }

        public async Task<bool> Delete(Student student)
        {
            try
            {
                var collection = Firebase.CloudFirestore.Firestore.SharedInstance.GetCollection("students");
                await collection.GetDocument(student.Id).DeleteDocumentAsync();
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
                var keys = new[]
                {
                    new NSString("name"),
                    new NSString("phone"),
                    new NSString("email"),
                    new NSString("address"),
                    new NSString("city"),
                    new NSString("state"),
                    new NSString("zipcode"),
                    new NSString("leadsource"),
                    new NSString("notes"),
                    new NSString("userId")
                };

                var values = new NSObject[]
                {
                    new NSString(student.Name),
                    new NSString(student.Phone),
                    new NSString(student.Email),
                    new NSString(student.Address),
                    new NSString(student.City),
                    new NSString(student.State),
                    new NSString(student.Zipcode),
                   
                    new NSString(student.Instruments),
                    new NSString(student.Notes),
                    new NSString(Firebase.Auth.Auth.DefaultInstance.CurrentUser.Uid)
                };

                var document = new NSDictionary<NSString, NSObject>(keys, values);

                //foreach (var item in document)
                //{
                //    if (item.Value.IsEqual(null))
                //        item.Value.Equals("");
                //}
                var collection = Firebase.CloudFirestore.Firestore.SharedInstance.GetCollection("students");
                collection.AddDocument(document);
                
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

                

        public async Task<List<Student>> Read()
        {
            try
            { 
                var collection = Firebase.CloudFirestore.Firestore.SharedInstance.GetCollection("students");
                var query = collection.WhereEqualsTo("userId", Firebase.Auth.Auth.DefaultInstance.CurrentUser.Uid);
                var documents = await query.GetDocumentsAsync();

                List<Student> students = new List<Student>();
                foreach (var doc in documents.Documents)
                {
                    var dictionary = doc.Data;

                    var newStudent = new Student()
                    {
                    Name = dictionary.ValueForKey(new NSString("name")) as NSString,
                    Phone = dictionary.ValueForKey(new NSString("phone")) as NSString,
                    Email = dictionary.ValueForKey(new NSString("email")) as NSString,
                    Address = dictionary.ValueForKey(new NSString("address")) as NSString,
                    City = dictionary.ValueForKey(new NSString("city")) as NSString,
                    State = dictionary.ValueForKey(new NSString("state")) as NSString,
                    Zipcode = dictionary.ValueForKey(new NSString("zipcode")) as NSString,                 
                    Instruments = dictionary.ValueForKey(new NSString("leadsource")) as NSString,
                    Notes = dictionary.ValueForKey(new NSString("notes")) as NSString,
                    UserId = dictionary.ValueForKey(new NSString("userId")) as NSString,
                    Id = doc.Id
                    };

                    students.Add(newStudent);
                }
                return students;
            }
            catch (Exception ex)
            {
                return new List<Student>();
            }
        }

        public async Task<bool> Update(Student student)
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
                    new NSString("leadsource"),
                    new NSString("notes"),
                    new NSString("userId")
                };

                var values = new NSObject[]
                {
                    new NSString(student.Name),                   
                    new NSString(student.Phone),
                    new NSString(student.Email),
                    new NSString(student.Address),
                    new NSString(student.City),
                    new NSString(student.State),
                    new NSString(student.Zipcode),                 
                    new NSString(student.Instruments),
                    new NSString(student.Notes),
                    new NSString(Firebase.Auth.Auth.DefaultInstance.CurrentUser.Uid)
                };

                var document = new NSDictionary<NSObject, NSObject>(keys, values);

                var collection = Firebase.CloudFirestore.Firestore.SharedInstance.GetCollection("students");
                await collection.GetDocument(student.Id).UpdateDataAsync(document);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }        
    }  
}