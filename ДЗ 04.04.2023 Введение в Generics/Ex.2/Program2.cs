namespace Ex._2
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Vocabulary Vocabulary = new Vocabulary();
            Vocabulary.Add("яблоко", ЛИСТ);
            Vocabulary.Add("голова", ЛИСТ);
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("\t\t\tАнгло-русский словарь");
                Console.WriteLine(" Меню операций");
                Console.WriteLine(" 1 - Показать словарь\n 2 - Добавление слово и перевод\n" +
                    " 3 - Удалить слово\n 4 - Удалить вариант перевода\n 5 - Изменить слово\n" +
                    " 6 - Изменить вариант перевода\n 7 - Поиск варианта перевода\n 0 - Выход\n");

                Console.Write(" Сделайте выбор: ");
                int choice = -1;
                try
                {
                    try { choice = int.Parse(Console.ReadLine()!); }
                    catch { throw new FormatException(" Некорректный ввод!\n"); }

                    if (choice < 0 || choice > 7)
                        throw new Exception(" Некорректный ввод!\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                    Console.Clear();
                }

                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        Vocabulary.Output();
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 2:
                        Vocabulary.Add();
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 3:
                        Vocabulary.Delete();
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 4:
                        Vocabulary.Change();
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 5:
                        Vocabulary.PasInfo();
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 0:
                        return;
                }
            }
        }

        public class Vocabulary
        {
            private Dictionary<string, string> manage;
            public Dictionary<string, string> man
            {
                get { return manage; }
                set { manage = value; }
            }
            public Vocabulary() // конструктор без параметров, ввод с клавиатуры
            {
                var emp = new Employee();
                Console.WriteLine(" Введите логин:");
                string log = Console.ReadLine()!;
                Console.WriteLine(" Введите пароль:");
                string pas = Console.ReadLine()!;

                manage = new Dictionary<string, string>()
                {
                    [string] = pas
                };
            }
            public Vocabulary(string, string pas) // конструктор с параметрами
            {
                manage = new Dictionary<(Employee, string), string>()
                {
                    [(emp, log)] = pas
                };
            }
            public void Output() // форматированный вывод на экран всех сотрудников с данными
            {
                Console.WriteLine("-База данных сотрудников-\n");
                int count = 1;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("№  Имя\t\t\tЛогин\t\tПароль\t\t");
                Console.ResetColor();
                foreach (var j in manage)
                {
                    Console.WriteLine("{0}. {1,-15} {2,12} \t{3,6}", count, j.Key.Item1.Name, j.Key.Item2, j.Value);
                    count++;
                }
            }
            public void Add() // добавление с вводом
            {
                Console.WriteLine("-Добавление логина и пароля и сотрудника-\n");
                var emp = new Employee();
                string log = CheckLog();
                string pas = CheckPas();
                manage.Add((emp, log), pas);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Данные успешно добавлены!");
                Console.ResetColor();
            }
            public void Add(Employee emp, string log, string pas) // добавление без ввода (параметры)
            {
                manage.Add((emp, log), pas);
            }
            public void Delete()
            {
                Output();
                Console.WriteLine("-Удаление сотрудника-\n");
                Console.WriteLine(" Введите фамилию и имя сотрудника:");
                string del = Console.ReadLine()!;
                bool flag = false;
                foreach ((Employee, string) c in manage.Keys)
                {
                    if (c.Item1.Name == del) flag = true;  // проверка есть ли данный сотрудник в базе
                }

                if (flag)   // если совпадение найдено
                {
                    foreach (var j in manage)
                    {
                        if (j.Key.Item1.Name == del)
                        {
                            manage.Remove(j.Key); // удаляем ключ
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Сотрудник успешно удалён из базы!");
                            Console.ResetColor();
                            break;
                        }
                    }
                }
                else { Console.WriteLine($" Сотрудника {del} нет в базе!"); }

            }
            public void Change()
            {
                Output();
                Console.WriteLine("-Изменение логина и пароля сотрудника-\n");
                Console.WriteLine(" Введите фамилию и имя сотрудника:");
                string ch = Console.ReadLine()!;
                bool flag = false;
                foreach ((Employee, string) c in manage.Keys)
                {
                    if (c.Item1.Name == ch) flag = true;
                }

                if (flag)
                {
                    foreach (var j in manage)
                    {
                        if (j.Key.Item1.Name == ch)
                        {
                            string log = CheckLog();
                            string pas = CheckPas();

                            var old = j.Key.Item1;      // сохраняем сотрудника(фио)
                            manage.Remove(j.Key);       // удаляем из коллекции текущий элемент
                            manage.Add((old, log), pas);  // добавляем новый элемент с новым логином и паролем, но со старой ФИО
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Данные успешно изменены!");
                            Console.ResetColor();
                            break;
                        }
                    }
                }
                else { Console.WriteLine($" Сотрудника {ch} нет в базе!"); }
            }
            public void PasInfo()
            {
                Output();
                Console.WriteLine("-Получение информации о пароле сотрудника-\n");
                Console.WriteLine(" Введите фамилию и имя сотрудника:");
                string ch = Console.ReadLine()!;
                bool flag = false;
                foreach ((Employee, string) c in manage.Keys)
                {
                    if (c.Item1.Name == ch) flag = true;
                }

                if (flag)
                {
                    foreach (var j in manage)
                    {
                        if (j.Key.Item1.Name == ch)
                        {
                            Console.WriteLine($" Пароль: {j.Value}");
                            break;
                        }
                    }
                }
                else { Console.WriteLine($" Сотрудника {ch} нет в базе!"); }
            }
            static string CheckLog()
            {
                string log;
                while (true)
                {
                    Console.WriteLine(" Введите логин (не менее 7, не более 10 символов):");
                    try
                    {
                        log = Console.ReadLine()!;
                        if (log.Length < 7 || log.Length > 10)
                        {
                            throw new Exception(" Неверное кол-во символов!");
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                return log;
            }
            static string CheckPas()
            {
                string pas;
                while (true)
                {
                    Console.WriteLine(" Введите пароль (не менее 8 символов, не более 12):");
                    try
                    {
                        pas = Console.ReadLine()!;
                        if (pas.Length < 8 || pas.Length > 12)
                        {
                            throw new Exception(" Неверное кол-во символов!");
                        }
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                return pas;
            }
        }

    }
}