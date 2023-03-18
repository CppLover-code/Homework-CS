using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДЗ_14._03._2023_Введение_в
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Square\n");

            Console.WriteLine(" Enter the length of the side of the square:");
            int length = int.Parse(Console.ReadLine());

            Console.WriteLine(" Enter character to display square:");
            char symbol = char.Parse(Console.ReadLine());

            Square.ShowSquare(length,symbol);
        }
        class Square
        {
            public static void ShowSquare(int length, char s)  // метод для вывода квадрата
            {
                for (int i = 0; i < length; i++)
                {
                    for (int k = 0; k < length; k++)
                    {
                        Console.Write(s + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
