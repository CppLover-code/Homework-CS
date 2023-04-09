
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
                if (x[i] % 7 == 0) count++;             // ноль кратен любому числу
            return count;
        };
        static Counter posNumber = x =>
        {
            int count = 0;
            for (int i = 0; i < x.Length; i++)
                if (x[i] > 0) count++;                  // число 0 явл. ни положительным, ни отрицательным
            return count;
        };
        static Unique negNumber = x =>
        {           
            for (int i = 0; i < x.Length; i++)
            {
                bool flag = false;                      // булевская переменная для проверки повторяется ли число   
                if (x[i] < 0)                           // если число отрицательное
                {
                    for (int j = 0; j < x.Length; j++)  // еще один цикл для проверки этого же массива
                    {
                        if (j == i)                     // если индексы совпали
                        {
                            continue;                   // число не проверяется
                        }
                        else if (x[j] < 0)              // если число отрицательное
                        {
                            if (x[i] == x[j])           // проверяем равны ли числа
                                flag = true;            // меняем значение флага
                        }
                    }
                    if (flag == false)                  // если флаг остался неизменным, значит число уникальное
                        Console.Write(x[i] + " ");      // выводим на экран
                }
            }
        };

        static void Main(string[] args)
        {
            Console.WriteLine("\t\t-Using lambda expressions to process an array-");
            Console.Write(" Creating an array\n Enter the number of array elements: ");
            int size;
            while (true)
            {
                try
                {
                    size = int.Parse(Console.ReadLine()!);
                    break;
                }
                catch(FormatException)
                {
                    Console.WriteLine(" Incorrect number!");
                }
            }
           
            int[] x = new int[size];
            Console.WriteLine(" Fill an array with integers from the keyboard: ");
            for (int i = 0; i < x.Length; i++)
            {
                while(true)
                {
                    Console.Write($" {i+1} element: ");
                    try
                    {
                        x[i] = int.Parse(Console.ReadLine()!);
                        break;
                    }
                    catch(FormatException)
                    {
                        Console.WriteLine(" Incorrect number!");
                    }
                }               
            }
            //int[] x = { -5,-3,-1,6,-5,-2,2,-1,0,-1,-3,-10,7 };
            Console.WriteLine(" Number of multiples of 7: " + multSeven(x));
            Console.WriteLine(" Number of positive numbers: " + posNumber(x));
            Console.Write(" Unique negative numbers: ");
            negNumber(x);
        }
    }
}