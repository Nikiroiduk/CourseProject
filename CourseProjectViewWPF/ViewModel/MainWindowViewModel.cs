using CourseProjectBL.Model;
using CourseProjectViewWPF.Services;
using CourseProjectViewWPF.View;

namespace CourseProjectViewWPF.ViewModel
{
    public class MainWindowViewModel : ViewModel
    {
        private User User { get; set; }
        public MainWindowViewModel(User User)
        {
            this.User = User;

            #region Commands

            #endregion
        }
    }
}
