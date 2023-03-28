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
                
                Array a = new(size);
                a.Show();
                a.Show(" Array with parameters:");
                Console.WriteLine(" Array Info ");
                a.ShowEven();
                a.ShowOdd();
                Console.Write(" Enter a number to compare: ");
                int numb = NumbInput();
                Console.WriteLine($" Number of elements less than {numb}:\t" + a.Less(numb));
                Console.WriteLine($" Number of large elements than {numb}:\t" + a.Greater(numb));
                Console.WriteLine(" Number of unique values in a container:\t" + a.CountDistinct());
                Console.WriteLine($" Number of elements equal to {numb}:\t" + a.EqualToValue(numb));
            }
            public static int SizeInput()
            {
                int size;
                while (true)
                { 
                    try
                    {
                        size = int.Parse(Console.ReadLine()!);
                        if (size <= 0 || size > 15)
                            throw new Exception(" Incorrect input!\n");
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
            public static int NumbInput()
            {
                int numb;
                while (true)
                {
                    try
                    {
                        numb = int.Parse(Console.ReadLine()!);
                        if (numb < 0)
                            throw new Exception(" Incorrect input!\n");
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
            public void Show()
            {
                Console.WriteLine(" Array: ");
                foreach (int i in ar)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
            public void Show(string info)
            {
                Console.WriteLine(info);

                foreach (int i in ar)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
            public void ShowEven()
            {
                Console.Write(" Even Container Values: ");
                for (int i = 0; i < ar.Length; i++)
                    if (ar[i] % 2 == 0) Console.Write(ar[i] + " "); 
                Console.WriteLine();
            }
            public void ShowOdd()
            {
                Console.Write(" Odd Container Values: ");
                for (int i = 0; i < ar.Length; i++)
                    if (ar[i] % 2 != 0) Console.Write(ar[i] + " ");
                Console.WriteLine();
            }
            public int Less(int valueToCompare)
            {
                int count = 0;
                for (int i = 0; i < ar.Length; i++)
                    if (ar[i] < valueToCompare) count++;

                return count;
            }
            public int Greater(int valueToCompare)
            {
                int count = 0;
                for (int i = 0; i < ar.Length; i++)
                    if (ar[i] > valueToCompare) count++;

                return count;
            }

            public int CountDistinct()
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
            public int EqualToValue(int valueToCompare)
            {
                int count = 0;
                for (int i = 0; i < ar.Length; i++)
                    if (Array.Equals(ar[i],valueToCompare)) count++;
                return count;
            }
        }
    }
}