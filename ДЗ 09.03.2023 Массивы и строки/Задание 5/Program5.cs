using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_5
{
    internal class Program5
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Задание 5. Арифметическое выражение");


            Console.WriteLine(" Введите арифметическое выражение с '+' или '-'");
            StringBuilder exp = new StringBuilder(Console.ReadLine());
            Console.WriteLine(exp);


            for (int i = 0; i < exp.Length; i++)
            {
                if (((int)exp[i] < 48 || (int)exp[i] > 57) &&                         // если текущий символ не является буквой или "+" или "-"
                   (int)exp[i] != 43 && (int)exp[i] != 45)
                {
                    exp.Remove(i, 1);                                                 // удаляем данный символ
                    i--;
                }
            }
            for (int i = 0; i < exp.Length; i++)                                      // выполняем проверку введенного выражения и удаляем лишние символы
            {
                if (exp[0] == '+' || exp[0] == '-')                                   // если первый символ является "+" или "-"
                {
                    exp.Remove(i, 1);                                                 // удаляем данный символ
                    i--;
                    continue;
                }

                else if (exp[i] == '+' && (exp[i + 1] == '+' || exp[i + 1] == '-'))   // если текущий сивол "+" и след. символ "+" или "-"
                {
                    exp.Remove(i + 1, 1);                                             // удаляем след. символ, остается только "+"
                    i--;
                }
                else if (exp[i] == '-' && (exp[i + 1] == '-' || exp[i + 1] == '+'))   // если текущий сивол "-" и след. символ "+" или "-"
                {
                    exp.Remove(i + 1, 1);                                             // удаляем след. символ, остается только "-"
                    i--;
                }
                else if ((exp[exp.Length - 1]) == '-' || exp[exp.Length - 1] == '+')    // если последний символ "+" или "-" 
                {
                    exp.Remove(exp.Length - 1, 1);                                    // удаляем его 
                    i--;
                }
            }
            // в итоге остается правильное выражение
            string strExp = Convert.ToString(exp);
            if (!strExp.Contains("+") && !strExp.Contains("-"))  // если строка не соддержит + или -
            {                                                    // выводим сообщение и выход
                Console.WriteLine(" Выражение не содержит арифметической операции! ");
                return;
            }
            Console.WriteLine(" Арифметическое выражение " + exp);

            int size = 10; // размер массива
            int ind = 0;   // индекс массива
            int[] ar = new int[size]; // массив для хранения чисел из выражения

            string strng = ""; // строка для записи отдельного числа из выражения

            for (int i = 0; i < exp.Length; i++)
            {
                if ((int)exp[i] >= 48 && (int)exp[i] <= 57)  // если текущий символ - цифра
                {
                    strng += Convert.ToString(exp[i]);       // записываем цифру в строку
                    exp.Remove(i, 1);                        // удаляем цифру из массива-выражения
                    i--;
                    if (i + 1 == exp.Length || // если след. символ выражения "+" или "-"
                        exp[i + 1] == '-' || // или конец массива
                        exp[i + 1] == '+')
                    {
                        ar[ind] = Convert.ToInt32(strng);    // записываем полученное число из строки                 
                        ind++;                               // увеличиваем индекс числового массива
                        strng = "";                          // опустошаем строку для записи нового числа
                    }
                }
            }
            // в итоге в выражении остались только "+" "-"

            int res = ar[0];
            int t = 0;
            for (int i = 1; i < ar.Length; i++)
            {
                if (exp[t] == '+')
                {
                    res += ar[i];
                }
                else if (exp[t] == '-')
                {
                    res -= ar[i];
                }
                if (t != exp.Length - 1) t++;
            }
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(" Результат " + res);
            Console.ResetColor();
        }
    }
}
