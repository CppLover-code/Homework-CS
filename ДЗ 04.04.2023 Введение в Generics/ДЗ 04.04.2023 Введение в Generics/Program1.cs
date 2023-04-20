namespace ДЗ_04._04._2023_Введение_в_Generics
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Менеджмент сотрудников и паролей");

            var manage = new Dictionary<(Employee, string), string>()
            {
                [(new Employee("Иванов Иван"), "vanya")] = "In3R5_qw",
                [(new Employee("Петров Петр"), "petro")] = "ie7TREnt",
            };

            Console.WriteLine("База данных содержит: ");
            foreach (var j in manage)
                Console.WriteLine("Имя -> {0}  Логин -> {1} Пароль -> {2}", j.Key.Item1, j.Key.Item2, j.Value);

            Console.WriteLine(" Меню операций");
            Console.WriteLine(" 1 - Добавление логина и пароля\n 2 - Удаление логина\n" +
                " 3 - Изменение логина и пароля\n 4 - Получение информации о пароле\n " +
                " 0 - Выход\n");


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
}