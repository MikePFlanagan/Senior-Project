using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;
using MusicAcademyCRM.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof(MusicAcademyCRM.Droid.Dependencies.Auth))]
namespace MusicAcademyCRM.Droid.Dependencies
{
    public class Auth : IAuth
    {
        public Auth()
        {
        }

        public string GetCurrentUserId()
        {
            return FirebaseAuth.Instance.CurrentUser.Uid;
        }

        public bool IsAuthenticated()
        {
            return FirebaseAuth.Instance.CurrentUser != null;
        }

        public async Task<bool> LoginUser(string email, string password)
        {
            try
            {
                await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);

                return true;
            }
            catch (FirebaseAuthWeakPasswordException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (FirebaseAuthInvalidCredentialsException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (FirebaseAuthInvalidUserException ex)
            {
                throw new Exception("There is no user record corresponding to this identifier");
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("There was an unknown error.");
            }
        }

        public async Task<bool> RegisterUser(string email, string password)
        {
            try
            {
                await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);

                return true;
            }
            catch (FirebaseAuthWeakPasswordException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (FirebaseAuthInvalidCredentialsException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (FirebaseAuthUserCollisionException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("There was an unknown error.");
            }
        }
    }
}


//    public class Auth : IAuth
//    {
//        private static IAuth auth = DependencyService.Get<IAuth>();
//        public Auth()
//        {
//        }

//        public bool IsAuthenticated()
//        {
//            return FirebaseAuth.Instance.CurrentUser != null;
//        }

//        public string GetCurrentUserId()
//        {
//            return FirebaseAuth.Instance.CurrentUser.Uid;
//        }

//        public async Task<bool> RegisterUser(string email, string password)
//        {
//            try
//            {
//                await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
//                return true;
//            }
//            catch (FirebaseAuthWeakPasswordException ex)
//            {
//                throw new Exception(ex.Message);
//            }
//            catch (FirebaseAuthInvalidCredentialsException ex)
//            {
//                throw new Exception(ex.Message);
//            }
//            catch (FirebaseAuthUserCollisionException ex)
//            {
//                throw new Exception(ex.Message);
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("There was an unknown error.");
//            }
//        }


//        public async Task<bool> LoginUser(string email, string password)
//        {
//            try
//            {
//                await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
//                return true;
//            }
//            catch (FirebaseAuthWeakPasswordException ex)
//            {
//                throw new Exception(ex.Message);
//            }
//            catch (FirebaseAuthInvalidCredentialsException ex)
//            {
//                throw new Exception(ex.Message);
//            }
//            catch (FirebaseAuthInvalidUserException ex)
//            {
//                throw new Exception("There is no user record corresponding to this identifier");
//            }
//            catch (Exception ex)
//            {
//                throw new Exception("There was an unknown error.");
//            }
//        }
//    }
//}
