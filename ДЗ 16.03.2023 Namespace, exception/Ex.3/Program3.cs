using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex._3
{
    internal class Program3
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" International passport\n");   
            InterPas passport = new InterPas();
            passport.Output();

        }
        struct Date
        {
            public int day;
            public int month;
            public int year;

            public void InputDate()
            {
                bool flag = false;

                while (!flag) // цикл работает пока пользователь вводит некорректную дату
                {
                    Console.WriteLine(" Enter date of issue of the passport (day, month, year):");
                    try
                    {
                        day = int.Parse(Console.ReadLine());
                        month = int.Parse(Console.ReadLine());
                        year = int.Parse(Console.ReadLine());
                        flag = CheckDate(day, month, year);
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }                      
                }                                     
            }
            public void OutputDate()
            {
                Console.WriteLine($" Date of issue of the passport: {day}.{month}.{year}\n");
            }
        }
        public static bool isLeap(int year)                         // функция для определения, високосным ли является год
        {
            if (year % 400 == 0) return true;                       // если год кратен 400, то он високосный
            if (year % 4 == 0 && year % 100 != 0) return true;      // если год кратен 4, но в то же время не кратен 100, то он тоже високосный
            return false;
        }
        public static bool CheckDate(int d, int m, int y)           // проверка корректности полной даты
        {
            if (((isLeap(y)) && (m == 2) && (d > 0 && d <= 29))     // если год високосный
                || ((isLeap(y)) && (m == 1 || m == 3 || m == 5 || m == 7 || m == 8 || m == 10 || m == 12) && (d > 0 && d <= 31))
                || ((isLeap(y)) && (m == 4 || m == 6 || m == 9 || m == 11) && (d > 0 && d <= 30))

                || (!(isLeap(y)) && (m == 2) && (d > 0 && d <= 28)) // если год не високосный
                || (!(isLeap(y)) && (m == 1 || m == 3 || m == 5 || m == 7 || m == 8 || m == 10 || m == 12) && (d > 0 && d <= 31))
                || (!(isLeap(y)) && (m == 4 || m == 6 || m == 9 || m == 11) && (d > 0 && d <= 30)))
            {
                return true;
            }
            else
            {
                Console.WriteLine(" Incorrect date!");
                return false;
            }
        }

        class InterPas
        {
            readonly string pasId;      // серия и номер паспорта
            readonly string firstName;  // имя
            readonly string lastName;   // фамилия
            readonly Date date;         // дата выдачи

            public InterPas()
            {
                pasId = InputPasId();
                firstName = InputFLN("first");
                lastName = InputFLN("last");
                date.InputDate();
            }
            public void Output()
            {
                Console.WriteLine(" Passport Information");
                Console.WriteLine(" Passport ID: " + pasId);
                Console.WriteLine(" First name: " +  firstName);
                Console.WriteLine(" Last name: " +  lastName);
                date.OutputDate();
            }
        }

        public static string InputPasId()  // ввод серии и номера паспорта
        {
            bool k;
            string str = "";
            do                                                                  // пока не введены корректные данные
            {
                k = false;
                Console.WriteLine(" Enter the series and number of the passport:");

                try
                {
                    str = Console.ReadLine();
                    char[] ch = str.ToCharArray();

                    if (str.Length != 9)                                        // если длина строки не равна 9
                    {
                        throw new Exception(" Incorrect length input!\n");
                    }
                    else if (!Char.IsLetter(ch[0]) || !Char.IsLetter(ch[1]))    // если первые два символа не буквы
                    {
                        throw new Exception(" Incorrect letter input!\n");
                    }

                    for (int i = 2; i < ch.Length; i++)
                    {
                        if (!Char.IsDigit(ch[i]))                               // если с 3 по 9 символ не цифры
                        {
                            throw new Exception(" Incorrect digit input!\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    k = true;
                }
            } while (k);

            return str;
        }
        public static string InputFLN(string s)     // ввод имени/фамилии  
        {
            bool k;
            string str = "";
            do                                                           // пока не введены корректные данные
            {
                k = false;
                Console.WriteLine($" Enter {s} name:");

                try
                {
                    str = Console.ReadLine();
                    char[] ch = str.ToCharArray();

                    if (str.Length < 2)                                 // если длина имени меньше двух букв
                    {
                        throw new Exception(" Incorrect length input!");
                    }
                    else if (Char.IsLower(ch[0]))                       // если первая буква маленькая
                    {
                        throw new Exception(" Incorrect input - lower case!");
                    }

                    for (int i = 0; i < ch.Length; i++)
                    {
                        if (!Char.IsLetter(ch[i]))                      // если не буква
                        {
                            throw new Exception(" Incorrect letter input!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    k = true;
                }

            } while (k);

            return str;
        }
    }
}
