namespace ДЗ_11._04._2023_Введение_в_LINQ
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            Console.Title = "LINQ запросы";


            int choice;
            while (true)
            {
                Console.WriteLine("\tМеню\n" +
                    " 1.Получить информацию обо всех фирмах\n" +
                    " 2.Получить фирмы, у которых в названии есть слово Food\n" +
                    " 3.Получить фирмы, которые работают в области маркетинга\n" +
                    " 4.Получить фирмы, которые работают в области маркетинга или IT\n" +
                    " 5.Получить фирмы с количеством сотрудников, большем 3\n" +
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

                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                    case 6:

                        break;
                    case 7:
                        
                        break;
                    case 8:
                        
                        break;
                    case 9:

                        break;
                    case 10:

                        break;
                    case 11:

                        break;
                    case 12:

                        break;
                    case 13:

                        break;
                    case 14:

                        break;
                    case 15:

                        break;
                    case 16:

                        break;
                    case 17:

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
            public void ShowCompany()   // Получить информацию обо всех фирмах
            {
                Console.WriteLine(" Название фирмы: {0}\n Дата основания: {1}\n " +
                    "Профиль бизнеса: {2}\n ФИО директора: {3}\n Количество сотрудников: {4}\n " +
                    "Адрес: {5}\n", this.Title, this.Date, this.Profile, this.Director, this.CountEmployees, this.Address);
            }
            public void ShowEmployees() // Получить всех сотрудников конкретной фирмы
            {
                int id = 1;
                foreach(var item in Employees!)
                {
                    Console.WriteLine($"{id}. {item.Name}");
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
            public void ShowEmployee()
            {

            }
        }
        static List<Company> Generate()
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
            Company company4 = new Company("Budova", date3, "construction", "Gennadiy Truhanov", employees4, "Odesa");


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