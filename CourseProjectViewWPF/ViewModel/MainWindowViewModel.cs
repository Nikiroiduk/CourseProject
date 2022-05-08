using CourseProjectBL.Enum;
using CourseProjectBL.Model;
using CourseProjectViewWPF.Commands;
using CourseProjectViewWPF.Services;
using System;
using System.Windows;
using System.Windows.Input;
using Action = CourseProjectBL.Actions.Action;
using System.Linq;
using CourseProjectBL;
using CourseProjectBL.Dictionary;
using CourseProjectBL.Services;
using System.Collections.Specialized;
using System.Windows.Data;
using System.ComponentModel;

using LiveCharts;
using LiveCharts.Wpf;

namespace CourseProjectViewWPF.ViewModel
{
    public class MainWindowViewModel : ViewModel
    {
        private User User { get; set; }

        private readonly DialogVisitor Visitor = new();

        private readonly DataServices DataService = new();
        public MainWindowViewModel(User User)
        {
            this.User = User;

            #region Commands
            CloseWindow = new LambdaCommand(OnCloseWindow, CanCloseWindow);
            MinimiseWindow = new LambdaCommand(OnMinimiseWindow, CanMinimiseWindow);
            FullScreenWindow = new LambdaCommand(OnFullScreenWindow, CanFullScreenWindow);
            AddNew = new LambdaCommand(OnAddNew, CanAddNew);
            RemoveItem = new LambdaCommand(OnRemoveItem, CanRemoveItem);
            ChangeItem = new LambdaCommand(OnChangeItem, CanChangeItem);
            #endregion

            Actions.CollectionChanged += Actions_CollectionChanged;
            DatePropertyChanged();
        }

        private void Actions_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            CalculateTotalValues();
            DataService.UpdateUserData(User);
        }

        #region Actions
        public ICollectionView Actions
        {
            get => CollectionViewSource.GetDefaultView(User.Actions);
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

        #region StartDate
        private DateTime _StartDate = DateTime.Now;
        public DateTime StartDate
        {
            get => _StartDate;
            set
            {
                Set(ref _StartDate, value);
                DatePropertyChanged();
            }
        }

        #endregion

        #region DatePropertyChanged
        private void DatePropertyChanged()
        {
            Actions.SortDescriptions.Add(new SortDescription("DateTime", ListSortDirection.Descending));
            Actions.Filter = item =>
            {
                Action action = item as Action;
                if (action == null) return false;
                return action.DateTime.Date >= StartDate.Date && action.DateTime.Date <= EndDate.Date;

            };
        }
        #endregion

        #region EndDate
        private DateTime _EndDate = DateTime.Now;
        public DateTime EndDate
        {
            get => _EndDate;
            set
            {
                Set(ref _EndDate, value);
                DatePropertyChanged();
            }
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
            TotalIncome = (from x in Actions.OfType<Action>() where x.ActionType == ActionType.Income select x.Amount).Sum();
            TotalExpense = (from x in Actions.OfType<Action>() where x.ActionType == ActionType.Expense select x.Amount).Sum();
            TotalSummary = TotalIncome - TotalExpense;
        }


        #region AddNew
        public ICommand AddNew { get; }

        private bool CanAddNew(object p) => true;
        private void OnAddNew(object p)
        {
            Action action = new();
            action = Visitor.DynamicVisit(action) as Action;
            if (action == null || action.Amount <= 0)
                return;
            User.Actions.Add(action);
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

        #region ChangeItem
        public ICommand ChangeItem { get; }

        private bool CanChangeItem(object p) => true;
        private void OnChangeItem(object p)
        {

            var action = p as Action;
            var index = User.Actions.IndexOf(action);
            action = Visitor.DynamicVisit(action) as Action;
            if (action == null || action.Amount <= 0)
                return;

            //TODO: ugh must be rewritten in some other way
            User.Actions.Insert(index, action);
            User.Actions.RemoveAt(index);
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
