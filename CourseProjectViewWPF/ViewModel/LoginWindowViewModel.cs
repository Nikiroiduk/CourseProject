using CourseProjectBL.Services;
using CourseProjectBL.Model;
using CourseProjectViewWPF.Commands;
using CourseProjectViewWPF.Services;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows;
using System.Security;

namespace CourseProjectViewWPF.ViewModel
{
    class LoginWindowViewModel : ViewModel, IDataErrorInfo
    {
        public LoginWindowViewModel()
        {
            #region Commands
            SignInClick = new LambdaCommand(OnSignInClick, CanSignInClick);
            SignUpClick = new LambdaCommand(OnSignUpClick, CanSignUpClick);
            CloseClick = new LambdaCommand(OnCloseClick, CanCloseClick);
            #endregion
        }

        #region Login
        private string _Login;
        [Required]
        public string Login
        {
            get => _Login;
            set => Set(ref _Login, value);
        }
        #endregion

        #region Password
        private string _Password;
        [Required]
        public string Password
        {
            get =>_Password;
            set => Set(ref _Password, value);
        }
        #endregion

        #region Name
        private string _Name;
        [Required]
        [RegularExpression(@"[a-zA-Z]+")]
        public string Name
        {
            get => _Name;
            set => Set(ref _Name, value);
        }
        #endregion

        #region ErrorMsg
        private string _ErrorMsg;
        public string ErrorMsg
        {
            get => _ErrorMsg;
            set => Set(ref _ErrorMsg, value);
        }
        #endregion

        #region Error
        public string this[string columnName]
        {
            get
            {
                var validationResults = new List<ValidationResult>();
                var property = GetType().GetProperty(columnName);

                var validationContext = new ValidationContext(this)
                {
                    MemberName = columnName
                };

                var isValid = Validator.TryValidateProperty(property.GetValue(this), validationContext, validationResults);
                if (isValid)
                {
                    return null;
                }
                return validationResults.First().ErrorMessage;
            }
        }
        public string Error
        {
            get
            {
                return "";
            }
        }
        #endregion

        #region CloseClick
        public ICommand CloseClick { get; }

        private bool CanCloseClick(object p) => true;
        private void OnCloseClick(object p)
        {
            CloseLoginWindow(p as Window);
        }


        #endregion

        #region SignInClick
        public ICommand SignInClick { get; }

        private bool CanSignInClick(object p) => true;
        private void OnSignInClick(object p)
        {
            if (string.IsNullOrEmpty(Login))
            {
                return;
            }
            if (string.IsNullOrEmpty(Password))
            {
                return;
            }

            var user = AuthService.Auth(Login, Password);
            if (user != null)
            {
                StartProgram(user);
                CloseLoginWindow(p as Window);
            }
            else
            {
                ErrorMsg = "Something went wrong";
            }
        }


        #endregion


        #region SignUpClick
        public ICommand SignUpClick { get; }

        private bool CanSignUpClick(object p) => true;
        private void OnSignUpClick(object p)
        {
            if (string.IsNullOrEmpty(Login))
            {
                return;
            }
            if (Password.Length < 1)
            {
                return;
            }
            if (string.IsNullOrEmpty(Name) && Regex.IsMatch(Name, @"[a-zA-Z]+"))
            {
                return;
            }
            var user = AuthService.Register(Name, Login, Password);
            if (user != null)
            {
                StartProgram(user);
                CloseLoginWindow(p as Window);
            }
            else
            {
                ErrorMsg = "Something went wrong";
            }
        }
        #endregion

        private static void StartProgram(User user)
        {
            WindowService windowService = new();
            windowService.CreateWindow(user);
        }
        private void CloseLoginWindow(Window window)
        {
            window.Close();
        }
    }
}
