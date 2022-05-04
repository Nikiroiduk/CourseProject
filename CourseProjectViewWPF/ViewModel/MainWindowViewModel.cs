using CourseProjectBL.Enum;
using CourseProjectBL.Model;
using CourseProjectViewWPF.Commands;
using CourseProjectViewWPF.Services;
using CourseProjectViewWPF.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Action = CourseProjectBL.Actions.Action;

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
            AddNew = new LambdaCommand(OnAddNew, CanAddNew);
            RemoveItem = new LambdaCommand(OnRemoveItem, CanRemoveItem);
            #endregion


            //test data
            User.Actions.Add(new Action(ActionType.Income, DateTime.UtcNow, Account.Cash, Category.Food, 150, "Buy some food for week"));
            User.Actions.Add(new Action(ActionType.Expense, DateTime.UtcNow, Account.Cash, Category.Food, 200));
            User.Actions.Add(new Action(ActionType.Expense, DateTime.UtcNow, Account.Cash, Category.Food, 10));
            User.Actions.Add(new Action(ActionType.Income, DateTime.UtcNow, Account.Cash, Category.Food, 300));
            User.Actions.Add(new Action(ActionType.Income, DateTime.UtcNow, Account.Cash, Category.Food, 200));
        }

        #region Actions
        public ObservableCollection<Action> Actions
        {
            get => User.Actions;
        }
        #endregion

        #region ActionTypeImage
        private string _ActionTypeImage;
        public string ActionTypeImage
        {
            get => _ActionTypeImage;
            set => Set(ref _ActionTypeImage, value);
        }
        #endregion


        #region AddNew
        public ICommand AddNew { get; }

        private bool CanAddNew(object p) => true;
        private void OnAddNew(object p)
        {
            //TODO: Add new action
            User.Actions.Add(new Action(ActionType.Income, DateTime.UtcNow, Account.Cash, Category.Culture, 200));
        }
        #endregion

        #region RemoveItem
        public ICommand RemoveItem { get; }

        private bool CanRemoveItem(object p) => true;
        private void OnRemoveItem(object p)
        {
            var tmp = p as Action;
            if (tmp != null)
                User.Actions.Remove(tmp);
        }
        #endregion


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
