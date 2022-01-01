using MusicAcademyCRM.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MusicAcademyCRM.Helpers
{
    public interface IFirestore
    {
        bool Insert(Student student);
        Task<bool> Delete(Student student);
        Task<bool> Update(Student student);
        Task<List<Student>> Read();
    }
    public class Firestore
    {

        private static IFirestore firestore = DependencyService.Get<IFirestore>();

        public static async Task<bool> Delete(Student student)
        {
            return await firestore.Delete(student);
        }

        public static bool Insert(Student student)
        {
            return firestore.Insert(student);
        }

        public static async Task<List<Student>> Read()
        {
            return await firestore.Read();
        }

        public static async Task<bool> Update(Student student)
        {
            return await firestore.Update(student);
        }
    }
}
