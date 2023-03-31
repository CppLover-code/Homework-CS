using System;

namespace Ex._2
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-Делегаты Action,Predicate, Func-");
            Console.WriteLine(CurrentTime());
            Console.WriteLine(CurrentDate());
            Console.WriteLine(CurrentDayOfWeek());
            Console.WriteLine(TriangleArea());
            Console.WriteLine(RectangleArea());
        }
        static string CurrentTime()
        {
            string time = DateTime.Now.ToString();
            int found = time.IndexOf(" ");
            return $" Сurrent time {time.Substring(found + 1)}";
        }
        static string CurrentDate()
        {
            string time = DateTime.Now.ToString();
            string[] subs = time.Split(" ");
            return $" Current date {subs[0]}";
        }
        static string CurrentDayOfWeek()
        {
            DateTime d = DateTime.Now;            
            return $" Current day of the week {d.DayOfWeek}";
        }
        static string TriangleArea()
        {
            Console.WriteLine(" Enter the value of the sides of the triangle one by one:");
            double s1,s2,s3;
            while (true)
            {
                try
                {
                    s1 = double.Parse(Console.ReadLine()!);
                    s2 = double.Parse(Console.ReadLine()!);
                    s3 = double.Parse(Console.ReadLine()!);
                    if(s1 <= 0 || s2 <= 0 || s3 <= 0)
                    {
                        throw new Exception(" Incorrect input!");
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine(" Incorrect input!");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            double Pp = (s1 + s2 +s3) / 2;
            double Area = Math.Sqrt(Pp*(Pp - s1)*(Pp - s2)*(Pp - s3));
            return $" Area of triangle with sides a {s1}; b {s2}; c {s3} = {Math.Round(Area,1)} cm";
        }
        static string RectangleArea()
        {
            Console.WriteLine(" Enter the value of the two sides of the rectangle one by one:");
            double s1, s2;
            while (true)
            {
                try
                {
                    s1 = double.Parse(Console.ReadLine()!);
                    s2 = double.Parse(Console.ReadLine()!);                    
                    if (s1 <= 0 || s2 <= 0)
                    {
                        throw new Exception(" Incorrect input!");
                    }
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine(" Incorrect input!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            double Area = Math.Round(s1 * s2,1);
            return $" Area of triangle with sides a {s1}; b {s2} = {Area} сm";
        }
    }
}