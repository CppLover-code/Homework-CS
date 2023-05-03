using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ДЗ_07._04._2023_Вз_ие_с_файловой_системой
{
    public class Program1
    {
        static void Main(string[] args)
        {
            Console.Title = "Сборник стихов";
            List<Poetry> poetries = new List<Poetry>()
            {
                new Poetry("Бычок", "Агния Барто", 1927,
                " Идет бычок, качается,\r\n Вздыхает на ходу:\r\n — Ох, доска кончается.\r\n Сейчас я упаду!\n", "О бычке"),
                new Poetry("Петушки", "Валентин Берестов", 1950,
                " Петушки распетушились,\r\n Но подраться не решились.\r\n Если очень петушиться,\r\n Можно пёрышек лишиться.\r\n" +
                " Если пёрышек лишиться,\r\n Нечем будет петушиться.\n", "О петушках"),
                new Poetry("Зайка", "Агния Барто", 1930,
                " Зайку бросила хозяйка,—\r\n Под дождем остался зайка.\r\n Со скамейки слезть не мог,\r\n Весь до ниточки промок.\n",
                "О зайке"),
                new Poetry("Туфельки", "Самуил Маршак", 1923,
                " Дали туфельки слону.\r\n Взял он туфельку одну\r\n И сказал: — Нужны пошире,\r\n И не две, а все четыре!\n", "О слоне" +
                " и туфельках"),
                new Poetry("Слон", "Агния Барто", 1930,
                " Спать пора! Уснул бычок,\r\n Лег в коробку на бочок.\r\n Сонный мишка лег в кровать,\r\n Только слон не хочет спать.\r\n" +
                " Головой качает слон,\r\n Он слонихе шлет поклон.\n", "О слоне")
            };

            Collection collection = new Collection();
            collection = new Collection(poetries);

            int choice;

            while (true)
            {
                Console.WriteLine("\tМеню\n" +
                    " 1 - показать все стихи\n" +
                    " 2 - добавить стих\n" +
                    " 3 - удалить стих\n" +
                    " 4 - изменить информацию о стихе\n" +
                    " 5 - искать стих по разным характеристикам\n" +
                    " 6 - сохранить сборник стихов в файл\n" +
                    " 7 - загрузить сборник стихов из файла\n" +
                    " 8 - формирование отчетов\n" +
                    " 0 - выход\n");
                while (true)
                {
                    Console.Write(" Сделайте выбор: ");
                    try
                    {
                        choice = int.Parse(Console.ReadLine()!);
                        if (choice < 0 || choice > 8)
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
                        collection.Search();
                        break;
                    case 6:
                        collection.WriteFile();
                        break;
                    case 7:
                        collection.ReadFile();
                        break;
                    case 8:
                        collection.Report();
                        break;
                }
                Console.WriteLine(" Для продолжения нажмите Enter!");
                Console.ReadLine();
                Console.Clear();
            }
        }

        [Serializable]
        public class Poetry
        {
            public string? Title { get; set; }
            public string? Author { get; set; }
            public int Date { get; set; }
            public string? Text { get; set; }
            public string? Theme { get; set; }

            public Poetry() { }
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
                    "Год написания:\t{2} г.\n Тема:\t\t{3}\n Текст стиха\u2193\n\n{4}\n",
                    Title, Author, Date, Theme, Text);
            }
        }
        public class Collection
        {
            public List<Poetry> poetries = new();
            public Collection() { }
            public Collection(List<Poetry> list)
            {
                poetries = list;
            }
            public void ShowCollection()
            {
                int id = 1;
                foreach (var poetry in poetries)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"\t Стих #{id}");
                    Console.ResetColor();
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
            public void Add()       // добавление стиха
            {
                Console.WriteLine(" Введите название стиха:");
                string title = CheckInput();
                Console.WriteLine(" Введите имя и фамилию автора:");
                string author = CheckInput();
                Console.WriteLine(" Введите год написания стиха:");
                int date = CheckDate();
                Console.WriteLine(" Введите тему стиха:");
                string theme = CheckInput();
                Console.WriteLine(" Введите текст стиха:");
                string text = CheckInput();

                poetries.Add(new Poetry(title, author, date, text, theme));
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Стих успешно добавлен!\n");
                Console.ResetColor();
            }
            public void Remove()    // удаление по индексу
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
                    Console.WriteLine(" Введите номер стиха для удаления: ");
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

                poetries.RemoveAt(ind - 1);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Стих успешно удалён!\n");
                Console.ResetColor();
            }
            public void Change()    // изменение информации стиха по выбранному пункту
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
                    Console.WriteLine("\tИзменить\n" +
                    " 1 - название стиха\n" +
                    " 2 - ФИО автора\n" +
                    " 3 - год написания\n" +
                    " 4 - текст стиха\n" +
                    " 5 - тема стиха\n" +
                    " 0 - выход\n");
                    Console.Write(" Сделайте выбор: ");
                    try
                    {
                        ch = int.Parse(Console.ReadLine()!);
                        if (ch < 0 || ch > 5)
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
                    case 0:
                        return;
                    case 1:
                        Console.WriteLine(" Введите обновленное название:");
                        newInfo = Console.ReadLine()!;
                        poetries[ind - 1].Title = newInfo;
                        break;
                    case 2:
                        Console.WriteLine(" Введите обновлённую информацию об авторе (ФИО):");
                        newInfo = Console.ReadLine()!;
                        poetries[ind - 1].Author = newInfo;
                        break;
                    case 3:
                        Console.WriteLine(" Введите обновлённый год написания:");
                        newDate = int.Parse(Console.ReadLine()!);
                        poetries[ind - 1].Date = newDate;
                        break;
                    case 4:
                        Console.WriteLine(" Введите обновлённый текст стиха:");
                        newInfo = Console.ReadLine()!;
                        poetries[ind - 1].Text = newInfo;
                        break;
                    case 5:
                        Console.WriteLine(" Введите обновлённую тему стиха:");
                        newInfo = Console.ReadLine()!;
                        poetries[ind - 1].Theme = newInfo;
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Изменения успешно сохранены!\n");
                Console.ResetColor();
            } 
            public void Search()    // поиск стиха по выбранному пункту
            {
                if (poetries.Count == 0)
                {
                    Console.WriteLine(" Сборник стихов пуст!");
                    return;
                }

                int ch;
                while (true)
                {
                    Console.WriteLine("\tПоиск по\n" +
                    " 1 - названию стиха\n" +
                    " 2 - ФИО автора\n" +
                    " 3 - году написания\n" +
                    " 4 - слову из стиха\n" +
                    " 5 - теме стиха\n" +
                    " 0 - выход\n");
                    Console.Write(" Сделайте выбор: ");
                    try
                    {
                        ch = int.Parse(Console.ReadLine()!);
                        if (ch < 0 || ch > 5)
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
                string temp;
                int date;
                List<Poetry> list1 = new List<Poetry>();
                switch (ch)
                {
                    case 0:
                        return;
                    case 1:
                        Console.WriteLine(" Введите название стиха:");
                        temp = CheckInput();
                        list1 = SearchByTitle(temp);
                        ShowList(list1);
                        break;

                    case 2:
                        Console.WriteLine(" Введите ФИО автора:");
                        temp = CheckInput();
                        list1 = SearchByAuthor(temp);
                        ShowList(list1);
                        break;

                    case 3:
                        Console.WriteLine(" Введите год написания стиха:");
                        date = CheckDate();
                        list1 = SearchByDate(date);
                        ShowList(list1);
                        break;

                    case 4:
                        Console.WriteLine(" Введите слово из стиха:");
                        temp = CheckInput();
                        list1 = SearchByStringInPoetry(temp);
                        ShowList(list1);
                        break;

                    case 5:
                        Console.WriteLine(" Введите тему стиха:");
                        temp = CheckInput();
                        list1 = SearchByTheme(temp);
                        ShowList(list1);
                        break;
                }
            }           
            public List<Poetry> SearchByTitle(string temp)
            {
                var Res = from i in poetries
                      where i.Title!.ToLower() == temp.ToLower()
                      select i;

                List<Poetry> list = Res.ToList();

                Console.Write("Результат поиска: ");
                if (list.Count != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"найдено {Res.Count()} совпадений!\n");
                    Console.ResetColor();
                }   
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("совпадений не найдено!\n");
                    Console.ResetColor();
                }

                return list;
            }
            public List<Poetry> SearchByAuthor(string temp)
            {
                var Res = from i in poetries
                          where i.Author!.ToLower() == temp.ToLower()
                          select i;

                List<Poetry> list = Res.ToList();

                Console.Write("Результат поиска: ");
                if (list.Count != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"найдено {Res.Count()} совпадений!\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("совпадений не найдено!\n");
                    Console.ResetColor();
                }

                return list;                
            }
            public List<Poetry> SearchByDate(int date)
            {
                var Res = from i in poetries
                          where i.Date == date
                          select i;

                List<Poetry> list = Res.ToList();

                Console.Write("Результат поиска: ");
                if (list.Count != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"найдено {Res.Count()} совпадений!\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("совпадений не найдено!\n");
                    Console.ResetColor();
                }

                return list;
            }
            public List<Poetry> SearchByStringInPoetry(string temp)
            {
                var Res = from i in poetries
                          where i.Text!.ToLower().Contains(temp.ToLower())
                          select i;

                List<Poetry> list = Res.ToList();

                Console.Write("Результат поиска: ");
                if (list.Count != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"найдено {Res.Count()} совпадений!\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("совпадений не найдено!\n");
                    Console.ResetColor();
                }

                return list;
            }
            public List<Poetry> SearchByTheme(string temp)
            {
                var Res = from i in poetries
                          where i.Theme!.ToLower() == temp.ToLower()
                          select i;

                List<Poetry> list = Res.ToList();

                Console.Write("Результат поиска: ");
                if (list.Count != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"найдено {Res.Count()} совпадений!\n");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("совпадений не найдено!\n");
                    Console.ResetColor();
                }

                return list;
            }
            public void WriteFile() // запись сборинка в файл
            {
                FileStream? stream = null;
                XmlSerializer? serializer = null;
                stream = new FileStream("Collection.xml", FileMode.Create);
                serializer = new XmlSerializer(typeof(List<Poetry>));
                serializer.Serialize(stream, poetries);
                stream.Close();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Коллекция стихов сохранена!");
                Console.ResetColor();
            }
            public void ReadFile()  // загрузка сборника из файла
            {
                poetries.Clear();
                FileStream? stream = null;
                XmlSerializer? serializer = null;
                stream = new FileStream("Collection.xml", FileMode.Open);
                serializer = new XmlSerializer(typeof(List<Poetry>));
                poetries = (List<Poetry>)serializer.Deserialize(stream)!;
                stream.Close();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Коллекция стихов загружена!");
                Console.ResetColor();
            }
            public void Report()    // отчёты
            {
                if (poetries.Count == 0)
                {
                    Console.WriteLine(" Сборник стихов пуст!");
                    return;
                }

                int ch;
                while (true)
                {
                    Console.WriteLine("\tОтчёт по\n" +
                    " 1 - названию стиха\n" +
                    " 2 - ФИО автора\n" +
                    " 3 - году написания\n" +
                    " 4 - слову в тексте стиха\n" +
                    " 5 - теме стиха\n" +
                    " 6 - длине стиха\n" +
                    " 0 - выход\n");
                    Console.Write(" Сделайте выбор: ");
                    try
                    {
                        ch = int.Parse(Console.ReadLine()!);
                        if (ch < 0 || ch > 6)
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
                
                switch (ch)
                {
                    case 0:
                        return;
                    case 1:
                        ReportByTitle();
                        break;
                    case 2:
                        ReportByAuthor();   
                        break;
                    case 3:
                        ReportByDate();
                        break;
                    case 4:
                       ReportByWordInPoetry();
                        break;
                    case 5:
                       ReportByTheme();
                        break;
                    case 6:
                        ReportByPoetryLength();
                        break;
                }
            }
            public void ReportByTitle()
            {
                Console.WriteLine(" Введите название стиха:");
                string title = CheckInput();

                var list = SearchByTitle(title);
                string filename = "ReportByTitle.txt";
                ReportPresentation(list, filename);
            }
            public void ReportByAuthor()
            {
                Console.WriteLine(" Введите имя и фамилию автора:");
                string author = CheckInput();

                var list = SearchByAuthor(author);
                string filename = "ReportByAuthor.txt";
                ReportPresentation(list, filename);
            }
            public void ReportByTheme()
            {
                Console.WriteLine(" Введите тему стиха:");
                string theme = CheckInput();

                var list = SearchByTheme(theme);
                string filename = "ReportByTheme.txt";
                ReportPresentation(list, filename);
            }
            public void ReportByWordInPoetry()
            {
                Console.WriteLine(" Введите слово:");
                string word = CheckInput();

                var list = SearchByStringInPoetry(word);
                string filename = "ReportByWord.txt";
                ReportPresentation(list, filename);
            }
            public void ReportByDate()
            {
                Console.WriteLine(" Введите год написания стиха:");
                int date = CheckDate();

                var list = SearchByDate(date);
                string filename = "ReportByDate.txt";
                ReportPresentation(list, filename);
            }
            public void ReportByPoetryLength()
            {
                Console.WriteLine(" Введите длину стиха:");
                int length;
                while (true)
                {
                    try
                    {
                         length = int.Parse(Console.ReadLine()!);
                        if (length < 4) throw new Exception(" Длина должна быть минимум 4 символа!");
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

                var Res = from i in poetries
                          where i.Text!.Length >= length // длина стиха больше или равно введённой длине, чтоб хоть что-то показать
                          select i;

                List<Poetry> list = Res.ToList();                                             
                string filename = "ReportByLength.txt";
                ReportPresentation(list, filename);
            }
            public void ReportPresentation(List<Poetry> list, string filename)
            {
                Console.WriteLine(" Выберите одно из представлений отчёта:\n" +
                   "1 - показать на экране\n" +
                   "2 - сохранить в файл");
                int choice;
                int id = 1;
                while (true)
                {
                    try
                    {
                        choice = int.Parse(Console.ReadLine()!);
                        if (choice < 1 || choice > 2) throw new Exception(" Неверный выбор!");
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
                    case 1:
                        Console.WriteLine("\t\tОтчёт");
                        Console.WriteLine($"Стихов найдено: {list.Count}");
                        Console.WriteLine("Стихи:");
                        foreach (var item in list)
                        {
                            Console.WriteLine($"{id}.\"{item.Title}\".{item.Author}");
                            id++;
                        }
                        break;

                    case 2:
                        try
                        {
                            StreamWriter sw = new StreamWriter(filename, true);
                            sw.WriteLine("\t\tОтчёт");
                            sw.WriteLine($"Стихов найдено: {list.Count} ");
                            sw.WriteLine("Стихи:");
                            foreach (var item in list)
                            {
                                sw.WriteLine($"{id}.\"{item.Title}\".{item.Author}");
                                id++;
                            }
                            sw.Close();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(" Отчёт успешно сохранён!\n");
                            Console.ResetColor();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                }
            }
        }
        static string CheckInput()  // проверка введенных текстовых данных
        {
            string text;
            while (true)
            {
                try
                {
                    text = Console.ReadLine()!;
                    if (string.IsNullOrEmpty(text) ||       // если строка пустая
                        string.IsNullOrWhiteSpace(text) ||  // если строка содержит только пробел или пустая
                        Regex.IsMatch(text, @"^\d+$"))      // если строка содержит только цифры
                    {
                        throw new Exception(" Некорректный ввод");
                    }
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return text;
        } 
        static int CheckDate()      // проверка введённой даты
        {
            int date;
            while (true)
            {
                try
                {
                    date = int.Parse(Console.ReadLine()!);
                    if (date < 1000 || date > DateTime.Today.Year)
                    {
                        throw new Exception(" Некорректный ввод!");
                    }
                    break;
                }
                catch(FormatException)
                {
                    Console.WriteLine(" Некорректный ввод!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } 
            return date;
        } 
        static void ShowList(List<Poetry> list)      // показ списка
        {
            int id = 1;
            foreach (var item in list)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($" Стих #{id}");
                Console.ResetColor();
                item.ShowPoetry();
                id++;
            }                
        }
    }
}