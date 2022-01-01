using MusicAcademyCRM.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MusicAcademyCRM.Helpers
{
    public interface ILessonFirestore
    {
        bool Insert(Lesson lesson);
        Task<bool> Delete(Lesson lesson);
        Task<bool> Update(Lesson lesson);
        Task<List<Lesson>> Read();
    }
    public class LessonFirestore
    {

        private static ILessonFirestore firestore = DependencyService.Get<ILessonFirestore>();

        public static async Task<bool> Delete(Lesson lesson)
        {
            return await firestore.Delete(lesson);
        }

        public static bool Insert(Lesson lesson)
        {
            return firestore.Insert(lesson);
        }

        public static async Task<List<Lesson>> Read()
        {
            return await firestore.Read();
        }

        public static async Task<bool> Update(Lesson lesson)
        {
            return await firestore.Update(lesson);
        }
    }
}
