using CourseProjectBL.Enum;
using CourseProjectBL.Model;
using CourseProjectViewWPF.Commands;
using CourseProjectViewWPF.Services;
using CourseProjectViewWPF.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Action = CourseProjectBL.Actions.Action;
using System.Linq;
using CourseProjectBL;
using CourseProjectBL.Dictionary;
using System.Collections.Specialized;

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

            Actions.CollectionChanged += Actions_CollectionChanged;

            //test data
            User.Actions.Add(new Action(ActionType.Income, DateTime.UtcNow, Account.Cash, Category.Food, 150, "Buy some food for week"));
            User.Actions.Add(new Action(ActionType.Expense, DateTime.UtcNow, Account.Cash, Category.Food, 200));
            User.Actions.Add(new Action(ActionType.Expense, DateTime.UtcNow, Account.Cash, Category.Food, 10));
            User.Actions.Add(new Action(ActionType.Income, DateTime.UtcNow, Account.Cash, Category.Food, 300));
            User.Actions.Add(new Action(ActionType.Income, DateTime.UtcNow, Account.Cash, Category.Food, 200));
        }

        private void Actions_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CalculateTotalValues();
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
        }
        #endregion


        #region TotalIncome
        private double _TotalIncome;
        public double TotalIncome
        {
            get => _TotalIncome;
            set => Set(ref _TotalIncome, value);
        }
        #endregion

        #region TotalExpense
        private double _TotalExpense;
        public double TotalExpense
        {
            get => _TotalExpense;
            set => Set(ref _TotalExpense, value);
        }
        #endregion

        #region TotalSummary
        private double _TotalSummary;
        public double TotalSummary
        {
            get => _TotalSummary;
            set => Set(ref _TotalSummary, value);
        }
        #endregion

        #region CurrencySymbol;
        public string CurrencySymbol
        {
            get => CurrencyDictionary.currencySymbolsDictionary[Settings.MainCurrency];
            // TODO: Update when mainCurrency changed
        }
        #endregion

        private void CalculateTotalValues()
        {
            TotalIncome = (from x in User.Actions where x.ActionType == ActionType.Income select x.Amount).Sum();
            TotalExpense = (from x in User.Actions where x.ActionType == ActionType.Expense select x.Amount).Sum();
            TotalSummary = TotalIncome - TotalExpense;
        }


        #region AddNew
        public ICommand AddNew { get; }

        private bool CanAddNew(object p) => true;
        private void OnAddNew(object p)
        {
            //TODO: Add new action
            User.Actions.Add(new Action(ActionType.Expense, DateTime.UtcNow, Account.Cash, Category.Culture, 200.11));
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
