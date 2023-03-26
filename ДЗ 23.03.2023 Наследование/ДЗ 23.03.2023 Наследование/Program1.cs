namespace ДЗ_23._03._2023_Наследование
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t-Products and prices-\n");
         
            Product product = new Product();
            product.InputInfo();
            product.OutputInfo();
            product.Reduction();
            product.OutputInfo();
        }
        class Money
        {
            public int dollar { get; set; } // целая часть доллара 
            public int cent { get; set; }   // центы

            public Money()                  // c-tor по умолчанию
            {
                this.dollar = 0;
                this.cent = 0;
            }
            public Money(int d, int c)      // c-tor с параметрами (на всякий)
            {
                this.dollar = d;
                this.cent = c;
            }
            public void OutputSum()         // вывод суммы на экран
            {
                Console.WriteLine($" Amount: {dollar}.{cent} $\n");
            }
            public void Input()             // ввод суммы с клавиатуры
            {
                while(true)                 // все циклы while работают пока выбрасываются исключения
                {
                    while (true)
                    {
                        try
                        {
                            Console.Write(" Enter the amount of dollars: ");
                            dollar = int.Parse(Console.ReadLine()!);         // если введены некорректные данные - исключение format
                            if (dollar < 0)                                  // если целая часть меньше нуля
                            {
                                throw new Exception(" Incorrect input");     // выбрасываем исключение
                            }
                            break;
                        }
                        catch (FormatException ex)                           // ловим исключение формата
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" Incorrect input", ex);
                            Console.ResetColor();
                        }
                        catch (Exception ex)                                 // ловим созданное нами исключение
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(ex.Message);
                            Console.ResetColor();
                        }
                    }
                    while (true)
                    {
                        try
                        {
                            Console.Write(" Enter the amount of cents: ");
                            cent = int.Parse(Console.ReadLine()!);           // если введены некорректные данные - исключение format                 
                            if (cent > 99 || cent < 0)                       // если цент больше 99 или меньше нуля
                            {
                                throw new Exception(" Incorrect input");     // выбрасываем исключение
                            }
                            break;
                        }
                        catch (FormatException ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" Incorrect input", ex);
                            Console.ResetColor();
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(ex.Message);
                            Console.ResetColor();
                        }
                    }
                    try
                    {
                        if (dollar == 0 && cent == 0)                       // если доллар и цент равны нулю
                        {
                            throw new Exception(" Incorrect input");        // выбрасываем исключение
                        }
                        else break;
                    }
                    catch(Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ResetColor();
                    } 
                }
                Console.WriteLine();
            }          
        }
        class Product : Money
        {
            public string? name { get; set; }
            public Product()
            {
                this.dollar = 0;
                this.cent = 0;
                this.name = "";
            }
            public Product(int d, int c, string n) : base(d, c)
            {
                this.name = n;
            }
            public void OutputInfo()        // вывод информации о продукте
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" -Product information-");
                Console.ResetColor();
                Console.WriteLine($" Product name: {name}");
                base.OutputSum();
                if(this.dollar == 0 && this.cent == 0)
                {
                    Console.WriteLine($" Wow! You can pick up -{name}- for free!");
                }
            }
            public void InputInfo()         // ввод информации о продукте
            {
                Console.Write(" Enter product name: ");  // можно сделать проверку для названия продукта
                name = Console.ReadLine();
                Console.WriteLine(" Enter the price of the product \u25bc");
                base.Input();
            }
            public void Reduction()         // уменьшение стоимости продукта
            {                
                Money money = new Money();  // объект-сумма для уменьшения стоимости продукта

                while(true)
                {
                    try
                    {
                        Console.WriteLine(" Enter the amount to reduce the price of the product \u25bc");
                        money.Input();

                        // Условие, которое проверяет является ли введенная сумма для уменьшения БОЛЬШЕ стоимости продукта
                        if(this.dollar < money.dollar ||                            // если доллар продукта меньше доллара суммы для уменьшения ИЛИ
                           this.dollar == money.dollar && this.cent < money.cent)   // доллар продукта равен доллару суммы И цент продукта меньше цента суммы
                        {
                            throw new Exception(" Incorrect input!\n The entered amount is more than the cost of product.\n");
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message); 
                        Console.ResetColor();
                    }
                }

                if(money.cent > this.cent)          
                {
                    this.dollar -= (money.dollar + 1);
                    this.cent = 100 - (money.cent - this.cent);
                }
                else
                {
                    this.dollar -= money.dollar;
                    this.cent -= money.cent;
                }  
            }
        }
    }
}