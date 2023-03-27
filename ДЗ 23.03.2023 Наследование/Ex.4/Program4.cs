namespace Ex._4
{
    internal class Program4
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t-Worker-\n");

            Worker[] workers =
            {
                new President("Tomas"),
                new Security("James"),
                new Manager("Alice"),
                new Engineer("Lucas")
            };

            foreach (Worker worker in workers)
            {
                worker.Print();
            }
          
        }
        abstract class Worker
        {
            public string name { get; set; }
            public Worker(string n)
            {
                name = n;
            }
            public abstract void Print();
        }
        class President : Worker
        {
            public President(string n) : base(n) { }
            public override void Print()
            {
                Console.WriteLine($" This is the president\t- {name}");
            }
        }
        class Security : Worker
        {
            public Security(string n) : base(n) { }
            public override void Print()
            {
                Console.WriteLine($" This is security\t- {name}");
            }
        }
        class Manager : Worker
        {
            public Manager(string n) : base(n) { }
            public override void Print()
            {
                Console.WriteLine($" This is the manager\t- {name}");
            }
        }
        class Engineer : Worker
        {
            public Engineer(string n) : base(n) { }
            public override void Print()
            {
                Console.WriteLine($" This is an engineer\t- {name}");
            }
        }

    }
}