namespace ДЗ_07._04._2023_Вз_ие_с_файловой_системой
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t-Collection of poetries-");
            List<Poetry> poetries = new List<Poetry>()
            {
                new Poetry("Бычок", "Агния Барто", 1927,
                " Идет бычок, качается,\r\n Вздыхает на ходу:\r\n — Ох, доска кончается.\r\n Сейчас я упаду!\n", "О бычке"),
                new Poetry("Петушки", "Валентин Берестов", 1950,
                " Петушки распетушились,\r\n Но подраться не решились.\r\n Если очень петушиться,\r\n Можно пёрышек лишиться.\r\n Если пёрышек лишиться,\r\n Нечем будет петушиться.\n", "О петушках"),
                new Poetry("Зайка", "Агния Барто", 1930,
                " Зайку бросила хозяйка,—\r\n Под дождем остался зайка.\r\n Со скамейки слезть не мог,\r\n Весь до ниточки промок.\n", "О зайке"),
                new Poetry("Туфельки", "Самуил Маршак", 1923,
                " Дали туфельки слону.\r\n Взял он туфельку одну\r\n И сказал: — Нужны пошире,\r\n И не две, а все четыре!\n", "О слоне и туфельках"),
            };

            Collection collection = new Collection(poetries);
            collection.ShowCollection();
            while(true)
            {
                Console.WriteLine("\tМеню\n" +
                    " 1 - показать все стихи\n" +
                    " 2 - ");

            }
        }
        class Poetry
        {
            public string? Title { get; set; }
            public string? Author { get; set; }
            public int Date { get; set; }
            public string? Text { get; set; }
            public string? Theme { get; set; }

            public Poetry() // сделать проверки
            {
                Console.WriteLine(" Введите название стиха:");
                this.Title = Console.ReadLine();
                Console.WriteLine(" Введите имя и фамилию автора:");
                this.Author = Console.ReadLine();
                Console.WriteLine(" Введите год написания стиха:");
                this.Date = int.Parse(Console.ReadLine()!);
                Console.WriteLine(" Введите тему стиха:");
                this.Theme = Console.ReadLine();
                Console.WriteLine(" Введите текст стиха:");
                this.Text = Console.ReadLine();
            }
            public Poetry(string title, string author, int date, string text, string theme)
            {
                this.Title = title;
                this.Author = author;
                this.Date = date;
                this.Text = text;
                this.Theme = theme;
            }
            public void ShowPoetry()
            {
                Console.WriteLine(" Название:\t{0}\n Автор:\t\t{1}\n " +
                    "Год написания:\t{2} г.\n Тема:\t\t{3}\n Текст стиха\u2193\n{4}\n",
                    Title, Author, Date, Theme, Text);
            }
        }
        class Collection
        {
            List<Poetry> poetries = new();
            public Collection()
            {

            }
            public Collection(List<Poetry> list)
            {
                poetries = list;
            }
            public void ShowCollection()
            {
                foreach (var poetry in poetries)
                    poetry.ShowPoetry();
            }
            public void Add()   // добавление стиха
            {
                poetries.Add(new Poetry());
            }
            public void Remove(int ind) // удаление по индексу
            {
                poetries.RemoveAt(ind);
            }
            public void Change()
            {

            }
        }
    }
}