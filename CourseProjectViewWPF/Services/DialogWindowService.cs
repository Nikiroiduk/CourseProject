using System.Windows;

namespace CourseProjectViewWPF.Services
{
    public class DialogWindowService : IWindowService
    {
        public void showWindow(object viewModel)
        {
            var win = new Window();
            win.Content = viewModel;
            win.ShowDialog();
        }
    }
}
