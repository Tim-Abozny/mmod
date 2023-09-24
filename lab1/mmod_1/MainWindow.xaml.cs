using System.Windows;

namespace mmod_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            mySharedOwnWindow.window = this;
        }

        private void btn_task1_Click(object sender, RoutedEventArgs e)
        {
            Task1 task1 = new Task1();
            task1.Show();
            this.Hide();
        }

        private void btn_task2_Click(object sender, RoutedEventArgs e)
        {
            Task2 task2 = new Task2();
            task2.Show();
            this.Hide();
        }

        private void btn_task3_Click(object sender, RoutedEventArgs e)
        {
            Task3 task3 = new Task3();
            task3.Show();
            this.Hide();
        }

        private void btn_task4_Click(object sender, RoutedEventArgs e)
        {
            Task4 task4 = new Task4();
            task4.Show();
            this.Hide();
        }

        private void myOwnWindow_Closed(object sender, System.EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
    public static class mySharedOwnWindow
    {
        public static MainWindow window = new MainWindow();
    }
}
