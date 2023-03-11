using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ДЗ_07._03._2023_Введение_в_С_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Задание 1. Кратность чисел ");
            int numb = 0;
            do                                                     // цикл работает, пока пользователь не введёт корректное число
            {
                Console.WriteLine(" Введите число от 1 до 100: ");
                numb = Int32.Parse(Console.ReadLine());            // ввод числа из строки в int

                if (numb < 1 || numb > 100)                        // если введённое число не входит в диапазон от 1 до 100
                {
                    Console.WriteLine(" Ошибочный ввод!");         // выводим сообщение об ошибке
                }

            } while (numb < 1 || numb > 100);

            if (numb % 3 == 0 && numb % 5 == 0)                     // если введенное число кратно 3 и 5
            {
                Console.WriteLine("Fizz Buzz");
            }
            else if (numb % 3 == 0)                                 // если число кратно 3
            {
                Console.WriteLine("Fizz");
            }
            else if (numb % 5 == 0)                                // если число кратно 5
            {
                Console.WriteLine("Buzz");
            }
            else                                                   // если ни одно из условий не вернуло true,
            {                                                      // выводим само введенное число
                Console.WriteLine(numb);
            }

            Console.WriteLine("----------------------------");

            Console.WriteLine(" Задание 2. Найти процент от числа ");

            Console.WriteLine(" Введите число:");
            double n = Double.Parse(Console.ReadLine());

            Console.WriteLine(" Введите число-процент, которое нужно посчитать:");
            double p = Double.Parse(Console.ReadLine());

            // {Math.Round (n * (p / 100), 2)} - округляем результат до 2 чисел после запятой
            Console.WriteLine($" Результат: {p} % от {n} = {Math.Round(n * (p / 100), 2)}");

            Console.WriteLine("----------------------------");

            Console.WriteLine(" Задание 3. Создать число из 4-ёх разных цифр ");

            Console.WriteLine(" Введите четыре цифры по порядку:");

            int n1 = Int32.Parse(Console.ReadLine());
            int n2 = Int32.Parse(Console.ReadLine());
            int n3 = Int32.Parse(Console.ReadLine());
            int n4 = Int32.Parse(Console.ReadLine());

            string s = n1.ToString() + n2.ToString() + n3.ToString() + n4.ToString(); // записали числа в строку
            int res = Int32.Parse(s);  // преобразование String к Int
            Console.WriteLine($" Результат: {res}");

            Console.WriteLine("----------------------------");

            Console.WriteLine(" Задание 4. Обмен цифр в 6-значном числе ");

            int number = 0;
            do                                                     // цикл работает, пока пользователь не введёт корректное число
            {
                Console.WriteLine(" Введите 6-значное число: ");
                number = Int32.Parse(Console.ReadLine());          // ввод числа из строки в int

                if (CountDigit(number) != 6)                       // если введённое число не шестизначное
                {
                    Console.WriteLine(" Ошибочный ввод!");         // выводим сообщение об ошибке
                }

            } while (CountDigit(number) != 6);

            Console.WriteLine(" Введите номера разрядов для обмена цифр:");

            Console.WriteLine(" - первый номер ");
            int r1 = Int32.Parse(Console.ReadLine());

            Console.WriteLine(" - второй номер ");
            int r2 = Int32.Parse(Console.ReadLine());

            StringBuilder sb = new StringBuilder().Append(number); // 6-значное число в string builder

            char s1 = sb[r1 - 1];  // сохраняем в переменную первый символ
            char s2 = sb[r2 - 1];  // сохраняем в переменную второй символ

            sb[r1 - 1] = s2;     // меняем местами символы по индексам
            sb[r2 - 1] = s1;

            string str = sb.ToString(); // конвертируем string builder в string
            number = Int32.Parse(str);  // конвертируем результат в int
            Console.WriteLine($" Результат: {number}");

            Console.WriteLine("----------------------------");

            Console.WriteLine(" Задание 5. Дата - сезон и день недели ");

            int year, month, day;
            Console.WriteLine(" Введите дату (год, месяц, день:");
            year = Int32.Parse(Console.ReadLine());
            month = Int32.Parse(Console.ReadLine());
            day = Int32.Parse(Console.ReadLine());

            DateTime date = new DateTime(year, month, day);  // создаем объект класса DateTime

            if (month == 12 || month == 1 || month == 2)                  // в условиях проверяем принадлежность месяцев к сезону
                Console.WriteLine("Result: Winter " + date.DayOfWeek);    // и определяем с помощью свойства .DayOfWeek день недели
            else if (month == 3 || month == 4 || month == 5)
                Console.WriteLine("Result: Spring " + date.DayOfWeek);
            else if (month == 6 || month == 7 || month == 8)
                Console.WriteLine("Result: Summer " + date.DayOfWeek);
            else if (month == 9 || month == 10 || month == 11)
                Console.WriteLine("Result: Autumn " + date.DayOfWeek);

            Console.WriteLine("----------------------------");

            Console.WriteLine(" Задание 6. Показания температуры ");

            Console.WriteLine(" Введите показания температуры:");
            double tmpr = Double.Parse(Console.ReadLine());

            Console.WriteLine(" Выберите шкалу:");
            Console.WriteLine(" 1 - из Фаренгейта в Цельсий");
            Console.WriteLine(" 2 - из Цельсия в Фаренгейт");
            short choice = short.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine($" Результат: {Math.Round((tmpr - 32) * 5 / 9, 2)} °C");
                    break;

                case 2:
                    Console.WriteLine($" Результат: {Math.Round((tmpr * 1.8) + 32, 2)} °F");
                    break;
            }

            Console.WriteLine("----------------------------");

            Console.WriteLine(" Задание 7. Чётные числа в диапазоне, включая начало и конец ");

            Console.WriteLine(" Введите начало диапазона: ");
            int start = Int32.Parse(Console.ReadLine());

            Console.WriteLine(" Введите конец диапазона: ");
            int end = Int32.Parse(Console.ReadLine());

            if(start > end)         // если начальное значение больше конечного,
            {                       // то меняем значения переменных местами
                int temp = start;
                start = end;
                end = temp;
            }
            else if(start == end)  // если начало и конец совпадают,
            {                      // выводим сообщение и выходим из программы
                Console.WriteLine(" Чисел в данном диапазоне нет!");
                return;
            }

            int [] arr = new int [end - start + 1];                 // массив для хранения диапазона чисел
            int st = start;                                          // переменная для хранения начального значения

            // заполняем массив, увеличивая начальное значение
            for (int i = 0; i < arr.Length; i++, st++) arr[i] = st;

            Console.WriteLine(" Чётные числа диапазона: ");
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] % 2 == 0) Console.Write(arr[i] + " ");   // число чётное, если делится на 2 без остатка
        
            Console.WriteLine();
        }
        public static int CountDigit(int n)  // функция для подсчёта цифр в числе
        {
            int count = 0;
            while (n > 0)
            {
                n/= 10;
                count++;
            }
            return count;
        }
    }
}
