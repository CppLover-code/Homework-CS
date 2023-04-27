namespace ДЗ_06._04._2023_Сборка_мусора
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t-Лучшие пьесы всех времён-");
            Console.ResetColor();

            // Использование Деструктора
            CreateObjects();
            GC.Collect();
            Console.Read();

            // Использование Dispose
            Play[] plays = new Play[2];
            plays[0] = new Play("Король Лир", "Уильям Шекспир", "трагедия", 1606);
            plays[1] = new Play("Ромео и Джульетта", "Уильям Шекспир", "трагедия", 1597);
            
            foreach (var item in plays)
                item.ShowPlay();

            foreach (var item in plays)
                item.Dispose();

        }
        static void CreateObjects()
        {
            var list = new List<Play>()
            {
                new Play("Гамлет","Уильям Шекспир","трагедия", 1601),
                new Play("Пигмалион","Бернард Шоу","комедия", 1913),
                new Play("Ревизор","Николай Гоголь","комедия", 1835)
            };

            foreach (var item in list)
                item.ShowPlay();
        }
        
    }
    class Play :IDisposable
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }

        public Play(string t, string a, string g, int y)
        {
            this.Title = t;
            this.Author = a;
            this.Genre = g;
            this.Year = y;
        }
        public void ShowPlay()
        {
            Console.WriteLine(" Название:\t{0}\n Автор:\t\t{1}\n Жанр:\t\t{2}\n Год выпуска:\t{3}\n",
                Title, Author, Genre, Year);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Console.WriteLine($"Пьеса {this.Title} уничтожена (Dispose)!");
        }
        ~Play()
        {
            Console.WriteLine($" Объект с названием {Title} уничтожен (d-tor)!");
        }
    }

}