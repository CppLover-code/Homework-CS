using Microsoft.SqlServer.Server;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_2
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Palindrome\n");

            long number;
            while (true)                                               
            {      
                Console.WriteLine(" Enter the number: ");
                if (!long.TryParse(Console.ReadLine(), out number))      // если введенные данные не явл. числом
                {
                    Console.WriteLine(" Incorrect input!\n");            // вывод сообщения о неверном вводе
                }
                else break;                                              // иначе выход из цикла
            }
            string str = number.ToString();                              // преобразование числа в строку

            if (Palindrome.CheckP(str))                                  // если метод вернул true
            {
                Console.WriteLine(" This number is a palindrome!");      // ok!
            }
            else { Console.WriteLine(" This is NOT a palindrome!"); }    // иначе НЕ ok!


        }
        class Palindrome
        {         
            public static string ReverseStr(string str) // метод для реверсирования строки
            {
                char[] chars = str.ToCharArray();       // строку в массив char
                Array.Reverse(chars);                   // реверс массива char
                return new string(chars);               // возврат строки, содержащей символы массива char
            }
            public static bool CheckP(string str)       // метод определения палиндрома
            {
                string temp = ReverseStr(str);          // инициализируем строку реверсом
                return str.Equals(temp);                // возврат результата равенства/неравенства 
            }
        }
    }
}
