namespace Ex._3
{
    internal class Program3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t-Collection of poetries-");
            List<Poetry> poetries = new List<Poetry>()
            {
                new Poetry("Бычок", "Агния Барто", 1927, 
                "Идет бычок, качается,\r\nВздыхает на ходу:\r\n— Ох, доска кончается.\r\nСейчас я упаду!\n", "О бычке"),
                new Poetry("Бычок", "Валентин Берестов", 1950, 
                "Петушки распетушились,\r\nНо подраться не решились.\r\nЕсли очень петушиться,\r\nМожно пёрышек лишиться.\r\nЕсли пёрышек лишиться,\r\nНечем будет петушиться.\n", "О петушках"),
                new Poetry("Бычок", "Агния Барто", 1930, 
                "Зайку бросила хозяйка,—\r\nПод дождем остался зайка.\r\nСо скамейки слезть не мог,\r\nВесь до ниточки промок.\n", "О зайке"),
                new Poetry("Туфельки", "Самуил Маршак", 1923,
                "Дали туфельки слону. Взял он туфельку одну И сказал: — Нужны пошире, И не две, а все четыре!\n", "О слоне и туфельках"),
            };

            Collection collection = new Collection(poetries);
            collection.ShowCollection();
        }
        class Poetry
        {
            public string? Title { get; set; }
            public string? Author { get; set; }
            public int Date { get; set; }
            public string? Text { get; set; }
            public string? Theme { get; set; }

            public Poetry() { }
            public Poetry(string title,string author, int date, string text, string theme)
            {
                this.Title = title;
                this.Author = author;
                this.Date = date;   
                this.Text = text;
                this.Theme = theme;
            }
            public void ShowPoetry()
            {
                Console.WriteLine(" Название:\t{0}\n Автор:\t{1}\n " +
                    "Год написания:\t{2}\n Тема:\t{3}\n Текст стиха:\n{4}\n ");
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
            public void Add(Poetry poetry)   // добавление стиха
            {
                poetries.Add(poetry);
            }
            public void Remove(Poetry poetry)
            {
                poetries.Remove(poetry);
            }
            public void Change() 
            { 

            }
        }
    }
}