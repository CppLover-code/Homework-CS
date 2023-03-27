namespace Ex._3
{
    internal class Program3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\tMusical instrument");
            Console.Title = "Musical instrument";

        }
        abstract class MusicalInstrument
        {
            public string? name { get; set; }
            public string? description { get; set; }
            public abstract void Sound();
            public abstract void Show();
            public abstract void Desc();
        }
        class Violin : MusicalInstrument
        {
            public Violin()
            {
                Console.WriteLine("\n Enter the name of the violin:");
                name = Console.ReadLine();
                Console.WriteLine(" Enter a description of the violin:");
                description = Console.ReadLine();
            }

            public override void Sound()
            {
                Console.WriteLine(" Violin sound: Lya-lya-lya!");
            }
            public override void Show()
            {
                Console.WriteLine(" Violin name: " + name);
            }
            public override void Desc()
            {
                Console.WriteLine(" Description of the violin: " + description);
            }
        }
        class Trombone : MusicalInstrument
        {
            public Trombone()
            {
                Console.WriteLine("\n Enter the name of the trombone:");
                name = Console.ReadLine();
                Console.WriteLine(" Enter a description of the trombone:");
                description = Console.ReadLine();
            }

            public override void Sound()
            {
                Console.WriteLine(" Tu-tru-tu-tu!");
            }
            public override void Show()
            {
                Console.WriteLine(" Trombone name " + name);
            }
            public override void Desc()
            {
                Console.WriteLine(" Description of the trombone: " + description);
            }
        }
        class Ukulele : MusicalInstrument
        {
            public Ukulele()
            {
                Console.WriteLine("\n Enter the name of the ukulele:");
                name = Console.ReadLine();
                Console.WriteLine(" Enter a description of the ukulele:");
                description = Console.ReadLine();
            }

            public override void Sound()
            {
                Console.WriteLine(" Drin'-brin'!");
            }
            public override void Show()
            {
                Console.WriteLine(" Ukulele name " + name);
            }
            public override void Desc()
            {
                Console.WriteLine(" Ukulele of the ukulele: " + description);
            }
        }
        class Сello : MusicalInstrument
        {
            public Сello()
            {
                Console.WriteLine("\n Enter the name of the cello:");
                name = Console.ReadLine();
                Console.WriteLine(" Enter a description of the cello:");
                description = Console.ReadLine();
            }

            public override void Sound()
            {
                Console.WriteLine(" Tru-lya-lya!");
            }
            public override void Show()
            {
                Console.WriteLine(" Сello name " + name);
            }
            public override void Desc()
            {
                Console.WriteLine(" Description of the cello: " + description);
            }
        }
    }
}