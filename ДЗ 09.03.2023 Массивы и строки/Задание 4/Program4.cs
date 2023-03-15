using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_4
{
    internal class Program4
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Задание 4. Операции над матрицами");

            int h = 3, w = 4;                       // размер массива

            Random rand = new Random();

            int[,] matrix1 = new int[h, w];
            int[,] matrix2 = new int[h, w];
            int[,] res = new int[h, w];             // массив для хранения результата

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\n Матрица 1 - " + h + "*" + w);
            Console.ResetColor();
            FillArray(matrix1, h, w, rand);         // заполняем массив 
            ShowArray(matrix1, h, w);               // показ массива

            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("\n Матрица 2 - " + h + "*" + w);
            Console.ResetColor();
            FillArray(matrix2, h, w, rand);
            ShowArray(matrix2, h, w);

            int choice;
            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n Выберите операцию над матрицами: ");
                Console.WriteLine(" 1 - умножение матрицы на число");
                Console.WriteLine(" 2 - сложение матриц");
                Console.WriteLine(" 3 - произведение матриц");
                Console.WriteLine(" 0 - выход");
                Console.ResetColor();

                while (true)
                {
                    while (!int.TryParse(Console.ReadLine(), out choice))
                    {
                        Console.WriteLine(" Ошибочный ввод! Введите целое число:");
                    }
                    if (choice >= 0 && choice <= 3) break;
                    else Console.WriteLine(" Ошибочный ввод! ");
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine(" Введите число для умножения матрицы:");
                        int multNumb = int.Parse(Console.ReadLine());

                        Console.WriteLine($" Выберите матрицу, которую необходимо умножить на {multNumb}:");
                        Console.WriteLine(" 1 - Матрица 1\n 2 - Матрица 2");
                        int ch = int.Parse(Console.ReadLine());

                        if (ch == 1)
                        {
                            MultNumber(matrix1, res, h, w, multNumb);
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine(" Результат умножения Матрицы 1 на число:");
                            Console.ResetColor();
                            ShowArray(res, h, w);
                        }
                        else if (ch == 2)
                        {
                            MultNumber(matrix2, res, h, w, multNumb);
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine(" Результат умножения Матрицы 2 на число:");
                            Console.ResetColor();
                            ShowArray(res, h, w);
                        }

                        break;

                    case 2:
                        Addition(matrix1, matrix2, res, h, w);
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(" Результат сложения двух матриц:");
                        Console.ResetColor();
                        ShowArray(res, h, w);
                        break;

                    case 3:
                        Product(matrix1, matrix2, res, h, w);
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine(" Результат произведения двух матриц:");
                        Console.ResetColor();
                        ShowArray(res, h, w);
                        break;

                }
            } while (choice != 0);
        }
        static void FillArray(int[,] arr, int h, int w, Random rand)
        {
            for (int i = 0; i < h; i++)
                for (int k = 0; k < w; k++)
                    arr[i, k] = rand.Next(1, 101);
        }
        static void ShowArray(int[,] arr, int h, int w)
        {
            for (int i = 0; i < h; i++)
            {
                for (int k = 0; k < w; k++)
                {
                    Console.Write(arr[i, k] + "\t");
                }
                Console.WriteLine();
            }
        }
        static void MultNumber(int[,] arr, int[,] res, int h, int w, int numb)
        {
            for (int i = 0; i < h; i++)
            {
                for (int k = 0; k < w; k++)
                {
                    res[i, k] = arr[i, k] * numb;
                }
            }
        }
        static void Addition(int[,] arr1, int[,] arr2, int[,] res, int h, int w)
        {
            for (int i = 0; i < h; i++)
            {
                for (int k = 0; k < w; k++)
                {
                    res[i, k] = arr1[i, k] + arr2[i, k];
                }
            }
        }
        static void Product(int[,] arr1, int[,] arr2, int[,] res, int h, int w)
        {
            for (int i = 0; i < h; i++)
            {
                for (int k = 0; k < w; k++)
                {
                    res[i, k] = arr1[i, k] * arr2[i, k];
                }
            }
        }
    }
}
