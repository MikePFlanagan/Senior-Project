using MusicAcademyCRM.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MusicAcademyCRM.Helpers
{
    public interface ITeacherFirestore
    {
        bool Insert(Teacher teacher);
        Task<bool> Delete(Teacher teacher);
        Task<bool> Update(Teacher teacher);
        Task<List<Teacher>> Read();
    }
    public class TeacherFirestore
    {

        private static ITeacherFirestore teacherfirestore = DependencyService.Get<ITeacherFirestore>();

        public static async Task<bool> Delete(Teacher teacher)
        {
            return await teacherfirestore.Delete(teacher);
        }

        public static bool Insert(Teacher teacher)
        {
            return teacherfirestore.Insert(teacher);
        }

        public static async Task<List<Teacher>> Read()
        {
            return await teacherfirestore.Read();
        }

        public static async Task<bool> Update(Teacher teacher)
        {
            return await teacherfirestore.Update(teacher);
        }
    }
}
