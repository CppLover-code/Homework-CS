using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ex._4
{
    internal class Program4
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" -The result of the entered logical expression-\n");

            string expressions;
            String pattern = @"(\d+)\s?([<=]*[>=]*[==]*[!=]*)\s?(\d+)"; // регулярное выражение

            while (true)
            {
                Console.WriteLine(" Enter boolean expression:");
                expressions = Console.ReadLine();

                try
                {
                    Match m = System.Text.RegularExpressions.Regex.Match(expressions, pattern); // сопоставление введённой строки и регулярного выражения
                    if (!m.Success) { throw new Exception(" Incorrect input!\n"); }  // если введенная строка не соотв. шаблону - исключение
                    else break;                                                      // иначе выход из цикла
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;   
            Console.Write("\n Result: ");
            Console.ResetColor();

            foreach (System.Text.RegularExpressions.Match m in                            // проходимся по строке и выражению, находим совпадения
                     System.Text.RegularExpressions.Regex.Matches(expressions, pattern))  // объект Match сохраняет в себе данные из строки пользователя
            {
                int value1 = Int32.Parse(m.Groups[1].Value);   // 1 группа соотв. первому числу
                int value2 = Int32.Parse(m.Groups[3].Value);   // 3 группа соотв. третьему числу
                                                               
                switch (m.Groups[2].Value)                     // 2 группа - операции сравнения
                {
                    case "<":
                        Console.WriteLine("{0} = {1}", m.Value, value1 < value2);
                        break;
                    case ">":
                        Console.WriteLine("{0} = {1}", m.Value, value1 > value2);
                        break;
                    case "<=":
                        Console.WriteLine("{0} = {1}", m.Value, value1 <= value2);
                        break;
                    case ">=":
                        Console.WriteLine("{0} = {1}", m.Value, value1 >= value2);
                        break;
                    case "==":
                        Console.WriteLine("{0} = {1}", m.Value, value1 == value2);
                        break;
                    case "!=":
                        Console.WriteLine("{0} = {1}", m.Value, value1 != value2);
                        break;
                }
            }
        }

    }
}

// https://cutt.ly/P4bZvWe - wiki регулярные выражения (Разновидности регулярных выражений - POSIX)
// https://cutt.ly/54bX2kE - tproger.Регулярные выражения: начало работы с RegExp
// https://regex101.com/ 

//String pattern = @"(\d+)\s?([<=]*[>=]*[==]*[!=]*)\s?(\d+)"; // регулярное выражение
// \d - цифра от 0-9  // + один или несколько раз // вместе означает совпадение одной или нескольких цифр
// \s - любой невидимый символ // ? 0 или один раз  // вместе означает, что пробел между цифрой и оператором сравнения может быть лишь один или вообще не быть
// ([<=]*[>=]*[==]*[!=]*)  2 группа "захвата" символов, которые могут находиться между числами 