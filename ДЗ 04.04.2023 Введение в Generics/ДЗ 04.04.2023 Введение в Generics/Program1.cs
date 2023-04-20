using System.Collections.Generic;
using System.ComponentModel.Design;
using static System.Reflection.Metadata.BlobBuilder;

namespace ДЗ_04._04._2023_Введение_в_Generics
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Менеджмент сотрудников и паролей");           
 
            Management management = new Management(new Employee("Иванов Иван"), "vanya95","In3R5_qw");
            management.Add(new Employee("Петров Петр"), "petya97", "Otr390_t_");
            management.Add(new Employee("Семенов Семен"), "semen90", "_Ui48y0_qe");
            Console.WriteLine(" Меню операций");
            Console.WriteLine(" 1 - Добавление логина и пароля\n 2 - Удаление логина\n" +
                " 3 - Изменение логина и пароля\n 4 - Получение информации о пароле\n " +
                " 0 - Выход\n");

            management.Output();

            management.Add();
            management.Output();

            management.Delete();
            management.Output();

            management.Change();
            management.Output();

            management.PasInfo();
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
            Console.WriteLine("База данных содержит: ");
            int count = 1;
            foreach (var j in manage)
            {
                Console.WriteLine("{0}.Имя: {1}  \t|Логин: {2} \t|Пароль: {3}", count, j.Key.Item1.Name, j.Key.Item2, j.Value);
                count++;
            }     
        }
        public void Add()
        {
            Console.WriteLine("Добавление логина и пароля и сотрудника: ");
            var emp = new Employee();
            Console.WriteLine(" Введите логин:");
            string log = Console.ReadLine()!;
            Console.WriteLine(" Введите пароль:");
            string pas = Console.ReadLine()!;
            manage.Add((emp,log),pas);
        }
        public void Add(Employee emp, string log, string pas)
        {
            manage.Add((emp, log), pas);
        }
        public void Delete()
        {
            Console.WriteLine(" Введите фамилию и имя сотрудника для удаления:");
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
                    }
                }
            }
            else { Console.WriteLine($" Сотрудника {del} нет в базе!"); }
  
        }
        public void Change()
        {
            Console.WriteLine(" Введите фамилию и имя сотрудника для изменения логина и пароля:");
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
                        Console.WriteLine(" Введите новый логин:");
                        string log = Console.ReadLine()!;
                        Console.WriteLine(" Введите новый пароль:");
                        string pas = Console.ReadLine()!;

                        var old = j.Key.Item1;
                        manage.Remove(j.Key);
                        manage.Add((old,log),pas);
                        break;
                    }
                }
            }
            else { Console.WriteLine($" Сотрудника {ch} нет в базе!"); }
        }
        public void PasInfo()
        {
            Console.WriteLine(" Введите фамилию и имя сотрудника для получения пароля:");
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
                        Console.Write($" Пароль: {j.Value}");
                        break;
                    }
                }
            }
            else { Console.WriteLine($" Сотрудника {ch} нет в базе!"); }
        }
    }
}