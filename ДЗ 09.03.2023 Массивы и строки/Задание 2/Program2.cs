using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_2
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Задание 2. Работа с 2d массивом\n");

            int s = 5;
            int[,] arrInt = new int[s, s];

            Random rndInt = new Random();                  // объект для генерации случайных чисел

            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j < s; j++)
                {
                    arrInt[i, j] = rndInt.Next(-100, 101);   // заполнение массива случайными числами
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" 2D массив 5х5");
            Console.ResetColor();
            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j < s; j++)
                {
                    Console.Write(arrInt[i, j] + "\t");    // выводим массив 
                }
                Console.WriteLine();
            }


            int size = s * s;               // размер 1d массива
            int[] arrCopy = new int[size];  // создаем и выделяем память для 1d массива
            int w = 0;                      // переменная для индексации массива

            for (int k = 0; k < s; k++)
            {
                for (int j = 0; j < s; j++)
                {
                    arrCopy[w] = arrInt[k, j];
                    w++;
                }
            }

            int minC = arrCopy.Min();
            int maxC = arrCopy.Max();

            int minI = 0;
            int maxI = 0;

            int rangeSum = 0;

            for (int i = 0; i < arrCopy.Length; i++)
            {
                if (arrCopy[i] == minC) minI = i;         // находим индексы мин и макс элементов
                else if (arrCopy[i] == maxC) maxI = i;
            }

            if (minI > maxI)                              // если индекс минимального элемента
            {                                             // больше индекса макс элемента,
                int temp = minI;                          // то меняем значения индексов местами
                minI = maxI;
                maxI = temp;
            }

            for (int i = minI + 1; i < maxI; i++)
            {
                rangeSum += arrCopy[i];                   // суммируем элементы в диапазоне от мин. до макс.
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n Сумма элементов массива в диапазоне от мин. до макс.: " + rangeSum);
            Console.ResetColor();
        }
    }
}
