
using CourseProjectBL.Model;
using System.Security;

namespace CourseProjectBL.Services
{
    public static class AuthService
    {

        public static bool ContainsLogin(string Login)
        {
            DataServices dataServices = new();
            return dataServices.GetUserByLogin(Login) != null;
        }

        public static User? Register(string Name, string Login, string Password)
        {
            DataServices dataServices = new();
            if (dataServices.GetUserByLogin(Login) != null)
            {
                return Auth(Login, Password);
            }
            return dataServices.AddNewUser(Name, Login, Password);
        }

        public static User? Auth(string Login, string Password)
        {
            DataServices dataServices = new();
            var user = dataServices.GetUserByLogin(Login);
            if (user != null)
            {
                if (PasswordService.ComparePassword(user.Password, Password))
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
