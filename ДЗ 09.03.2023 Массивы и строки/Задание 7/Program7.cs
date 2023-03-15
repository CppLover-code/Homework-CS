using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_7
{
    internal class Program7
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Задание 7. Проверка текста на недопустимые слова\n");
            string text = "To be, or not to be, that is the question";

            string x = "be";                             // недопустимое слово
            string symb = new String ( '*', x.Length);   // строка для замены
            string text1 = text.Replace(x, symb);        // заменяем все недопустимые слова
            int count = 0;

            //count = text1.Count(ch => ch == '*');      // можно использовать как вариант

            StringBuilder sb = new StringBuilder(text1);

            for (int i = 0; i < sb.Length; i++)
                if (sb[i] == '*') count++;               // подсчитываем кол-во вхождений    

            Console.WriteLine(" -Исходный текст-\n" + text);
            Console.WriteLine("\n -Недопустимое слово: " + x);
            Console.WriteLine("\n -Результат-\n" + text1);
            Console.WriteLine($"\n Статистика: {count / x.Length} замены слова " + x);
        }
    }
}
