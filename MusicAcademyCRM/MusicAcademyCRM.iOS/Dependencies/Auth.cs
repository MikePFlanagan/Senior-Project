using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using MusicAcademyCRM.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(MusicAcademyCRM.iOS.Dependencies.Auth))]
namespace MusicAcademyCRM.iOS.Dependencies
{
   
    public class Auth : IAuth
    {
        private static IAuth auth = DependencyService.Get<IAuth>();
        public Auth()
        {
        }


        public async Task<bool> RegisterUser(string email, string password)
        {
            try
            {
                await Firebase.Auth.Auth.DefaultInstance.CreateUserAsync(email, password);
                return true;
            }
            catch (NSErrorException error)
            {
                string message = error.Message.Substring(error.Message.IndexOf("NSLocalizedDescription=", StringComparison.CurrentCulture));
                message = message.Replace("NSLocalizedDescription=", "").Split('.')[0];
                throw new Exception(message);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an unknown error.");
            }
        }

        public async Task<bool> LoginUser(string email, string password)
        {
            try
            {
                await Firebase.Auth.Auth.DefaultInstance.SignInWithPasswordAsync(email, password);
                return true;
            }
            catch(NSErrorException error)
            {
                string message = error.Message.Substring(error.Message.IndexOf("NSLocalizedDescription=", StringComparison.CurrentCulture));
                message = message.Replace("NSLocalizedDescription=", "").Split('.')[0];
                throw new Exception(message);                
            }
            catch(Exception ex)
            {
                throw new Exception("There was an unknown error.");               
            }
        }

        public bool IsAuthenticated()
        {
            return Firebase.Auth.Auth.DefaultInstance.CurrentUser != null;
        }

        public string GetCurrentUserId()
        {
            return Firebase.Auth.Auth.DefaultInstance.CurrentUser.Uid;
        }
    }
}
