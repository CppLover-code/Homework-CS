using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_3
{
    internal class Program3
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Задание 3. Шифр Цезаря для кириллицы");

            Console.WriteLine(" Введите строку, которую необходимо зашифровать: ");

            StringBuilder str = new StringBuilder(Console.ReadLine());               // для ввода строки

            int key = 0;                                                             // цифра-ключ для сдвига
            while (true)                                                             // цикл работает, пока не введут 
            {                                                                        // цифру в диапазоне от 1 до 10
                Console.WriteLine(" Введите цифру-ключ для шифрования от 1 до 10:");

                while (!int.TryParse(Console.ReadLine(), out key))                   // пока вводимый символ не является цифрой
                {
                    Console.WriteLine(" Ошибочный ввод! Введите целое число:");      // выводим сообщение, иначе в key запишется цифра
                }
                if (key >= 1 && key <= 10) break;                                    // если цифра входит в диапазон - стоп цикл,           
                else Console.WriteLine(" Ошибочный ввод! ");                         // иначе выводим сообщение об ошибке

            }

            int side;                                                                // сторона сдвига
            while (true)
            {
                Console.WriteLine(" Выберите сторону сдвига: \n 1 - вправо \n 2 - влево");

                while (!int.TryParse(Console.ReadLine(), out side))
                {
                    Console.WriteLine(" Ошибочный ввод! Введите целое число:");
                }
                if (side == 1 || side == 2) break;
                else Console.WriteLine(" Ошибочный ввод! ");
            }

            if (side == 1)                                  // если сдвиг вправо
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] >= 1040 && str[i] <= 1103)  // если символ является кириллицей
                    {                                      // temp(хранит код символа-шифра)
                        int temp = str[i] + key;           // временная переменная равна сумме кода текущего символа и ключа
                        if (temp > 1103)                   // если temp символ больше буквы 'я'
                        {
                            temp -= 1103;                  // находим разницу temp и буквы 'я'
                            temp += 1040 - 1;              // эту разницу суммируем к коду 'А' - 1
                        }
                        str[i] = (char)temp;               // "заменяем" настоящую букву полученным шифром 
                    }
                    else continue;                         // иначе, если текущий символ не является буквой кириллицы,
                }                                          // пропускаем обработку данного символа
            }
            else if (side == 2)                            // если сдвиг влево
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] >= 1040 && str[i] <= 1103)
                    {
                        int temp = str[i] - key;
                        if (temp < 1040)
                        {
                            temp = 1040 - temp;
                            temp = 1103 - temp + 1;
                        }
                        str[i] = (char)temp;
                    }
                    else continue;

                }
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n Зашифрованное сообщение " + (char)9660);
            Console.ResetColor();
            Console.WriteLine(str);


            //Console.WriteLine(" Дешифратор для кириллицы");
            // Дешифратор работает аналогично шифровке, только наоборот.
            // Если шифровка была вправо, то расшифровывать нужно справа налево.
            // Если влево - то слева направо. Все действия с учётом цифры-ключа!

            if (side == 1)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] >= 1040 && str[i] <= 1103)
                    {
                        int temp = str[i] - key;
                        if (temp < 1040)
                        {
                            temp = 1040 - temp;
                            temp = 1103 - temp + 1;
                        }
                        str[i] = (char)temp;
                    }
                    else continue;
                }
            }
            else if (side == 2)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] >= 1040 && str[i] <= 1103)
                    {
                        int temp = str[i] + key;
                        if (temp > 1103)
                        {
                            temp -= 1103;
                            temp += 1040 - 1;
                        }
                        str[i] = (char)temp;
                    }
                    else continue;
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n Расшифрованное сообщение " + (char)9660);
            Console.ResetColor();
            Console.WriteLine(str);
        }
    }
}
