using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;

namespace ДЗ_28._03._2023_Struct__enum
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t-3d vector-\n");
            Vector vect;

            ConsoleKey key;

            while (true)
            {
                Console.WriteLine(" Vector menu");
                Console.WriteLine(
                    " 1 - Multiply by a number\n" +
                    " 2 - Vector addition\n" +
                    " 3 - Vector subtraction\n" +
                    " Esc - exit");

                ConsoleKeyInfo info = Console.ReadKey();
                key = info.Key;

                switch (key)
                {
                    case ConsoleKey.NumPad1:
                        vect = new();
                        vect.Mult();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\n -Result-\n" + vect);
                        Console.ResetColor();
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case ConsoleKey.NumPad2:
                        Console.WriteLine("\n First vector ");
                        Vector a = new Vector();
                        Console.WriteLine(" Second vector ");
                        Vector b = new Vector();
                        vect = a + b;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\n -Result-\n" + vect);
                        Console.ResetColor();
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case ConsoleKey.NumPad3:
                        Console.WriteLine("\n First vector ");
                        Vector c = new Vector();
                        Console.WriteLine("\n Second vector ");
                        Vector d = new Vector();
                        vect = c - d;
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("\n -Result-\n" + vect);
                        Console.ResetColor();
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case ConsoleKey.Escape:
                        return;

                    default:
                        Console.WriteLine("\n Incorrect input!\n");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }
        struct Vector
        {
            int x;
            int y;
            int z;
            public Vector()                                       // конструктор без параметров с вводом от пользователя
            {
                while (true)
                {
                    Console.WriteLine("\n Enter vector data ");
                    try
                    {
                        Console.Write(" X: ");
                        x = int.Parse(Console.ReadLine()!);
                        Console.Write(" Y: ");
                        y = int.Parse(Console.ReadLine()!);
                        Console.Write(" Z: ");
                        z = int.Parse(Console.ReadLine()!);
                        break;
                    }
                    catch (FormatException ex)                        // ловим некорректный ввод
                    {                                                 // не удалось спарсить число int
                        Console.WriteLine(" Incorrect input!", ex);
                    }
                }                      
            }
            public Vector(int x, int y, int z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
            public override string ToString()
            {
                return " 3-D Vector:" + "\n coord X - " + x + "\n coord Y - " + y + "\n coord Z - " + z;
            }
            public void Mult()
            {
                int numb;
                while (true)
                {
                    Console.WriteLine(" Enter a number to multiply:");
                    try { numb = int.Parse(Console.ReadLine()!); break; }
                    catch (FormatException ex) { Console.WriteLine(" Incorrect input!", ex); }                 
                }
                
                this.x *= numb;
                this.y *= numb;
                this.z *= numb;
            }
            public Vector Add()
            {
                Console.WriteLine(" Enter data about the first vector ");
                Vector a = new Vector();
                Console.WriteLine(" Enter data about the second vector ");
                Vector b = new Vector();

                Vector temp = new Vector();
                temp.x = a.x + b.x;
                temp.y = a.y + b.y;
                temp.z = a.z + b.z;
                return temp;
            }
            public static Vector operator +(Vector a, Vector b)
            {
                return new Vector(a.x + b.x, a.y + b.y, a.z + b.z);
            }
            public static Vector operator -(Vector a, Vector b)
            {
                return new Vector(a.x - b.x, a.y - b.y, a.z - b.z);
            }            
        }
    }
}