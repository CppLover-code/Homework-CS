using System;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;

namespace ДЗ_24._03._2023_Интерфейсы
{
    internal class Program1
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("\t\t-Array of random numbers-\n");

                Console.WriteLine(" Enter the size of the array (max size 15): ");
                int size = SizeInput();
                Console.Write(" Enter a number to compare values: ");
                int numb = NumbInput();
                Console.ReadLine();
                Console.Clear();

                Array a = new(size);

                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t\t\t-Array Info-\n");
                Console.ResetColor();
                a.Show();
                a.Show(" Array with parameters:");
                Console.WriteLine();

                a.ShowEven();
                a.ShowOdd();

                Console.WriteLine($" Number of elements less than {numb}:\t " + a.Less(numb));
                Console.WriteLine($" Number of large elements than {numb}:\t " + a.Greater(numb));
                Console.WriteLine(" Number of unique values in a container: " + a.CountDistinct());
                Console.WriteLine($" Number of elements equal to {numb}:\t\t " + a.EqualToValue(numb));
            }
            public static int SizeInput()   // ввод размера массива
            {
                int size;
                while (true)
                {
                    try
                    {
                        size = int.Parse(Console.ReadLine()!);
                        if (size <= 0 || size > 15)                       // если размер меньше либо равен нулю или больше 15
                            throw new Exception(" Incorrect input!\n");   // выброс исключения
                        break;
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(" Incorrect input!\n", ex);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                return size;
            }
            public static int NumbInput()   // ввод числа для сравнения с элементами массива
            {
                int numb;
                while (true)
                {
                    try
                    {
                        numb = int.Parse(Console.ReadLine()!);
                        if (numb < 0)                                   // если число отрицательное
                            throw new Exception(" Incorrect input!\n"); // выброс исключения
                        break;
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(" Incorrect input!\n", ex);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                return numb;
            }
        }
        interface IOutput
        {
            void Show();
            void Show(string info);
        }
        interface IOutput2
        {
            void ShowEven();
            void ShowOdd();
        }
        interface ICalc
        {
            int Less(int valueToCompare);
            int Greater(int valueToCompare);
        }
        interface ICalc2
        {
            int CountDistinct();
            int EqualToValue(int valueToCompare);
        }

        class Array : IOutput, IOutput2, ICalc, ICalc2
        {
            public int[] ar;
            public Array(int s)
            {
                ar = new int[s];
                Random random = new Random();
                for (int i = 0; i < ar.Length; i++)
                {
                    ar[i] = random.Next(1, 10);
                }
            }
            public void Show()                            // обычный вывод массива
            {
                Console.WriteLine(" Array: ");
                foreach (int i in ar)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
            public void Show(string info)                 // вывод массива с параметром
            {
                Console.WriteLine(info);

                foreach (int i in ar)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
            public void ShowEven()                        // вывод чётных значений массива
            {
                Console.Write(" Even Container Values:\t\t\t ");
                for (int i = 0; i < ar.Length; i++)
                    if (ar[i] % 2 == 0) Console.Write(ar[i] + " ");
                Console.WriteLine();
            }
            public void ShowOdd()                         // вывод нечётных значений массива
            {
                Console.Write(" Odd Container Values:\t\t\t ");
                for (int i = 0; i < ar.Length; i++)
                    if (ar[i] % 2 != 0) Console.Write(ar[i] + " ");
                Console.WriteLine();
            }
            public int Less(int valueToCompare)           // подсчет количества элементов массива меньших, чем заданое число
            {
                int count = 0;
                for (int i = 0; i < ar.Length; i++)
                    if (ar[i] < valueToCompare) count++;

                return count;
            }
            public int Greater(int valueToCompare)        // подсчет количества элементов массива больших, чем заданое число
            {
                int count = 0;
                for (int i = 0; i < ar.Length; i++)
                    if (ar[i] > valueToCompare) count++;

                return count;
            }
            public int CountDistinct()                    // подсчёт количества уникальных значений массива
            {
                int count = 0;
                for (int i = 0; i < ar.Length; i++)
                {
                    bool flag = false;

                    for (int j = 0; j < ar.Length; j++)
                    {
                        if (i != j && Array.Equals(ar[i], ar[j]))
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (!flag) count++;
                }
                return count;
            }
            public int EqualToValue(int valueToCompare)   //подсчёт количества значений равных заданому числу
            {
                int count = 0;
                for (int i = 0; i < ar.Length; i++)
                    if (Array.Equals(ar[i], valueToCompare)) count++;
                return count;
            }
        }
    }
}