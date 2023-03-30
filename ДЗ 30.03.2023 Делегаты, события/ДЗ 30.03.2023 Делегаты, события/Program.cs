using System;
using System.Reflection.Metadata.Ecma335;

namespace ДЗ_30._03._2023_Делегаты__события
{
    delegate void MyDel(int[]ar);
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" -Методы для работы с массивами-");

            int[] array = new int[20];
            FillArray(array);
            ShowArray(array);

            MyDel[] dlg = { Even, Odd, Prime, Fibonacci };
            int choice = 0;
            while (choice != 5)
            {
                Console.Write("\n1 Even\n2 Odd \n3 Prime\n4 Fibonacci\n5 Exit\nYour choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                if (choice >= 1 && choice <= 4)
                {
                    dlg[choice - 1](array);
                }
            }
        }
        static void FillArray(int [] ar)
        {
            Random rnd = new Random();
            for (int i = 0; i < ar.Length; i++)
                ar[i]= rnd.Next(1,101);
        }
        static void ShowArray(int[] ar)
        {
            foreach (int i in ar)
                Console.Write(i + " ");
            Console.WriteLine();
        }

        static void Even(int[] ar)
        {
            for (int i = 0; i < ar.Length;i++)
                if(ar[i] % 2 is 0) Console.Write(ar[i] + " ");
            Console.WriteLine();
        }
        static void Odd(int[] ar)
        {
            for (int i = 0; i < ar.Length; i++)
                if (ar[i] % 2 != 0) Console.Write(ar[i] + " ");
            Console.WriteLine();
        }
        static void Prime(int[] ar)
        {
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] is 1) continue;
                else if (ar[i] is 2 || ar[i] is 3 || ar[i] is 5 || ar[i] is 7)
                {
                    Console.Write(ar[i] + " ");
                }
                else if(ar[i] % 2 != 0 && ar[i] % 3 != 0 &&
                   ar[i] % 5 != 0 && ar[i] % 7 != 0)
                {
                    Console.Write(ar[i] + " ");
                }
            }
            Console.WriteLine();
        }
        static void Fibonacci(int[] ar)
        {
            int count = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                int a = 0, b = 1, s = 1;

                while (s < 101)
                {
                    s = a + b;
                    a = b;
                    b = s;
                    if (ar[i] == s)
                    {
                        Console.Write(ar[i] + " ");
                        count++;
                        break;
                    }
                } 
            }
            if(count == 0) Console.Write(" Чисел Фибоначчи не найдено!");
            Console.WriteLine();
        }
    }
}