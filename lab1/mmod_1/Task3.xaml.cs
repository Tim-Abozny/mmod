using System;
using System.Windows;

namespace mmod_1
{
    /// <summary>
    /// Interaction logic for Task3.xaml
    /// </summary>
    public partial class Task3 : Window
    {
        public Task3()
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
