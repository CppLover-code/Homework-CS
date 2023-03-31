using System;
using System.Reflection.Metadata.Ecma335;

namespace ДЗ_30._03._2023_Делегаты__события
{
    delegate void MyDel(int[]ar);
    internal class Program1
    {
        static void Main(string[] args)
        {
            int[] array = new int[20];                     
            FillArray(array);                              // заполняем массив

            MyDel[] dlg = { Even, Odd, Prime, Fibonacci }; // массив делегатов

            int choice = 0;
            while (choice != 5)
            {
                Console.WriteLine("\t\t-Working with an array using delegates-");
                ShowArray(array);
                Console.Write("\n 1 - Even\n 2 - Odd \n 3 - Prime\n" +
                    " 4 - Fibonacci\n 5 - Exit\n Make a choice: ");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                    if(choice < 1 || choice > 5)
                        throw new Exception("\a Incorrect input!");
                }
                catch(FormatException ex)
                {
                    Console.WriteLine("\a Incorrect input!", ex);
                    Console.ReadLine();
                    Console.Clear();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                    Console.Clear();
                }
                
                if (choice >= 1 && choice <= 4)  // если выбор пользователя от 1 до 4, что соотв кол-ву методов
                    dlg[choice - 1](array);      // то вызываем соотв. делегат по индексу
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
            Console.WriteLine(" Random array");
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
            if(count == 0) Console.Write(" Fibonacci numbers not found!");
            Console.WriteLine();
        }
    }
}