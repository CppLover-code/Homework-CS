namespace ДЗ_23._03._2023_Наследование
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //Money money = new Money(25, 30);
            //money.OutputSum();
            Money money = new Money();
            money.Input();
            money.OutputSum();

        }
        class Money
        {
            public int dollar { get; set; } // целая часть доллара 
            public int cent { get; set; }   // центы

            public Money()
            {
                this.dollar = 0;
                this.cent = 0;
            }
            public Money(int d, int c)
            {
                this.dollar = d;
                this.cent = c;
            }
            public void OutputSum()
            {
                Console.WriteLine($" Amount of money: {dollar}.{cent} ");
            }
            public void Input()
            {
                while (true)
                {
                    try
                    {
                        Console.Write(" Enter the amount of dollars: ");
                        dollar = int.Parse(Console.ReadLine()!);
                        break;
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(" Incorrect input", ex);
                    }
                }
                while (true)
                {
                    try
                    {
                        Console.Write(" Enter the amount of cents: ");
                        cent = int.Parse(Console.ReadLine()!);
                        break;
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(" Incorrect input", ex);
                    }
                }               
            }
            //public void Reduction();
        }
        class Product : Money
        {

        }
    }
}