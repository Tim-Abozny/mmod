using System;
using System.Windows;

namespace mmod_1
{
    /// <summary>
    /// Interaction logic for Task2.xaml
    /// </summary>
    public partial class Task2 : Window
    {
        public Task2()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            mySharedOwnWindow.window.Show();
            this.Close();
        }
    }
}
