using System.Collections.Generic;
using System.ComponentModel.Design;
using static System.Reflection.Metadata.BlobBuilder;

namespace ДЗ_04._04._2023_Введение_в_Generics
{
    internal class Program1
    {
        static void Main(string[] args)
        {                 
            Management management = new Management(new Employee("Иванов Иван"), "vanya95","In3R5_qw");
            management.Add(new Employee("Петров Петр"), "petya97", "Otr390_t_");
            management.Add(new Employee("Семенов Семен"), "semen90", "_Ui48y0_qe");
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("\t\t\tМенеджмент сотрудников (логины и пароли)");
                Console.WriteLine(" Меню операций");
                Console.WriteLine(" 1 - Показать базу данных\n 2 - Добавление логина и пароля\n" +
                    " 3 - Удаление логина\n 4 - Изменение логина и пароля\n" +
                    " 5 - Получение информации о пароле\n 0 - Выход\n");

                Console.Write(" Сделайте выбор: ");
                int choice = -1;
                try
                {
                    try { choice = int.Parse(Console.ReadLine()!); }
                    catch { throw new FormatException(" Некорректный ввод!\n"); }

                    if (choice < 0 || choice > 5)
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
                        management.Output();
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 2:
                        management.Add();
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 3:
                        management.Delete();
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 4:
                        management.Change();
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 5:
                        management.PasInfo();
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 0:
                        return;
                }
            }        
        }
        
    }
    public class Employee
    {
        public string? Name { get; set; }
        public Employee ()
        {
            Console.WriteLine(" Введите фамилию и имя сотрудника ");
            Name = Console.ReadLine();
        }
        public Employee(string name)
        {
            this.Name = name;
        }
    }  

    public class Management
    {
        private Dictionary<(Employee, string), string> manage;
        public Dictionary<(Employee, string), string> man
        {
            get { return manage; }
            set { manage = value; }
        }
        public Management() 
        { 
            var emp = new Employee();
            Console.WriteLine(" Введите логин:");
            string log = Console.ReadLine()!;
            Console.WriteLine(" Введите пароль:");
            string pas = Console.ReadLine()!;

            manage = new Dictionary<(Employee, string), string>()
            {
                [(emp, log)] = pas
            };
        }
        public Management(Employee emp, string log, string pas)
        {
            manage = new Dictionary<(Employee, string), string>()
            {
                [(emp, log)] = pas
            };
        }
        public void Output()
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
        public void Add()
        {
            Console.WriteLine("-Добавление логина и пароля и сотрудника-\n");
            var emp = new Employee();
            string log = CheckLog();
            string pas = CheckPas();
            manage.Add((emp,log),pas);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Данные успешно добавлены!");
            Console.ResetColor();
        }
        public void Add(Employee emp, string log, string pas)
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
            foreach ((Employee,string) c in manage.Keys)
            {
                if(c.Item1.Name == del) flag = true;
            }

            if (flag)
            {
                foreach (var j in manage)
                {
                    if (j.Key.Item1.Name == del)
                    {
                        manage.Remove(j.Key);
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

                        var old = j.Key.Item1;
                        manage.Remove(j.Key);
                        manage.Add((old,log),pas);
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