﻿using System.Drawing;

namespace Ex._3
{
    internal class Program3
    {
        static void Main(string[] args)
        {
            var person = new List<Person>() 
            { 
                new Person("Тарас Шевченко"),
                new Person("Леся Украинка"),
                new Person("Иван Франко"),
                new Person("Ольга Кобылянская"),
                new Person("Сергей Жадан"),
                new Person("Иван Котляревский"),
                new Person("Оксана Забужко"),
                new Person("Николай Зеров"),
                new Person("Борис Олейник"),
                new Person("Пантелеймон Кулиш"),
                new Person("Иван Малкович")
            };
            Cafe cafe = new Cafe("Берёзка", 5, person);
            cafe.MainInfo();
            var openCafe = new OpenCafe();

            while(cafe.QueLine?.persons.Count != 0)
            {                
                openCafe.Open(cafe);                
                Thread.Sleep(1500);
            }           
        }
   
        class Cafe
        {
            public string? Title { get; set; } // название кафе
            public int Table { get; set; }     // кол-во столиков
            public Line? QueLine { get; set; }        // очередь
            public Cafe(string title, int table, List<Person> people)
            {
                Title = title;
                Table = table;
                QueLine = new Line(people);
            }          
            public void MainInfo()
            {
                Console.WriteLine($" Кафе \"{Title}\"\n Всего столиков - {Table}");
            }
            public int FreeTable()
            {
                Random rnd = new Random();
                int value = rnd.Next(1, 4);
                Console.WriteLine("\n");
                Console.WriteLine("* * * * * * * * * * * *");
                Console.WriteLine($" Свободных столиков - {value}");
                Console.WriteLine("* * * * * * * * * * * *");
                return value;
            }
        }       
        class Line
        {
            public Queue<Person> persons = new();
            public Line() { }       // конструктор по умолчанию
            public Line(string p)   // конструктор с параметрами
            {
                this.persons.Enqueue(new Person() { Name = p });
            }
            public Line(List <Person> people)   // конструктор c полным списком гостей
            {
                for (int i = 0; i < people.Count(); i++)
                    this.persons.Enqueue(people[i]);
            }
            public void ShowLine()  // показ очереди
            {
                Console.WriteLine("Сейчас в очереди {0} человек:", persons.Count);
                int numb = 1;
                foreach (Person p in persons)
                {
                    Console.WriteLine(numb + ". " + p.Name);
                    numb++;
                }
            }
            public void Add(int count)    // добавление гостей в очередь
            {
                for (int i = 0; i < count; i++)
                     persons.Enqueue(new Person());
            }
            public void RemovePerson(int value) // удаление гостей из очереди
            {
                var temp = persons.ToList();                    // очередь в список, чтоб удалять Person, независимо от месторасположения

                    // 1 - происходит удаление из очереди по приоритету
                    foreach (var guest in persons)              // перебор очереди
                    {
                    if (guest.Reserved() &&                 // если Person резервировал
                            value > 0 &&                        // и свободные столы есть
                            persons.Count > 0)                  // и очередь не пустая 
                    {
                            Console.ForegroundColor = ConsoleColor.Green;                           
                            Console.WriteLine($" {guest.Name} проходит по брони!");
                            Console.ResetColor();
                            temp.Remove(guest);                 // удаляем Person          
                            value--;                            // уменьшаем кол-во столов
                            persons = new Queue<Person>(temp);  // по новой записываем в очередь измененный список
                        }
                    }

                // 2 -  происходит удаление первостоящего в очереди без брони
                while(value > 0 && persons.Count > 0) // пока свободные столики есть и очередь не пустая
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($" {persons.Peek().Name} проходит из живой очереди!");
                    Console.ResetColor();
                    persons.Dequeue();  // удаляем первостоящего из очереди
                    value--;            // уменьшаем кол-во столов
                }
            }
        }
        interface IReserved
        {
            bool Reserved();
        }
        class Person : IReserved
        {
            public string? Name { get; set; } // имя
            public Person()
            {
                Console.WriteLine(" Введите фамилию и имя гостя:");
                Name = Console.ReadLine();
            }
            public Person(string name)
            {
                this.Name = name;
            }
            public bool Reserved()         // есть ли бронь у человека
            {
                Random rnd = new Random();
                int value = rnd.Next(0, 20);
                if (value == 5) return true;
                else return false;
            }          
        }
        class OpenCafe
        {
            public void Open(Cafe cafe)
            {
                int free = cafe.FreeTable();
                cafe.QueLine?.ShowLine();
                cafe.QueLine?.RemovePerson(free);
            }
        }
    }
}