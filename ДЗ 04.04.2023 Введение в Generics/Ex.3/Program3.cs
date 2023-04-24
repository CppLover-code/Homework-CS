namespace Ex._3
{
    internal class Program3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        
        interface IFree
        {
            int Free();
        }
        class Cafe : IFree
        {
            public string? Title { get; set; } // название кафе
            public int Table { get; set; }     // кол-во столиков
            int IFree.Free()                   // кол-во свободных столиков
            {
                Random rnd = new Random();
                int value = rnd.Next(0, 5);
                return value;
            }
        }
        class Line
        {
            Queue<Person> persons = new();
            public Line() { }       // конструктор по умолчанию
            public Line(string p)   // конструктор с параметрами
            {
                this.persons.Enqueue(new Person() { Name = "Tom" });
            }
            public void ShowLine()  // показ очереди
            {
                Console.WriteLine("Сейчас в очереди {0} человек", persons.Count);
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
            public void Remove(int count) // удаление гостей из очереди
            {
                for (int i = 0; i < count; i++)
                    persons.Dequeue();
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
            bool IReserved.Reserved()         // есть ли бронь у человека
            {
                Random rnd = new Random();
                int value = rnd.Next(0, 10);
                if (value == 5) return true;
                else return false;
            }
        }
    }
}