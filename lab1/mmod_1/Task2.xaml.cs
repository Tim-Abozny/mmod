using System;
using System.Windows;
using System.Windows.Controls;

namespace mmod_1
{
    /// <summary>
    /// Interaction logic for Task2.xaml
    /// </summary>
    public partial class Task2 : Window
    {
        public static int TrueCounter = 0;
        public class RandomNumberGenerator
        {
            public Random random = new Random();
            public void GenerateEvent(double probability, ListBox answersList)
            {
                double tempDouble = random.NextDouble();

                if (tempDouble <= probability)
                {
                    answersList.Items.Add(tempDouble.ToString() + "\t\t" + "True");
                    TrueCounter++;
                }
                else
                {
                    answersList.Items.Add(tempDouble.ToString() + "\t\t" + "False");
                }
            }
        }

        public Task2()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            mySharedOwnWindow.window.Show();
            this.Close();
        }

        private void btn_ready_Click(object sender, RoutedEventArgs e)
        {
            answerListBox.Items.Clear();
            TrueCounter = 0;
            RandomNumberGenerator generator = new RandomNumberGenerator();
            foreach (var item in probabilityListBox.Items)
            {
                generator.GenerateEvent(double.Parse(item.ToString()), answerListBox);
            }
            answerListBox.Items.Add("How many True values:\t" + TrueCounter);
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            probabilityListBox.Items.Add(probabilityTextBox.Text);
        }
    }
}
