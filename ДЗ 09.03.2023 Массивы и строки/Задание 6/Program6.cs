using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_6
{
    internal class Program6
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Задание 6. Изменение регистра первой буквы каждого предложения");

            Console.WriteLine(" Введите текст латинским алфавитом:");
            StringBuilder sb = new StringBuilder(Console.ReadLine());

            StringBuilder symb = new StringBuilder(".!?");     // массив, который будет хранить знаки окончания предложения
            UpperCase(sb, symb);

            Console.WriteLine(" Отредактированный текст:");
            Console.WriteLine(sb);
        }
        static void UpperCase(StringBuilder sb, StringBuilder symb)
        {
            for (int i = 0; i < sb.Length; i++)                             // массив строк
            {
                if (i == 0 && ((int)sb[i] >= 97 && (int)sb[i] <= 122))      // если первый символ начинается с буквы нижнего регистра,
                {
                    sb[i] = (char)((int)sb[i] - 32);                        // то меняем его на букву верхнего регистра
                }
                for (int x = 0; x < symb.Length; x++)                       // массив знаков окончания предложения
                {
                    if (sb[i] == symb[x] &&                                 // если в строке найден символ конца предложения
                        (int)sb[i + 1] >= 97 && (int)sb[i + 1] <= 122)      // и следующий символ в строке начинается с буквы нижнего регистра,
                    {
                        sb[i + 1] = (char)((int)sb[i + 1] - 32);            // то меняем его на букву верхнего регистра
                    }
                    else if (sb[i] == symb[x] && (int)sb[i + 1] == 32 &&    // если в строке найден символ конца предложения и след. символ - пробел, 
                        ((int)sb[i + 2] >= 97 && (int)sb[i + 2] <= 122))    // и следующий символ в строке после пробела начинается с буквы нижнего регистра,
                    {
                        sb[i + 2] = (char)((int)sb[i + 2] - 32);            // то меняем его на букву верхнего регистра
                    }
                }
            }
        }
    }
}
