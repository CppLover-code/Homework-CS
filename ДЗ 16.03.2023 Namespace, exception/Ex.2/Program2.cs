using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex._2
{
    internal class Program2
    {
        enum Number: int { zero, one, two, three, four, five, six, seven, eight, nine } // перечисление
        static void Main(string[] args)
        {
            Console.WriteLine(" -Translation of a word into a number-\n");

            Console.WriteLine(" Enter in words one digit from 0 to 9");
            string word = Console.ReadLine();
            
            Translation(word);                                                          // перевод из слова в число
        }
        static void Translation(string word)
        {
            bool flag = false;
            foreach (Number item in Enum.GetValues(typeof(Number)))                     // цикл по перечислению
            {               
                string str = item.ToString();                                           // конвертация целого числа в строку

                if (str.Equals(word, StringComparison.InvariantCultureIgnoreCase))      // если строки совпали (независимо
                {                                                                       // от регистра)
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n Result: " + Enum.Format(typeof(Number), item, "D"));  // выводим результат
                    Console.ResetColor();
                    flag = true;
                    break;
                }
            }
            if (!flag)                                                                  // если совпадений не найдено
            {                                                                           // вывод сообщения
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\a Impossible to translate from word to number!\n"); 
                Console.ResetColor();
            }
        }
    }
}
