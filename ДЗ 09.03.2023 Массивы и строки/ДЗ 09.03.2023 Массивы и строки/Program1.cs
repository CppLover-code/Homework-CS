using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ДЗ_09._03._2023_Массивы_и_строки
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Задание 1. Работа с 1d и 2d массивами");

            double[] A = new double[5];                         // 1d массив вещественных чисел
            double[,] B = new double[3, 4];                      // 2d масиив вещественных чисел

            Console.WriteLine("\n Введите 5 чисел для заполнения 1d массива:");

            for (int i = 0; i < A.Length; i++)                  // заполнение 1d массива с клавы
                A[i] = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\n 1d массив: ");                  // вывод 1d массива

            foreach (double i in A)
                Console.Write(i + "\t");
            Console.WriteLine();

            Random rnd = new Random();                                  // создаем объект для генерации чисел

            for (int i = 0; i < 3; i++)                                 // заполнение 2d массива рандомом
                for (int j = 0; j < 4; j++)
                    B[i, j] = i + j + 1 + Math.Round(rnd.NextDouble(), 1);  // записываем в массив случайное число

            Console.WriteLine("\n 2d массив: ");

            for (int i = 0; i < 3; i++)                         // вывод 2d массива в виде матрицы
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(B[i, j] + "\t");
                }
                Console.WriteLine();
            }

            double sum = A.Sum();   // общая сумма всех элементов 1d и 2d (ниже суммируем еще и эл. 2d массива) 
            double product = 1;     // общее произведение всех элементов 1d и 2d

            //////////////////////////////////////////////////////////////////////////////////////////////////

            double maxA = A.Max();  // максимальный элемент 1d массива
            double minA = A.Min();  // минимальный элемент 1d массива
            double sumEvenA = 0;    // сумма чётных элементов 1d массива

            for (int i = 0; i < A.Length; i++)
            {
                product *= A[i];        // умножаем эл. массива
                if (A[i] % 2 == 0)      // суммируем чётные эл.
                    sumEvenA += A[i];
            }

            ///////////////////////////////////////////////////////////////////////////////////////////////////
            double maxB = B[0, 0];   // максимальный элемент 2d массива
            double minB = B[0, 0];   // минимальный элемент 2d массива
            double sumOddB = 0;     // сумма нечётных столбцов 2d массива

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (maxB < B[i, j]) maxB = B[i, j];            // поиск макс. элемента 2d массива
                    if (minB > B[i, j]) minB = B[i, j];            // поиск мин. элемента 2d массива
                    sum += B[i, j];                                // суммируем эл. массива
                    product *= B[i, j];                            // умножаем эл. массива
                    if (j % 2 != 0) sumOddB += B[i, j];            // сумма эл. нечётных столбцов
                }
            }

            ///////////////////////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine();
            if (maxA == maxB)
            {
                Console.WriteLine(" Общий максимальный элемент двух массивов: " + maxA);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(" Общего максимального элемента двух массивов не найдено!");
                Console.ResetColor();
            }

            if (minA == minB)
            {
                Console.WriteLine(" Общий минимальный элемент двух массивов: " + minA);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(" Общего минимального элемента двух массивов не найдено!");
                Console.ResetColor();
            }

            Console.WriteLine(" Общая сумма всех элементов: " + sum);
            Console.WriteLine(" Общее произведение всех элементов: " + Math.Round(product, 2));
            Console.WriteLine(" Сумма чётных элементов 1d массива A: " + sumEvenA);
            Console.WriteLine(" Сумма нечётных столбцов 2d массива B: " + sumOddB);
        } 
    }
}
