namespace Ex._2
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t-Магазин-");
            Console.ResetColor();

            // Использование Dispose
            var stores = new Store[3];
            stores[0] = new Store("АТБ", "Одесса, Сахарова, 18", "Продовольственный");
            stores[1] = new Store("Прораб", "Одесса, Южная, 5", "Хозяйственный");
            stores[2] = new Store("Зара", "Фонтанка, Южная, 12", "Одежда");

            foreach (var item in stores)
                item.ShowStore();

            foreach (var item in stores)
                item.Dispose();
            Console.WriteLine();

            // Использование Деструктора
            CreateObjects();
            GC.Collect();
            Console.Read();
        }
        static void CreateObjects()
        {
            var list = new List<Store>()
            {
                new Store("Сильпо", "Одесса, Левитана, 26", "Продовольственный"),
                new Store("Пакер", "Одесса, С.Палия, 135/3", "Обувь"),
                new Store ("Эпицентр", "Одесса, Небесной Сотни, 142", "Хозяйственный")
            };

            foreach (var item in list)
                item.ShowStore();
        }

    }
    class Store : IDisposable
    {
        public string Title { get; set; }
        public string Adress { get; set; }
        public string Type { get; set; }

        public Store(string t, string a, string g)
        {
            this.Title = t;
            this.Adress = a;
            this.Type = g;
        }
        public void ShowStore()
        {
            Console.WriteLine(" Название:\t\"{0}\"\n Адрес:\t\t{1}\n Тип:\t\t{2}\n",
                Title, Adress, Type);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Магазин {this.Title} уничтожен (Dispose)!");
            Console.ResetColor();
        }
        ~Store()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" Объект с названием {Title} уничтожен (d-tor)!");
            Console.ResetColor();
        }
    }
}