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

        class EventGenerator
        {
            static Random random = new Random();

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
                double randomValue = random.NextDouble();
                if (randomValue < probabilityAB)
                {
                    return 0; // Событие AB
                }
                else if (randomValue < probabilityAB + probabilityAnotB)
                {
                    return 1; // Событие A!B
                }
                else if (randomValue < probabilityAB + probabilityAnotB + probabilityNotAB)
                {
                    return 2; // Событие !AB
                }
                else
                {
                    return 3; // Событие !A!B
                }
            }

              //double probabilityA = 0.3; // Замените на вашу вероятность P(A)
              //  double conditionalProbabilityBGivenA = 0.6; // Замените на вашу условную вероятность P(B|A)

              //  int eventIndicator = SimulateComplexEvent(probabilityA, conditionalProbabilityBGivenA);

              //  Console.WriteLine("Индикатор события: " + eventIndicator); 
        }
    }
}
