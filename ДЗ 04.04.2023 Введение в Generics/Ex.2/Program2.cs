using System.Collections.Generic;

// ДОРАБОТАТЬ!
// сделать проверки на вводимые слова (цифры, язык, регистр) проверка на
// пустоту строки. Слово или перевод не может быть пустым!

// вынести лишнее из методов, убрать повторы.
// продумать использование linq запросов
// сортировка словаря по алфавиту!!!!!!!!
// сериализация
// сделать более приличный интерфейс, красивый вывод
// Добавить условие - Нельзя удалить перевод слова, если это последний вариант перевода.

namespace Ex._2
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Vocabulary Vocabulary = new Vocabulary("собака", new List<string>() { "dog", "pooch", "hound" });
            Vocabulary.Add("яблоко", new List<string>() { "apple" });
            Vocabulary.Add("голова", new List<string>() { "head", "brain", "pate" });
            Vocabulary.Add("ходить", new List<string>() { "walk", "go" });

            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("\t\t\tАнгло-русский словарь");
                Console.WriteLine(" Меню операций");
                Console.WriteLine(" 1 - Показать словарь\n 2 - Добавление слова и перевода\n" +
                    " 3 - Удалить слово\n 4 - Удалить вариант перевода\n 5 - Изменить слово\n" +
                    " 6 - Изменить вариант перевода\n 7 - Поиск перевода слова\n 0 - Выход\n");

                Console.Write(" Сделайте выбор: ");
                int choice = -1;
                try
                {
                    try { choice = int.Parse(Console.ReadLine()!); }
                    catch { throw new FormatException(" Некорректный ввод!\n"); }

                    if (choice < 0 || choice > 7)
                        throw new Exception(" Некорректный ввод!\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                    Console.Clear();
                }

                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        Vocabulary.Output();
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 2:
                        Vocabulary.Add();
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 3:
                        Vocabulary.DeleteWord();
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 4:
                        Vocabulary.DeleteTranslation();
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 5:
                        Vocabulary.ChangeWord();
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 6:
                        Vocabulary.ChangeTranslation();
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 7:
                        Vocabulary.FindTranslation();
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 0:
                        return;
                }
            }
        }

        public class Vocabulary
        {
            private Dictionary<string, List<string>> vocabulary = new();
            public Vocabulary() { }  // конструктор по умолчанию
            public Vocabulary(string key, List<string> list) // конструктор с параметрами
            {
                this.vocabulary.Add(key, list);
            }
            public void Output()    // форматированный вывод на экран словаря
            {
                Console.WriteLine("-Словарь-\n");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(" Слово\t\t\tПеревод\t\t");
                Console.ResetColor();
                foreach (var j in vocabulary)
                {
                    Console.Write($" {j.Key, -20}");
                    Console.Write($"{ "-",-3}");
                    foreach (var word in j.Value)
                        Console.Write($"{word}{(j.Value.IndexOf(word) == j.Value.Count - 1 ? "" : ", ")}");
                    Console.WriteLine();
                }
            }
            public void Add()       // добавление с вводом
            {
                Console.WriteLine("-Добавление слова и перевода-\n");
                Console.WriteLine(" Введите слово на русском:");
                string key = Console.ReadLine()!;
                Console.WriteLine(" Введите перевод на английском:");
                var list = new List<string>();
                list.Add(Console.ReadLine()!);
                int choice = 0;

                while(true) // пока пользователь желает добавлять переводы к слову
                {
                    Console.WriteLine($" Желаете добавить еще перевод слова \"{key}\":\n 1 - да\n 2 - нет");

                    while (true)
                    {
                        Console.Write(" Сделайте выбор: ");
                        try
                        {
                            choice = int.Parse(Console.ReadLine()!);

                            if (choice < 1 || choice > 2)
                                throw new Exception(" Некорректный ввод!\n");
                            break;
                        }
                        catch (FormatException) { Console.WriteLine(" Некорректный ввод!\n"); }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                    }

                    if (choice == 1) // если пользователь желает добавить еще перевод
                    {
                        Console.WriteLine(" Введите перевод на английском:");
                        list.Add(Console.ReadLine()!);
                    }
                    else break; // прерывает внешний цикл while
                }                

                this.vocabulary.Add(key, list); // добавляем в словарь слово и его переводы

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Слово и перевод успешно добавлены!");
                Console.ResetColor();
            }
            public void Add(string key, List<string> list) // добавление без ввода (параметры)
            {
                vocabulary.Add(key, list);
            }
            public void DeleteWord()        // удаление ключа (слово на русском)
            {
                Output();
                Console.WriteLine("-Удаление слова-\n");
                Console.WriteLine(" Введите слово на русском:");
                string del = Console.ReadLine()!;
                bool flag = false;
                foreach (var word in vocabulary.Keys) // перебираем все ключи словаря
                    if (word == del) flag = true;  // найдено ли слово

                if (flag)   // если совпадение найдено
                {
                    foreach (var j in vocabulary)
                    {
                        if (j.Key == del)
                        {
                            vocabulary.Remove(j.Key); // удаляем слово
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Слово успешно удалёно из словаря!");
                            Console.ResetColor();
                            break;
                        }
                    }
                }
                else { Console.WriteLine($" Слова \"{del}\" нет в словаре!"); }
            }
            public void DeleteTranslation() // удаление перевода слова
            {
                Output();
                Console.WriteLine("-Удаление перевода-\n");
                Console.WriteLine(" Введите слово на русском:");
                string word = Console.ReadLine()!;
                bool flag = false;

                foreach (var w in vocabulary.Keys) // перебираем все ключи словаря
                    if (w == word) flag = true;  // найдено ли слово

                if (flag)   // если совпадение найдено
                {
                    foreach (var j in vocabulary)
                    {
                        if (j.Key == word)
                        {
                            Console.WriteLine($" Варианты перевода слова \"{j.Key}\":");
                            for (int i = 0; i < j.Value.Count; i++)  // показ всех переводов List
                                Console.WriteLine($"{i + 1}. {j.Value[i]}");

                            while(true)
                            {
                                Console.Write(" Введите номер перевода:");
                                try
                                {
                                    int ind = int.Parse(Console.ReadLine()!);
                                    if(ind < 1 || ind > j.Value.Count)  // если номер перевода меньше 1 или больше кол-ва элементов в List
                                        throw new Exception("Некорректный ввод номера!");

                                    j.Value.RemoveAt(ind - 1); // удаление элемента из List

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine(" Перевод успешно удалён!");
                                    Console.ResetColor();
                                    break; // прерывает while
                                }
                                catch (FormatException) { Console.WriteLine(" Некорректный ввод номера!"); }
                                catch(Exception ex) { Console.WriteLine(ex.Message); }                                
                            }
                            break;  // прерывает foreach
                        }
                    }
                }
                else { Console.WriteLine($" Слова \"{word}\" нет в словаре!"); }
            }
            public void ChangeWord()        // изменение слова
            {
                Output();
                Console.WriteLine("-Изменение слова на русском-\n");
                Console.WriteLine(" Введите искомое слово:");
                string ch = Console.ReadLine()!;
                bool flag = false;
                foreach (var w in vocabulary.Keys)
                {
                    if (w == ch) flag = true;
                }

                if (flag)
                {
                    foreach (var j in vocabulary)
                    {
                        if (j.Key == ch)
                        {
                            Console.WriteLine(" Введите новое слово на русском:");
                            string newKey = Console.ReadLine()!;

                            var oldList = j.Value;           // сохраняем переводы
                            vocabulary.Remove(j.Key);        // удаляем из коллекции текущий элемент
                            vocabulary.Add(newKey, oldList); // добавляем новый элемент с новым словом, но со старыми переводами
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(" Слово успешно изменено!");
                            Console.ResetColor();
                            break;
                        }
                    }
                }
                else { Console.WriteLine($" Слова \"{ch}\" нет в словаре!"); }
            }
            public void ChangeTranslation() // изменение перевода
            {
                Output();
                Console.WriteLine("-Изменение перевода слова-\n");
                Console.WriteLine(" Введите искомое слово на русском:");
                string word = Console.ReadLine()!;
                bool flag = false;
                foreach (var w in vocabulary.Keys)
                {
                    if (w == word) flag = true;
                }

                if (flag)
                {
                    foreach (var j in vocabulary)
                    {
                        if (j.Key == word)
                        {
                            Console.WriteLine($" Варианты перевода слова \"{j.Key}\":");
                            for (int i = 0; i < j.Value.Count; i++)  // показ всех переводов List
                                Console.WriteLine($"{i + 1}. {j.Value[i]}");

                            while (true)
                            {
                                Console.Write(" Введите номер перевода для изменения:");
                                try
                                {
                                    int ind = int.Parse(Console.ReadLine()!);
                                    if (ind < 1 || ind > j.Value.Count)  // если номер перевода меньше 1 или больше кол-ва элементов в List
                                        throw new Exception("Некорректный ввод номера!");

                                    Console.WriteLine(" Введите новый перевод:");
                                    string newTranslation = Console.ReadLine()!;
                                    j.Value[ind - 1] = newTranslation;

                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine(" Новый перевод успешно сохранён!");
                                    Console.ResetColor();
                                    break; // прерывает while
                                }
                                catch (FormatException) { Console.WriteLine(" Некорректный ввод номера!"); }
                                catch (Exception ex) { Console.WriteLine(ex.Message); }
                            }
                            break;  // прерывает foreach
                        }
                    }
                }
                else { Console.WriteLine($" Слова \"{word}\" нет в словаре!"); }
            }
            public void FindTranslation()   // поиск перевода слова
            {
                Console.WriteLine("-Поиск перевода слова-\n");
                Console.WriteLine(" Введите искомое слово на русском:");
                string word = Console.ReadLine()!;
                bool flag = false;
                foreach (var w in vocabulary.Keys)
                {
                    if (w == word) flag = true;
                }

                if (flag)
                {
                    foreach (var j in vocabulary)
                    {
                        if (j.Key == word)
                        {
                            Console.WriteLine($" Варианты перевода слова \"{j.Key}\":");
                            for (int i = 0; i < j.Value.Count; i++)  // показ всех переводов List
                                Console.WriteLine($"{i + 1}. {j.Value[i]}");

                            break;  // прерывает foreach
                        }
                    }
                }
                else { Console.WriteLine($" Слова \"{word}\" нет в словаре!"); }
            }
        }
    }
}