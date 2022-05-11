using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace CourseProjectViewWPF.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                DragMove();
        }

        private void Window_ContentRendered(object sender, System.EventArgs e)
        {
            ChartTest.Update();
            IncomePieChart.Update();
            ExpensePieChart.Update();
        }
    }
}
