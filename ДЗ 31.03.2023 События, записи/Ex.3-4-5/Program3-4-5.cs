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
            bool flag;

            for (int i = 0; i < x.Length; i++)
            {
                flag = false;
                if (x[i] < 0)
                {
                    for (int k = i + 1; k < x.Length; k++)
                    {
                        if(x[i] == x[k]) flag = true; 
                    }
                    if (flag == false)
                    {
                        Console.Write(x[i] + " ");
                    }
                }
            }
        };

        static void Main(string[] args)
        {
            Console.WriteLine("\t\t-Using lambda expressions to process an array-");
            int[] x = { -1, 5,-1, 21,-3, 4,-2, 8, -1, 1, 7,-3, -10, -42 };
            Console.WriteLine( " Количество чисел кратных 7: " + multSeven(x));
            Console.WriteLine(" Количество положительных чисел: " + posNumber(x));
            Console.WriteLine(" Уникальные отрицательные числа: ");
            negNumber(x);

        }
    }
}