using CourseProjectBL.Model;
using CourseProjectViewWPF.Commands;
using CourseProjectViewWPF.Services;
using CourseProjectViewWPF.View;
using System.Windows;
using System.Windows.Input;

namespace CourseProjectViewWPF.ViewModel
{
    public class MainWindowViewModel : ViewModel
    {
        private User User { get; set; }
        public MainWindowViewModel(User User)
        {
            this.User = User;

            #region Commands
            CloseWindow = new LambdaCommand(OnCloseWindow, CanCloseWindow);
            MinimiseWindow = new LambdaCommand(OnMinimiseWindow, CanMinimiseWindow);
            FullScreenWindow = new LambdaCommand(OnFullScreenWindow, CanFullScreenWindow);
            #endregion
        }


        #region CloseWindow
        public ICommand CloseWindow { get; }

        private bool CanCloseWindow(object p) => true;
        private void OnCloseWindow(object p)
        {
            var win = p as Window;
            win.Close();
        }
        #endregion

        #region WindowState
        private WindowState _WindowState;
        public WindowState WindowState
        {
            get => _WindowState;
            set => Set(ref _WindowState, value);
        }
        #endregion

        #region MinimiseWindow
        public ICommand MinimiseWindow { get; }

        private bool CanMinimiseWindow(object p) => true;
        private void OnMinimiseWindow(object p)
        {
            WindowState = WindowState.Minimized;
        }
        #endregion

        #region FullScreenWindow
        public ICommand FullScreenWindow { get; }

        private bool CanFullScreenWindow(object p) => true;
        private void OnFullScreenWindow(object p)
        {
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }
        #endregion

    }
}
