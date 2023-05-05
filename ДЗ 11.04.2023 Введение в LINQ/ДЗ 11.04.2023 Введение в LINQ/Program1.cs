using System.ComponentModel;

namespace ДЗ_11._04._2023_Введение_в_LINQ
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            Console.Title = "LINQ запросы";
            
            Companies companies = new Companies(FillCompanies());

            int choice;
            while (true)
            {
                Console.WriteLine("\tМеню\n" +
                    " 1.Получить информацию обо всех фирмах\n" +
                    " 2.Получить фирмы, у которых в названии есть слово Food\n" +
                    " 3.Получить фирмы, которые работают в области маркетинга\n" +
                    " 4.Получить фирмы, которые работают в области маркетинга или IT\n" +
                    " 5.Получить фирмы с количеством сотрудников, большем 6\n" +
                    " 6.Получить фирмы с количеством сотрудников в диапазоне от 5 до 10\n" +
                    " 7.Получить фирмы, которые находятся в Лондоне\n" +
                    " 8.Получить фирмы, у которых фамилия директора White\n" +
                    " 9.Получить фирмы, которые основаны больше двух лет назад\n" +
                    " 10.Получить фирмы со дня основания, которых прошло 123 дня\n" +
                    " 11.Получить фирмы, у которых фамилия директора Black и название фирмы содержит слово White\n" +
                    " 12.Получить всех сотрудников конкретной фирмы\n" +
                    " 13.Получить всех сотрудников конкретной фирмы, у которых заработные платы больше заданной\n" +
                    " 14.Получить сотрудников всех фирм, у которых должность менеджер\n" +
                    " 15.Получить сотрудников, у которых телефон начинается с 23\n" +
                    " 16.Получить сотрудников, у которых Email начинается с di\n" +
                    " 17.Получить сотрудников, у которых имя Lionel\n" +
                    " 0 - выход\n");
                while (true)
                {
                    Console.Write(" Сделайте выбор: ");
                    try
                    {
                        choice = int.Parse(Console.ReadLine()!);
                        if (choice < 0 || choice > 17)
                        {
                            throw new Exception(" Некорректный выбор!");
                        }
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine(" Некорректный ввод!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                switch (choice)
                {
                    case 0:
                        return;

                    case 1:
                        companies.ShowCompanies();
                        break;
                    case 2:
                        companies.TitleFood();
                        break;
                    case 3:
                        companies.ProfileMarketing();
                        break;
                    case 4:
                        companies.ProfileMarketingOrIt();
                        break;
                    case 5:
                        companies.EmployeesMore6();
                        break;
                    case 6:
                        companies.Employees5_10();
                        break;
                    case 7:
                        companies.AddressLondon();
                        break;
                    case 8:
                        companies.SurnameWhite();
                        break;
                    case 9:
                        companies.DateMore2();
                        break;
                    case 10:
                        companies.DateMore123Day();
                        break;
                    case 11:
                        companies.DirectorBlackCompanyWhite();
                        break;
                    case 12:
                        companies.CompanyEmployees();
                        break;
                    case 13:
                        companies.CompanyEmployeesSalaryMore();
                        break;
                    case 14:
                        companies.CompanyEmployeesManager();
                        break;
                    case 15:
                        companies.CompanyEmployeesPhone23();
                        break;
                    case 16:
                        companies.CompanyEmployeesEmailDi();
                        break;
                    case 17:
                        companies.CompanyEmployeesNameLionel();
                        break;
                }
                Console.WriteLine(" Для продолжения нажмите Enter!");
                Console.ReadLine();
                Console.Clear();
            }

        }
        class Companies
        {
            public List<Company> companies = new();
            public Companies() { }
            public Companies(List<Company> list)
            {
                this.companies = list;
            }
            public void ShowCompanies()   // Получить информацию обо всех фирмах
            {
                int id = 1;
                foreach(var item in companies)
                {
                    Console.WriteLine($"-Компания {id}-");
                    Console.WriteLine(item);
                    id++;
                }              
            }
            public void TitleFood()
            {
                var Res = from item in companies
                          where item.Title!.ToLower().Contains("Food".ToLower())
                          select item;
                foreach (var item in Res)
                    Console.WriteLine(item);
            }
            public void ProfileMarketing()
            {
                var Res = from item in companies
                          where item.Profile!.ToLower().Contains("Marketing".ToLower())
                          select item;
                foreach (var item in Res)
                    Console.WriteLine(item);
            }
            public void ProfileMarketingOrIt()
            {
                var Res = from item in companies
                          where item.Profile!.ToLower().Contains("Marketing".ToLower()) || item.Profile!.Contains("IT")
                          select item;
                foreach (var item in Res)
                    Console.WriteLine(item);
            }
            public void EmployeesMore6()
            {
                var Res = from item in companies
                          where item.CountEmployees > 6
                          select item;
                foreach (var item in Res)
                    Console.WriteLine(item);
            }
            public void Employees5_10()
            {
                var Res = from item in companies
                          where item.CountEmployees >= 5 && item.CountEmployees <= 10
                          select item;
                foreach (var item in Res)
                    Console.WriteLine(item);
            }
            public void AddressLondon()
            {
                var Res = from item in companies
                          where item.Address!.ToLower().Contains("London".ToLower())
                          select item;
                foreach (var item in Res)
                    Console.WriteLine(item);
            }
            public void SurnameWhite()
            {
                var Res = from item in companies
                          where item.Director!.ToLower().Contains("White".ToLower())
                          select item;
                foreach (var item in Res)
                    Console.WriteLine(item);
            }
            public void DateMore2()
            {
                var Res = from item in companies
                          where item.Date!.Value.Year < (DateTime.Now.Year - 2)
                          select item;
                foreach (var item in Res)
                    Console.WriteLine(item);
            }
            public void DateMore123Day()
            {
                var Res = from item in companies
                          let v = DateTime.Today - item.Date
                          where v.Value.Days >= 123
                          select item;

                foreach (var item in Res)
                    Console.WriteLine(item);                   
            }
            public void DirectorBlackCompanyWhite()
            {
                var Res = from item in companies
                          where item.Director!.ToLower().Contains("Black".ToLower()) 
                          && item.Title!.ToLower().Contains("White".ToLower())
                          select item;
                foreach (var item in Res)
                    Console.WriteLine(item);
            }
            public void CompanyEmployees()
            {
                Console.Write(" Введите название фирмы: ");
                string str = Console.ReadLine()!;
                var Res = from item in companies
                          where item.Title!.ToLower().Contains(str.ToLower())
                          select item;
                foreach (var item in Res)
                    item.ShowEmployees();
            }
            public void CompanyEmployeesSalaryMore()
            {
                Console.Write(" Введите название фирмы: ");
                string str = Console.ReadLine()!;
                Console.Write(" Введите минимальную зарплату: ");
                double salary = double.Parse(Console.ReadLine()!);

                var Res = from item in companies
                          where item.Title!.ToLower().Contains(str.ToLower())
                          select item;

                foreach (var item in Res)
                {
                    Console.WriteLine($" Сотрудники компании {item.Title}, чья зарплата больше {salary}$");
                    var Res1 = from i in item.Employees
                               select i;

                    var Res2 = from i in Res1
                               where i.Salary >= salary
                               select i;

                    foreach (var i in Res2)
                        Console.WriteLine($"{ i.Name} - {i.Salary}$");                
                }
            }
            public void CompanyEmployeesManager()
            {               
                var Res = from item in companies
                          select item;

                foreach (var item in Res)
                { 
                    var Res1 = from i in item.Employees
                               select i;

                    var Res2 = from i in Res1
                               where i.JobTitle!.Contains("manager")
                               select i;

                    var list = Res2;

                    if(list?.Count() != 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($" Сотрудники компании {item.Title} с должностью -manager-");
                        Console.ResetColor();

                        foreach (var i in Res2)
                            Console.WriteLine($"{i.Name} - {i.JobTitle}");
                        Console.WriteLine();
                    }
                }
            }
            public void CompanyEmployeesPhone23()
            {
                var Res = from item in companies
                          select item;

                foreach (var item in Res)
                {
                    var Res1 = from i in item.Employees
                               select i;

                    var Res2 = from i in Res1
                               where i.Phone!.StartsWith("23")
                               select i;

                    var list = Res2;

                    if (list?.Count() != 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($" Сотрудники компании {item.Title} с номером телефона 23...");
                        Console.ResetColor();

                        foreach (var i in Res2)
                            Console.WriteLine($"{i.Name} - {i.Phone}");
                        Console.WriteLine();
                    }
                }
            }
            public void CompanyEmployeesEmailDi()
            {
                var Res = from item in companies
                          select item;

                foreach (var item in Res)
                {
                    var Res1 = from i in item.Employees
                               select i;

                    var Res2 = from i in Res1
                               where i.Email!.StartsWith("di")
                               select i;

                    var list = Res2;

                    if (list?.Count() != 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($" Сотрудники компании {item.Title} с почтой di...");
                        Console.ResetColor();

                        foreach (var i in Res2)
                            Console.WriteLine($"{i.Name} - {i.Email}");
                        Console.WriteLine();
                    }
                }
            }
            public void CompanyEmployeesNameLionel()
            {
                var Res = from item in companies
                          select item;

                foreach (var item in Res)
                {
                    var Res1 = from i in item.Employees
                               select i;

                    var Res2 = from i in Res1
                               where i.Name!.StartsWith("Lionel")
                               select i;

                    var list = Res2;

                    if (list?.Count() != 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($" Сотрудники компании {item.Title} с именем Lionel");
                        Console.ResetColor();

                        foreach (var i in Res2)
                            Console.WriteLine($"{i.Name}");
                        Console.WriteLine();
                    }
                }
            }
        }
        class Company
        {
            public string? Title { get; set; }
            public DateTime? Date { get; set; }
            public string? Profile { get; set; }
            public string? Director { get; set; }
            public List<Employee>? Employees { get; set; }
            public int CountEmployees { get; }
            public string? Address { get; set; }

            public Company() { }
            public Company(string title, DateTime date, string profile, string director, List<Employee> employees, string address)
            {
                this.Title = title;
                this.Date = date;
                this.Profile = profile;
                this.Director = director;
                this.Employees = employees;
                this.CountEmployees = employees.Count;
                this.Address = address;
            }
            public override string ToString()   // информация о фирме
            {
                return $" Название фирмы:\t{Title}\n Дата основания:\t{Date}\n " +
                    $"Профиль бизнеса: \t{Profile}\n ФИО директора:\t\t{Director}\n " +
                    $"Кол-во сотрудников:\t{CountEmployees}\n Адрес:\t\t\t{Address}\n";
            }
            public void ShowEmployees() // Получить всех сотрудников конкретной фирмы
            {
                int id = 1;
                foreach(var item in Employees!)
                {
                    Console.WriteLine($"{id}. {item.Name}");
                    id++;
                }
            }           
        }
        class Employee
        {
            public string? Name { get; set; }
            public string? JobTitle { get; set; }
            public string? Phone { get; set; }
            public string? Email { get; set; }
            public double Salary { get; set; }

            public Employee() { }
            public Employee(string name, string job, string phone, string email, double salary)
            {
                this.Name = name;
                this.JobTitle = job;
                this.Phone = phone;
                this.Email = email;
                this.Salary = salary;
            }
        }
        static List<Company> FillCompanies()
        {
            List<Employee> employees1 = new List<Employee>()
            {
                new Employee("Lionel Martines", "salesman", "23985689697", "lio9485@gmail.com", 2385.56),
                new Employee("Manuel Ramos", "cashier", "28985559677", "ramosman@gmail.com", 3200.00),
                new Employee("Maria Gimenez", "cashier", "22374722699", "marigi@gmail.com", 3200.00),
                new Employee("Alejandro Garcia", "salesman", "23547684456", "garcialex95@gmail.com", 2385.56),
                new Employee("Liam Fertines", "salesman", "27899659121", "fertliam9519@gmail.com", 2385.56)
            };
            DateTime date1 = new DateTime(2011, 07, 15);
            Company company1 = new Company("Drinks and Food", date1, "nutrition", "Olivia Sanches", employees1, "Madrid");

            ////////////////////////////////////////////////////////////////////////////////////////////

            List<Employee> employees2 = new List<Employee>()
            {
                new Employee("Emily Adamson", "hr-manager", "23865454578", "adam_sonem@gmail.com", 4056.25),
                new Employee("Jessica Evans", "secretary", "86587452757", "jessyevans@gmail.com", 2000.00),
                new Employee("Jack Johnson", "cleaner", "23896547155", "jackkk4568@gmail.com", 1200.00),
                new Employee("Harry Davies", "manager", "85479658745", "har789dav95@gmail.com", 5385.78),
                new Employee("Jacob Wilson", "manager", "87945669477", "wilson_j@gmail.com", 5385.78),
                new Employee("Mike Flatcher", "manager", "89654784545", "miki965fl@gmail.com", 5385.78)
            };
            DateTime date2 = new DateTime(2022, 11, 23);
            Company company2 = new Company("Black Horse", date2, "marketing", "Joe White", employees2, "London");

            ////////////////////////////////////////////////////////////////////////////////////////////

            List<Employee> employees3 = new List<Employee>()
            {
                new Employee("Ava Johnson", "hr-manager", "23985689697", "lio9485@gmail.com", 4500.89),
                new Employee("Leo Brown", "secretary", "28985559677", "leo_leo@gmail.com", 1988.50),
                new Employee("David Taylor", "junior developer", "22374722699", "ditayjun@gmail.com", 5365.00),
                new Employee("Isabella Wilson", "junior developer", "23547684456", "isa_bella9695@gmail.com", 5365.00),
                new Employee("John Walker", "senior developer", "27899659121", "walker_john1989@gmail.com", 10625.78),
                new Employee("Chloe Harris", "middle developer", "27899659121", "harrischl@gmail.com", 8765.32),
                new Employee("Ryan Moore", "team lead", "27899659121", "dirook_moore@gmail.com", 5502.12),
            };
            DateTime date3 = new DateTime(2023, 05, 04);
            Company company3= new Company("White Rook", date3, "IT", "Sophie Black", employees3, "New York");

            ////////////////////////////////////////////////////////////////////////////////////////////

            List<Employee> employees4 = new List<Employee>()
            {
                new Employee("Yuliya Petrova", "secretary", "380937418356", "yupetrova@gmail.com", 536.89),
                new Employee("Dmitriy Sokolovskiy", "manager", "380674565782", "dimasokol85@gmail.com", 1536.50),
                new Employee("David Avdeev", "architect", "380503636255", "ddavveda@gmail.com", 2365.00),
                new Employee("Nataliya Denisova", "accountant", "380964587147", "nataDen95@gmail.com", 920.75),
                new Employee("Vasiliy Ivanov", "architect", "380671212457", "ivanov1978@gmail.com", 2365.00),
                new Employee("Larisa Semenkova", "designer", "380986545982", "semenkovalara@gmail.com", 1132.60),
                new Employee("Ivan Markov", "architect", "380939727563", "markovvi94@gmail.com", 2365.00),
            };
            DateTime date4 = new DateTime(2010, 09, 13);
            Company company4 = new Company("Budova", date4, "construction", "Gennadiy Truhanov", employees4, "Odesa");


            List<Company> cmpn = new List<Company>()
            {
                company1,
                company2,
                company3,
                company4
            };            
            return cmpn;
        }
    }
}