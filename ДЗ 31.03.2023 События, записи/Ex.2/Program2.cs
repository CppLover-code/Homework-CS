using Microsoft.VisualBasic;
using System.Runtime.InteropServices;
using System.Security.Principal;
using static Ex._2.Program2;

namespace Ex._2
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Backpack bp = new();
            Console.Clear();
            
            bp.account.Notify += (object? sender, AccoutEventArgs e) =>
            {
                Console.WriteLine(e.Message + e.Name + ". Свободное место: " + e.Volume + " л.");
                Console.WriteLine("---------------------------------------------------------------------");
                Console.ResetColor();
            };
            bp.AccountAction += delegate (object? sender, AccoutEventArgs e)
            {
                if (sender is Backpack bp)
                {
                    Console.WriteLine(e.Message + e.Name + " c объемом: " + e.Volume + " л.");
                }
            };

            bool flag = true;
            while (flag)   // кладем предметы, пока свободный объем рюкзака больше 1, тк самый маленький
                           // по объему предмет равен 2 л, проверка происходит в методе Put класса Backpack
            {
                bp.Show();
                Console.SetCursorPosition(0, 12);
                flag = bp.Put();               
                Console.ReadLine();
                Console.Clear();               
            }
        }

        public interface IItem          // интерфейс для предметов
        {
            string Name { get; set; }
            double Vol { get; set; }
        }
        public class Book : IItem
        {
            public string Name { get; set; }
            public double Vol { get; set; }
            public Book(string Name, double Vol)
            {
                this.Name = Name;
                this.Vol = Vol;
            }            
        }
        public class PencilCase : IItem
        {
            public string Name { get; set; }
            public double Vol { get; set; }
            public PencilCase(string Name, double Vol)
            {
                this.Name = Name;
                this.Vol = Vol;
            }
        }
        public class LaunchBox : IItem
        {
            public string Name { get; set; }
            public double Vol { get; set; }
            public LaunchBox(string Name, double Vol)
            {
                this.Name = Name;
                this.Vol = Vol;
            }
        }
        public class Notebook : IItem
        {
            public string Name { get; set; }
            public double Vol { get; set; }
            public Notebook(string Name, double Vol)
            {
                this.Name = Name;
                this.Vol = Vol;
            }
        }

        public class Account
        {
            public EventHandler<AccoutEventArgs>? Notify;   // определение события
            public double volume { get; set; }              // копия объема рюкзака, которая будет меняться
            public List<IItem>? contents { get; set; }      // содержимое рюкзака
            public Account(double vol) 
            {
                this.volume = vol;                          // изначально копия объема равна реальному объему, но
                this.contents = new List<IItem>();          // при добавлении предмета объем свободного места будет уменьшаться
            }
            public void Put(IItem item)                     // добавление предмета в рюкзак
            {
                try
                {
                    volume -= item.Vol;                    // если выбранный предмет оказался большим, чем свободный объем, 
                    if (volume < 0)                        // но у нас есть в перечне предметы, которые мы можем поместить в рюкзак,
                    {                                      // то предлагаем добавить другой предмет, который все же поместится
                        volume += item.Vol;
                        throw new Exception(" Внимание! Превышен объем рюкзака! Попробуйте добавить предмет с меньшим объемом.\n" +
                            $" Свободный объем - {volume} л.");
                    }
                    contents?.Add(item);
                    Notify?.Invoke(this, new AccoutEventArgs(" В рюкзак положено: ", item.Name, volume)); // вызов события
                    Console.WriteLine(" Нажмите Enter, чтобы продолжить заполнять рюкзак!");

                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
            }
            
            public override string ToString()
            {
                return " ";
            }

        }
        public class AccoutEventArgs : EventArgs
        {
            public AccoutEventArgs(string? message, string name, double vol)
            {
                Message = message;
                Name = name;
                Volume = vol;
            }
            public string? Message { get; set; }
            public string Name { get; set; }
            public double Volume { get; set; }
        }
        public class Backpack
        {
            public EventHandler<AccoutEventArgs>? AccountAction;
            public string? color { get; set; }
            public string? firm { get; set; }
            public string? fabric { get; set; }
            public double weight { get; set; }
            public double volume { get; set; }
            public Account account { get; set; }

            public Backpack() // конструктор без параметров для ввода данных
            {
                Console.WriteLine(" Описание рюкзака ");
                Console.WriteLine("Введите цвет: ");
                this.color = Console.ReadLine();

                Console.WriteLine(" Введите название фирмы производителя: ");
                this.firm = Console.ReadLine();

                Console.WriteLine(" Введите название ткани: ");
                this.fabric = Console.ReadLine();
                while (true)
                {
                    try
                    {
                        Console.WriteLine(" Введите вес: ");
                        this.weight = double.Parse(Console.ReadLine()!);
                        break;
                    }
                    catch(FormatException)
                    {
                        Console.WriteLine(" Некорректный ввод веса!");
                    }
                }
                while (true)
                {
                    try
                    {
                        Console.WriteLine(" Введите объём: ");
                        this.volume = double.Parse(Console.ReadLine()!);
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine(" Некорректный ввод объема!");
                    }
                }

                this.account = new Account(volume);
            }
            public void Show()
            {
                Console.WriteLine($" -Рюкзак фирмы {firm}-\n");
                Console.WriteLine($" Цвет:\t{color}\n Ткань:\t{fabric}\n Вес:\t{weight}\n" +
                                  $" Объем:\t{volume}\n\n *Свободное место:\t{account.volume} л.");
                Console.Write(" *Cодержимое:\t\t");
                if(account.contents?.Count == 0)
                {
                    Console.Write("Рюкзак пуст!");
                }
                else
                {
                    foreach(var item in account.contents!)
                    {
                        Console.Write($"{item.Name} ");
                    }
                }

            }
            public bool Put() // сделать проверку ввода choice
            {
                int choice = 0;
                IItem? item = null;
                if (account.volume > 1)
                {
                    while (true)
                    {
                        Console.WriteLine(" Выберите предмет, который желаете положить в рюкзак:");
                        Console.WriteLine(" 1 - книга объемом 6 л\n 2 - пенал объемом 2 л\n" +
                            " 3 - ланчбокс объемом 4 л\n 4 - тетрадь объемом 3 л\n");
                        try
                        {
                            choice = int.Parse(Console.ReadLine()!);
                            if (choice < 1 || choice > 4)
                            {
                                throw new Exception(" Некорректный выбор!");
                            }
                            break;
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(" Некорректный выбор!");
                            Console.ResetColor();
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(ex.Message);
                            Console.ResetColor();
                        }                        
                    }
                    switch (choice)
                    {
                        case 1:
                            item = new Book("Book", 6);
                            break;
                        case 2:
                            item = new PencilCase("PencilCase", 2);
                            break;
                        case 3:
                            item = new LaunchBox("LaunchBox", 4);
                            break;
                        case 4:
                            item = new Notebook("Notebook", 3);
                            break;
                    }
                    AccountAction?.Invoke(this, new AccoutEventArgs("Попытка положить в рюкзак предмет ", item!.Name, item.Vol));
                    account.Put(item!);
                    return true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" Рюкзак заполнен!");
                    Console.ResetColor();
                    return false;
                }
            }
        }
    }
}