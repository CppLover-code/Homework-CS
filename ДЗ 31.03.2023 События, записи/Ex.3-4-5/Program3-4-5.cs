using System.Numerics;

namespace Ex._3_4_5
{
    internal class Program
    {
        delegate int Counter(int[] x);
        delegate void Unique(int[] x);

        static Counter multSeven = x =>
        {
            int count = 0;
            for (int i = 0; i < x.Length; i++)
                if (x[i] % 7 == 0) count++;
            return count;
        };
        static Counter posNumber = x =>
        {
            int count = 0;
            for (int i = 0; i < x.Length; i++)
                if (x[i] > 0) count++; // число 0 явл. ни положительным, ни отрицательным
            return count;
        };
        static Unique negNumber = x =>
        {
            for (int i = 0; i < x.Length; i++)
            {

                bool cont = x.Contains(0);
                if (cont == false)
                {
                    Console.Write(x[i] + " ");
                }

            }
        };

        static void Main(string[] args)
        {
            Console.WriteLine("\t\t-Using lambda expressions to process an array-");
            int[] x = { -5,-3,-5,-2,-1,-1 };
            Console.WriteLine( " Количество чисел кратных 7: " + multSeven(x));
            Console.WriteLine(" Количество положительных чисел: " + posNumber(x));
            Console.WriteLine(" Уникальные отрицательные числа: ");
            negNumber(x);

        }
    }
}