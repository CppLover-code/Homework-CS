using System.Collections.Generic;
using System.Linq;

namespace ДЗ_31._03._2023_События__записи
{
    internal class Program1
    {
        delegate void Color(string UserColor, Dictionary<string,string> rainbow);           // объявляем тип делегата      

        static Color RGB = delegate (string UserColor, Dictionary<string, string> rainbow)  // анонимный метод
        {
            var rgb = from k in rainbow
                      where k.Key == UserColor                                              // ключ должен быть равен цвету
                      select k;

            foreach (var val in rgb)
                Console.Write("\n Результат: {0} - RGB({1})", val.Key,val.Value);           // выводим результат
            Console.WriteLine();
        };
        
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t-Радуга-");
            ShowRainbow();

            Dictionary<string, string> rainbow = new Dictionary<string, string>            // коллекция хранит цвет и его rgb-значение
            {
                    {"красный",     "255, 0, 0"  },
                    {"оранжевый",   "255, 127, 0"},
                    {"желтый",      "255, 255, 0"},
                    {"зеленый",     "0, 255, 0"  },
                    {"голубой",     "0, 0, 255"  },
                    {"синий",       "46, 43, 95" },
                    {"фиолетовый",  "139, 0, 255"}
            };

            string UserColor;
            while (true)
            {
                Console.WriteLine("\n Введите цвет радуги для получения rgb-значения:");
                try
                {
                    UserColor = Console.ReadLine()!.Trim(' ').ToLower();        // убираем лишние пробелы и переводим все буквы в нижний регистр
                    if (!rainbow.ContainsKey(UserColor))                        // если в коллекции нет цвета, который ввёл пользователь,
                    {
                        throw new Exception(" Некорректное значение цвета!");   // бросаем исключение
                    }
                        
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            
             RGB(UserColor, rainbow); 
        }
        static void ShowRainbow()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("■ - красный");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("■ - оранжевый");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("■ - желтый");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("■ - зеленый");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("■ - голубой");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("■ - синий");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("■ - фиолетовый");
            Console.ResetColor();
        }
    }
}