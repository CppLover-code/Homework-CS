namespace ДЗ_07._04._2023_Вз_ие_с_файловой_системой
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            Console.Title = "Сборник стихов";
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
            //collection.ShowCollection();
            int choice;
            
            while (true)
            {
                Console.WriteLine("\tМеню\n" +
                    " 1 - показать все стихи\n" +
                    " 2 - добавить стих\n" +
                    " 3 - удалить стих\n" +
                    " 4 - изменить информацию о стихе\n" +
                    " 5 - сохранить сборник стихов в файл\n" +
                    " 6 - загрузить сборник стихов из файла\n" +
                    " 0 - выход\n");
                Console.Write(" Сделайте выбор: ");                   
                try
                {
                    choice = int.Parse(Console.ReadLine()!);
                    if(choice < 0 || choice > 6)
                    {
                        throw new Exception(" Некорректный выбор!");
                    }
                    break;
                }
                catch(FormatException)
                {
                    Console.WriteLine(" Некорректный ввод!");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            switch (choice)
            {
                //case 0:

                case 1:
                    collection.ShowCollection();
                    break;
                case 2:
                    collection.Add();
                    break;
                case 3:
                    collection.Remove();
                    break;
                case 4:
                    collection.Change();
                    break;
                case 5:
                    collection.ShowCollection();
                    break;
                case 6:
                    collection.ShowCollection();
                    break;
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
                int id = 1;
                foreach (var poetry in poetries)
                {
                    Console.WriteLine($" Стих #{id}");
                    poetry.ShowPoetry();
                    id++;
                }    
            }
            public void ShowMainInfoCollection() // показ названия и автора стиха
            {
                int id = 1;
                foreach (var poetry in poetries)
                {
                    Console.WriteLine($" {id}. \"{poetry.Title}\", {poetry.Author}");
                    id++;
                }
            }
            public void Add()   // добавление стиха
            {
                poetries.Add(new Poetry());
            }
            public void Remove() // удаление по индексу
            {
                if(poetries.Count == 0)
                {
                    Console.WriteLine(" Сборник стихов пуст!");
                    return;
                }
                ShowMainInfoCollection();
                int ind;
                while(true)
                {
                    Console.WriteLine(" Введите номер стиха для удаления: ");
                    try
                    {
                        ind = int.Parse(Console.ReadLine()!);
                        if(ind < 0 || ind > poetries.Count)
                        {
                            throw new Exception(" Некорректный выбор!");
                        }
                        break;
                    }
                    catch(FormatException)
                    {
                        Console.WriteLine(" Некорректный ввод!");
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                
                poetries.RemoveAt(ind);
            }
            public void Change()
            {
                if (poetries.Count == 0)
                {
                    Console.WriteLine(" Сборник стихов пуст!");
                    return;
                }
                ShowMainInfoCollection();
                int ind; 
                while (true)
                {
                    Console.WriteLine(" Введите номер стиха для изменения: ");
                    try
                    {
                        ind = int.Parse(Console.ReadLine()!);
                        if (ind < 0 || ind > poetries.Count)
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

                int ch;
                while (true)
                {
                    Console.WriteLine("\tПункты для изменения\n" +
                    " 1 - название стиха\n" +
                    " 2 - ФИО автора\n" +
                    " 3 - год написания\n" +
                    " 4 - текст стиха\n" +
                    " 5 - тема стиха\n");
                    Console.Write(" Сделайте выбор: ");
                    try
                    {
                        ch = int.Parse(Console.ReadLine()!);
                        if (ch < 1 || ch > 5)
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

                string newInfo;
                int newDate;
                switch (ch)
                {
                    case 1:
                        Console.WriteLine(" Введите обновленное название:");
                        newInfo = Console.ReadLine()!;
                        poetries[ind].Title = newInfo;
                        break;
                    case 2:
                        Console.WriteLine(" Введите обновлённую информацию об авторе (ФИО):");
                        newInfo = Console.ReadLine()!;
                        poetries[ind].Author = newInfo;
                        break;
                    case 3:
                        Console.WriteLine(" Введите обновлённый год написания:");
                        newDate = int.Parse(Console.ReadLine()!);
                        poetries[ind].Date = newDate;
                        break;
                    case 4:
                        Console.WriteLine(" Введите обновлённый текст стиха:");
                        newInfo = Console.ReadLine()!;
                        poetries[ind].Text = newInfo;
                        break;
                    case 5:
                        Console.WriteLine(" Введите обновлённую тему стиха:");
                        newInfo = Console.ReadLine()!;
                        poetries[ind].Theme = newInfo;
                        break;                   
                }
            }

        }
    }
}