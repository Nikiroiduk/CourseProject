using CourseProjectBL;
using CourseProjectBL.Model;
using CourseProjectViewWPF.View;
using CourseProjectViewWPF.ViewModel;
using System;
using System.Windows;

namespace CourseProjectViewWPF.Services
{
    public class WindowService : IWindowService
    {
        public void CreateWindow(object user)
        {
            MainWindow win = new();
            var User = user as User;
            MainWindowViewModel winVm = new(User);
            win.DataContext = winVm;
            win.Show();
        }
    }
}
