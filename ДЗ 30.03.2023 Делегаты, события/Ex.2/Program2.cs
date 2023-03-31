using System;

namespace Ex._2
{
    internal class Program2
    {
        static Func<string>? func;      // делегат, возвращающий string

        static Action? act;             // делегат без параметров

        static Predicate<double>? pred; // делегат, принимающий double
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\t-Using Delegates Action, Predicate, Func-");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\tDelegate Func\n");
            Console.ResetColor();

            func = CurrentTime;
            Console.WriteLine(func());

            func = CurrentDate;
            Console.WriteLine(func());

            func = CurrentDayOfWeek;
            Console.WriteLine(func());

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\tDelegates Action and Predicate\n");
            Console.ResetColor();

            act = TriangleArea;
            act();

            act = RectangleArea;
            act();
        }
        static string CurrentTime()
        {
            string time = DateTime.Now.ToString();
            int found = time.IndexOf(" ");
            return $" Сurrent time   --\u2192 \t\t{time.Substring(found + 1)}";
        }
        static string CurrentDate()
        {
            string time = DateTime.Now.ToString();
            string[] subs = time.Split(" ");
            return $" Current date   --\u2192 \t\t{subs[0]}";
        }
        static string CurrentDayOfWeek()
        {
            DateTime d = DateTime.Now;            
            return $" Current d/week --\u2192 \t\t{d.DayOfWeek}";
        }

        static bool CheckSide(double s) // метод для проверки стороны фигуры
        {
            return (s <= 0); // сторона меньше либо равна нулю?
        }
        static void TriangleArea()
        {
            Console.ForegroundColor= ConsoleColor.Yellow;
            Console.WriteLine(" -Area of a triangle-");
            Console.ResetColor();

            Console.WriteLine(" Enter the value of the sides of the triangle one by one:");
            double s1,s2,s3;
            while (true)
            {
                try
                {
                    s1 = double.Parse(Console.ReadLine()!);
                    s2 = double.Parse(Console.ReadLine()!);
                    s3 = double.Parse(Console.ReadLine()!);
                    pred = CheckSide;                               // предикат хранит указатель на метод, который подходит по параметру и типу возвр. значения(bool)
                    if (pred(s1) || pred(s2) || pred(s3))           // проверка на ноль и отрицательные числа с помощью предиката
                    {
                        throw new Exception("\a Incorrect input!");
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("\a Incorrect input!");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            double Pp = (s1 + s2 +s3) / 2;                              // полупериметр
            double Area = Math.Sqrt(Pp*(Pp - s1)*(Pp - s2)*(Pp - s3));  // площадь по формуле Герона
            if (Double.IsNaN(Area)) Area = 0;                           // если не удалось вычислить площадь, то присваиваем ноль

           Console.WriteLine($" Area of triangle with sides a {s1}; b {s2}; c {s3} = {Math.Round(Area,1)} cm\n");
        }
        static void RectangleArea()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" -Rectangle area-");
            Console.ResetColor();

            Console.WriteLine(" Enter the value of the two sides of the rectangle one by one:");
            double s1, s2;
            while (true)
            {
                try
                {
                    s1 = double.Parse(Console.ReadLine()!);
                    s2 = double.Parse(Console.ReadLine()!);
                    pred = CheckSide;
                    if (pred(s1) || pred(s2))                       // проверка с исп. предиката
                    {
                        throw new Exception("\a Incorrect input!");
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine("\a Incorrect input!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            double Area = Math.Round(s1 * s2,1);                    
            if (Double.IsNaN(Area)) Area = 0;                       // если не удалось вычислить площадь, то присваиваем ноль

            Console.WriteLine($" Area of triangle with sides a {s1}; b {s2} = {Area} сm");
        }
    }
}