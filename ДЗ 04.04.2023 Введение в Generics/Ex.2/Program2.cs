﻿using System.Collections.Generic;

namespace Ex._2
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Vocabulary Vocabulary = new Vocabulary("волосы", new List<string>() { "hair" });
            Vocabulary.Add("яблоко", new List<string>() { "apple" });
            Vocabulary.Add("голова", new List<string>() { "head", "brain", "pate" });
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("\t\t\tАнгло-русский словарь");
                Console.WriteLine(" Меню операций");
                Console.WriteLine(" 1 - Показать словарь\n 2 - Добавление слова и перевода\n" +
                    " 3 - Удалить слово\n 4 - Удалить вариант перевода\n 5 - Изменить слово\n" +
                    " 6 - Изменить вариант перевода\n 7 - Поиск варианта перевода\n 0 - Выход\n");

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
                        //Vocabulary.PasInfo();
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 6:
                        //Vocabulary.PasInfo();
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 7:
                        //Vocabulary.PasInfo();
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
            public Vocabulary() { } // конструктор по умолчанию
            public Vocabulary(string key, List<string> list) // конструктор с параметрами
            {
                this.vocabulary.Add(key, list);
            }

            public void Output() // форматированный вывод на экран словаря
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
            public void Add() // добавление с вводом
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
            public void DeleteWord() // удаление ключа (слово на русском)
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

            //public void Change()
            //{
            //    Output();
            //    Console.WriteLine("-Изменение логина и пароля сотрудника-\n");
            //    Console.WriteLine(" Введите фамилию и имя сотрудника:");
            //    string ch = Console.ReadLine()!;
            //    bool flag = false;
            //    foreach ((Employee, string) c in manage.Keys)
            //    {
            //        if (c.Item1.Name == ch) flag = true;
            //    }

            //    if (flag)
            //    {
            //        foreach (var j in manage)
            //        {
            //            if (j.Key.Item1.Name == ch)
            //            {
            //                string log = CheckLog();
            //                string pas = CheckPas();

            //                var old = j.Key.Item1;      // сохраняем сотрудника(фио)
            //                manage.Remove(j.Key);       // удаляем из коллекции текущий элемент
            //                manage.Add((old, log), pas);  // добавляем новый элемент с новым логином и паролем, но со старой ФИО
            //                Console.ForegroundColor = ConsoleColor.Green;
            //                Console.WriteLine("Данные успешно изменены!");
            //                Console.ResetColor();
            //                break;
            //            }
            //        }
            //    }
            //    else { Console.WriteLine($" Сотрудника {ch} нет в базе!"); }
            //}
            //public void PasInfo()
            //{
            //    Output();
            //    Console.WriteLine("-Получение информации о пароле сотрудника-\n");
            //    Console.WriteLine(" Введите фамилию и имя сотрудника:");
            //    string ch = Console.ReadLine()!;
            //    bool flag = false;
            //    foreach ((Employee, string) c in manage.Keys)
            //    {
            //        if (c.Item1.Name == ch) flag = true;
            //    }

            //    if (flag)
            //    {
            //        foreach (var j in manage)
            //        {
            //            if (j.Key.Item1.Name == ch)
            //            {
            //                Console.WriteLine($" Пароль: {j.Value}");
            //                break;
            //            }
            //        }
            //    }
            //    else { Console.WriteLine($" Сотрудника {ch} нет в базе!"); }
            //}
            //static string CheckLog()
            //{
            //    string log;
            //    while (true)
            //    {
            //        Console.WriteLine(" Введите логин (не менее 7, не более 10 символов):");
            //        try
            //        {
            //            log = Console.ReadLine()!;
            //            if (log.Length < 7 || log.Length > 10)
            //            {
            //                throw new Exception(" Неверное кол-во символов!");
            //            }
            //            break;
            //        }
            //        catch (Exception ex)
            //        {
            //            Console.WriteLine(ex.Message);
            //        }
            //    }
            //    return log;
            //}
            //static string CheckPas()
            //{
            //    string pas;
            //    while (true)
            //    {
            //        Console.WriteLine(" Введите пароль (не менее 8 символов, не более 12):");
            //        try
            //        {
            //            pas = Console.ReadLine()!;
            //            if (pas.Length < 8 || pas.Length > 12)
            //            {
            //                throw new Exception(" Неверное кол-во символов!");
            //            }
            //            break;
            //        }
            //        catch (Exception ex)
            //        {
            //            Console.WriteLine(ex.Message);
            //        }
            //    }
            //    return pas;
            //}

        }

    }
}