using CourseProjectBL.Model;
using CourseProjectBL.Services;
using CourseProjectViewWPF.Services;
using CourseProjectViewWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CourseProjectViewWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            LoginWindowViewModel loginWindowViewModel = new();
            loginWindowViewModel.Login = "Nikiroiduk";
            loginWindowViewModel.Password = "k.lbr040880";
            var user = AuthService.Auth(loginWindowViewModel.Login, loginWindowViewModel.Password);
            WindowService windowService = new();
            windowService.CreateWindow(user);
        }
    }
}
