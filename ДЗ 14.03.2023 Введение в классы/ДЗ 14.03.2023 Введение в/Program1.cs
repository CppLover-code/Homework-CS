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
            Square square = new Square(5, '-');
            square.ShowSquare();
        }
        class Square
        {
            public int length;
            public char symbol;
            public Square()
            {
                Console.WriteLine(" C-tor by default");
                length = 5;
                symbol = '*';
            }
            public Square(int l, char s) 
            {
                Console.WriteLine(" C-tor with 2 param");
                length = l;
                symbol = s;
            }

            public void ShowSquare()
            {
                for (int i = 0; i < length; i++)
                {
                    for (int k = 0; k < length; k++)
                    {
                        Console.Write(symbol + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
