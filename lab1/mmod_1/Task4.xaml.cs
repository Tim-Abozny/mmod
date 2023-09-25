using System;
using System.Windows;

namespace mmod_1
{
    /// <summary>
    /// Interaction logic for Task4.xaml
    /// </summary>
    public partial class Task4 : Window
    {
        public Task4()
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
