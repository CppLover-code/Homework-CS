namespace Ex._2
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t-Decimal number-");
            Decimal dec;
            ConsoleKey key;

            while (true)
            {
                Console.WriteLine(" Converter menu");
                Console.WriteLine(
                    " 1 - Converting to binary\n" +
                    " 2 - Converting to octal\n" +
                    " 3 - Converting to hexadecimal\n" +
                    " Esc - exit");

                ConsoleKeyInfo info = Console.ReadKey();
                key = info.Key;

                switch (key)
                {
                    case ConsoleKey.NumPad1:
                        dec = new Decimal();
                        dec.ToBinary();
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case ConsoleKey.NumPad2:
                        dec = new Decimal();
                        dec.ToOctal();
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case ConsoleKey.NumPad3:
                        dec = new Decimal();
                        dec.ToHexadecimal();
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
        struct Decimal
        {
            int number;
            public Decimal()                                          // конструктор без параметров с вводом от пользователя
            {
                while (true)
                {
                    Console.WriteLine("\n Enter a number:");
                    try
                    {
                        number = int.Parse(Console.ReadLine()!);                      

                        if (number < 0)
                        {
                            throw new Exception(" Incorrect input!"); // бросаем исключение
                        }
                        break;
                    }
                    catch (FormatException ex)                        // ловим некорректный ввод
                    {                                                 
                        Console.WriteLine(" Incorrect input!", ex);
                    }
                    catch (Exception ex)                              // ловим нами созданное исключение
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            public Decimal(int value)
            {
                number = value;
            }
            public void ToBinary()
            {
                string s = Convert.ToString(this.number, 2);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($" Result: {this.number} in binary \u2192 " + s + "\n");
                Console.ResetColor();
            }
            public void ToOctal()
            {
                string s = Convert.ToString(this.number, 8);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($" Result: {this.number} in octal \u2192 " + s + "\n");
                Console.ResetColor();
            }
            public void ToHexadecimal()
            {
                string s = Convert.ToString(this.number, 16);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($" Result: {this.number} in hexadecimal \u2192 " + s + "\n");
                Console.ResetColor();
            }
        }
    }
}