using CourseProjectBL.Services;
using CourseProjectViewWPF.Model.Commands;
using System.ComponentModel;
using System.Windows.Input;

namespace CourseProjectViewWPF.ViewModel
{
    class LoginWindowViewModel : ViewModel, IDataErrorInfo
    {
        public LoginWindowViewModel()
        {
            #region Commands
            LoginClick = new LambdaCommand(OnLoginClick, CanLoginClick);
            #endregion
        }


        #region ClassicSize
        private bool _ClassicSize = true;

        public bool ClassicSize
        {
            get => _ClassicSize;
            set => Set(ref _ClassicSize, value);
        }
        #endregion

        #region Login
        private string _Login;
        public string Login
        {
            get => _Login;
            set => Set(ref _Login, value);
        }
        #endregion

        #region Password
        private string _Password;
        public string Password
        {
            get => _Password;
            set => Set(ref _Password, value);
        }
        #endregion

        #region ButtonContent
        private string _ButtonContent = "Sign In";
        public string ButtonContent
        {
            get => _ButtonContent;
            set => Set(ref _ButtonContent, value);
        }
        #endregion


        #region Error
        public string this[string columnName]
        {
            get
            {
                if (columnName == "Login")
                {
                    if (string.IsNullOrWhiteSpace(Login)) return "Login can't be null or white space";
                }
                if (columnName == "Password")
                {
                    if (string.IsNullOrWhiteSpace(Login)) return "Password can't be null or white space";
                }
                return null;
            }
        }
        public string Error
        {
            get
            {
                return null;
            }
        }
        #endregion

        #region LoginClick
        public ICommand LoginClick { get; }

        private bool CanLoginClick(object p) => true;
        private void OnLoginClick(object p)
        {
            var user = AuthService.Auth(Login, Password);
            //if (ButtonContent == "Sign Up") 
            //{
            //    var newUser = AuthService.Register(Login, Password);
            //}
            if (user != null)
            {
                //TODO: Open main window
            }
            else
            {
                ButtonContent = "Sign Up";
                //TODO: Register new user
            }
        }
        #endregion
    }
}
