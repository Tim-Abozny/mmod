using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace mmod_1
{
    /// <summary>
    /// Interaction logic for Task1.xaml
    /// </summary>
    public partial class Task1 : Window
    {
        public class RandomNumberGenerator
        {
            public Random random = new Random();
            public double GenerateEvent(double probability, int N, ListBox answersList)
            {
                List<string> myList = new List<string>();

                int eventOccurred = 0;
                double tempDouble;
                for (int i = 0; i < N; i++)
                {
                    tempDouble = random.NextDouble();
                    if (tempDouble <= probability)
                    {
                        eventOccurred++;
                        myList.Add(tempDouble.ToString() + "\t\t" + "True");
                    }
                    else
                    {
                        myList.Add(tempDouble.ToString() + "\t\t" + "False");
                    }
                }
                myList.Add("How many True values:\t" + eventOccurred.ToString());
                double empiricalProbability = (double)eventOccurred / N;
                foreach (var item in myList)
                {
                    answersList.Items.Add(item);
                }
                myList = null;
                return empiricalProbability;
            }
        }

        public Task1()
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
            RandomNumberGenerator generator = new RandomNumberGenerator();
            answersList.Items.Clear();
            double probability = Double.Parse(probabilityTextBox.Text);
            int N = (int)Math.Pow(10, 6);
            double empiricalProbability = generator.GenerateEvent(probability, N, answersList);
            probabilityRealTextBox.Text = empiricalProbability.ToString();
            answersList.Items.Add("Здесь могла быть ваша реклама");
        }
    }
}
#region Пояснение к лабе
    /*Суть метода Монте-Карло для оценки вероятности события:

    Сгенерировать N случайных чисел равномерно распределенных 
    в интервале [0, 1]. Это можно сделать, например, с помощью 
    генератора случайных чисел.

    Для каждого сгенерированного числа проверить, меньше ли оно 
    заданной вероятности (порога). Если сгенерированное число меньше
    вероятности, то считать, что событие произошло (True); в
    противном случае, считать, что событие не произошло (False).

    Подсчитать количество True и False среди сгенерированных значений.

    Оценить частоту выпадения события, поделив количество True
    на общее количество сгенерированных значений.

    Теоретический расчет вероятности события:

    Если вероятность события равна P, то теоретически вероятность
    события произойти равна P. Таким образом, теоретическая вероятность 
    события равна заданной вероятности P.

    Итак, для каждого сгенерированного числа, если оно меньше или равно P,
    то возвращаем True, иначе возвращаем False. После генерации N = 10^6 значений,
    подсчитываем количество True и False и сравниваем с теоретическим значением P.*/
#endregion