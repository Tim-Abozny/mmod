using System;
using System.Security.Cryptography;
using System.Windows;
using System.Collections.Generic;

namespace mmod_1
{
    /// <summary>
    /// Interaction logic for Task3.xaml
    /// </summary>
    public partial class Task3 : Window
    {
        public static List<double> pAB = new List<double>();
        public static List<double> pAnotB = new List<double>();
        public static List<double> pnotAB = new List<double>();
        public static List<double> pnotAnotB = new List<double>();

        public static int pABCounter = 0;
        public static int pAnotBCounter = 0;
        public static int pnotABCounter = 0;
        public static int pnotAnotBCounter = 0;

        public Task3()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            mySharedOwnWindow.window.Show();
            this.Close();
        }
        public static class EventGenerator
        {
            static RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

            public static int SimulateComplexEvent(double probabilityA, double conditionalProbabilityBGivenA)
            {
                // Вычисляем P(!A) и P(B|!A)
                double probabilityNotA = 1 - probabilityA;
                double conditionalProbabilityBGivenNotA = 1 - conditionalProbabilityBGivenA;

                // Вычисляем P(AB), P(A!B), P(!AB), P(!A!B) с использованием формулы полной вероятности
                double probabilityAB = probabilityA * conditionalProbabilityBGivenA;
                double probabilityAnotB = probabilityA * (1 - conditionalProbabilityBGivenA);
                double probabilityNotAB = probabilityNotA * conditionalProbabilityBGivenNotA;
                double probabilityNotAnotB = probabilityNotA * (1 - conditionalProbabilityBGivenNotA);

                // Генерируем случайное число для определения события
                byte[] randomBytes = new byte[4];
                rng.GetBytes(randomBytes);
                double randomValue = BitConverter.ToUInt32(randomBytes, 0) / (UInt32.MaxValue + 1.0);

                if (randomValue < probabilityAB)
                {
                    pABCounter++;
                    pAB.Add(randomValue);
                    return 0; // Событие AB
                }
                else if (randomValue < probabilityAB + probabilityAnotB)
                {
                    pAnotBCounter++;
                    pAnotB.Add(randomValue);
                    return 1; // Событие A!B
                }
                else if (randomValue < probabilityAB + probabilityAnotB + probabilityNotAB)
                {
                    pnotABCounter++;
                    pnotAB.Add(randomValue);
                    return 2; // Событие !AB
                }
                else
                {
                    pnotAnotBCounter++;
                    pnotAnotB.Add(randomValue);
                    return 3; // Событие !A!B
                }
            }


        }

        private void btn_ready_Click(object sender, RoutedEventArgs e)
        {
            p1_abList.Items.Clear();
            p2_abList.Items.Clear();
            p3_abList.Items.Clear();
            p4_abList.Items.Clear();

            double probability = double.Parse(probabilityTextBox.Text);
            double condProb = double.Parse(probabilityTextBox.Text);

            indicatorTextBox.Text = EventGenerator.SimulateComplexEvent(probability, condProb).ToString();

            for (int i = 0; i < 999999; i++)
            {
                EventGenerator.SimulateComplexEvent(probability, condProb).ToString();
            }

            for (int i = 0; i < pAB.Count; i++)
            {
                p1_abList.Items.Add(pAB[i]);
            }
            
            for (int i = 0; i < pAnotB.Count; i++)
            {
                p2_abList.Items.Add(pAnotB[i]);
            }
            
            for (int i = 0; i < pnotAB.Count; i++)
            {
                p3_abList.Items.Add(pnotAB[i]);
            }
            
            for (int i = 0; i < pnotAnotB.Count; i++)
            {
                p4_abList.Items.Add(pnotAnotB[i]);
            }

            p1_abList.Items.Add(pABCounter);
            p2_abList.Items.Add(pAnotBCounter);
            p3_abList.Items.Add(pnotABCounter);
            p4_abList.Items.Add(pnotAnotBCounter);

            pABCounter = 0;
            pAnotBCounter = 0;
            pnotABCounter = 0;
            pnotAnotBCounter = 0;

            pAB.Clear();
            pAnotB.Clear();
            pnotAB.Clear();
            pnotAnotB.Clear();
        }
    }
}
