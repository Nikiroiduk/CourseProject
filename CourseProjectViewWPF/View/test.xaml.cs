using System;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;

namespace CourseProjectViewWPF.View
{
    /// <summary>
    /// Interaction logic for MaterialCards.xaml
    /// </summary>
    public partial class test : Window //INotifyPropertyChanged
    {
        private double _lastLecture;

        public test()
        {
            InitializeComponent();

            LastHourSeries = new SeriesCollection
            {
                new LineSeries
                {
                    AreaLimit = -10,
                    Values = new ChartValues<ObservableValue>
                    {
                        new ObservableValue(3),
                        new ObservableValue(5),
                        new ObservableValue(6),
                        new ObservableValue(7),
                        new ObservableValue(3),
                        new ObservableValue(4),
                        new ObservableValue(2),
                        new ObservableValue(5),
                        new ObservableValue(8),
                        new ObservableValue(3),
                        new ObservableValue(5),
                        new ObservableValue(6),
                        new ObservableValue(7),
                        new ObservableValue(3),
                        new ObservableValue(4),
                        new ObservableValue(2),
                        new ObservableValue(5),
                        new ObservableValue(8)
                    }
                }
            };

            DataContext = this;
        }

        public SeriesCollection LastHourSeries { get; set; }

        public double LastLecture
        {
            get { return _lastLecture; }
            set
            {
                _lastLecture = value;
                //OnPropertyChanged("LastLecture");
            }
        }

        ////public event PropertyChangedEventHandler PropertyChanged;

        ////protected virtual void OnPropertyChanged(string propertyName = null)
        ////{
        ////    var handler = PropertyChanged;
        ////    if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        ////}

        private void UpdateOnclick(object sender, RoutedEventArgs e)
        {
            TimePowerChart.Update(true);
        }
    }
}