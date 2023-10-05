using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Windows;

namespace mmod_1
{
    /// <summary>
    /// Interaction logic for Task4.xaml
    /// </summary>
    public partial class Task4 : Window
    {
        public static double myValue = 0;
        public Task4()
        {
            InitializeComponent();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            mySharedOwnWindow.window.Show();
            this.Close();
        }
        public static class ProbabilityBasedEventGenerator
        {
            static RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            public static int GenerateEventIndicator(List<double> probabilities)
            {
                byte[] randomBytes = new byte[4];
                rng.GetBytes(randomBytes);
                double randomValue = BitConverter.ToUInt32(randomBytes, 0) / (UInt32.MaxValue + 1.0);

                double cumulativeProbability = 0.0;

                for (int i = 0; i < probabilities.Count; i++)
                {
                    cumulativeProbability += probabilities[i];

                    if (randomValue < cumulativeProbability)
                    {
                        myValue = randomValue;
                        return i;
                    }
                }

                return probabilities.Count - 1; // Вернуть индикатор последнего события, если ничего другого не выбрано
            }

        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            probabilityListBox.Items.Add(probabilityTextBox.Text);
        }

        private void btn_ready_Click(object sender, RoutedEventArgs e)
        {
            List<double> probabilities = new List<double>();
            foreach (var item in probabilityListBox.Items)
            {
                probabilities.Add(double.Parse(item.ToString()));
            }
            indicatorTextBox.Text = ProbabilityBasedEventGenerator.GenerateEventIndicator(probabilities).ToString();
            valueTextBox.Text = myValue.ToString();
        }
    }
}
/*Индикатор возвращается из функции на основе вероятности каждого события и случайно сгенерированного числа.

Диапазоны для заданных вероятностей распределяются следующим образом:

1. Сначала создается случайное число `randomValue` в интервале [0, 1] с использованием `RNGCryptoServiceProvider`.

2. Затем начинается цикл, в котором происходит сравнение `randomValue` с кумулятивными вероятностями событий. Кумулятивные вероятности считаются, начиная с первого события.

3. Как только `randomValue` становится меньше кумулятивной вероятности для конкретного события, это событие выбирается как результат, и индикатор этого события возвращается. Это обеспечивает выбор события с учетом его вероятности.

Если `randomValue` находится в интервале [0, вероятность первого события), то возвращается индикатор первого события. Если `randomValue` находится в интервале [вероятность первого события, вероятность первого события + вероятность второго события), то возвращается индикатор второго события, и так далее.

Индикаторы выбираются случайным образом, но вероятность каждого события пропорциональна его заданной вероятности в списке `eventProbabilities`.*/