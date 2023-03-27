using System.Reflection.Emit;
using System.Security.Principal;

namespace Ex._3
{
    internal class Program3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\t-Musical instrument-");
            Console.Title = "Musical instrument";
#pragma warning disable CA1416 // Проверка совместимости платформы
            Console.SetWindowSize(72, 35);
            
            MusicalInstrument[] musicalInstrument =
            {
                new Violin("Stradivarius"," The Stradivari's sound is described as more \"direct and precise\",\n" +
                           " responding to the slightest touch with refined direction and elegance."),
                new Trombone("Trombone-soprano"," The sound color of the trombone is very rich, it can be courageous,\n" +
                            " bright and formidable, but it can be calm and lyrical, so the\n" +
                            " instrument was originally used in church works."),
                new Ukulele("Alt ukulele"," This is one of the varieties of the guitar - a four-stringed plucked\n" +
                            " musical instrument, which is suitable both for playing chord\n" +
                            "accompaniment and for performing melodic lines."),  
                new Сello("Сello 4/4"," The cello belongs to the group of bowed string instruments and has a\n" +
                          " typical curved shape. It is larger than the viola, has a lower voice,\n" +
                          " but less double bass and higher in timbre.")
            };

            foreach (var instrument in musicalInstrument)
            {
                int i = ((instrument.GetType().ToString()).IndexOf('+'));
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"\t-{ (instrument.GetType().ToString()).Substring(i + 1)}- ");
                Console.ResetColor();
                instrument.Show();
                instrument.Sound();
                instrument.Desc();
                Console.WriteLine();
            }
        }
        class MusicalInstrument
        {
            public string? name { get; set; }
            public string? description { get; set; }
            public MusicalInstrument() { }
            public MusicalInstrument(string n, string d)
            {
                name = n;
                description = d;
            }
            public virtual void Sound() { }
            public virtual void Show() { }
            public virtual void Desc() { }
        }
        class Violin : MusicalInstrument
        {
            public Violin (string n, string d) : base(n,d) { }

            public override void Sound()
            {
                Console.WriteLine(" ► Violin sound: Lya-lya-lya!");
            }
            public override void Show()
            {
                Console.WriteLine(" ► Violin name:  " + name);
            }
            public override void Desc()
            {
                Console.WriteLine(" ► Description of the violin:\n" + description);
            }
        }
        class Trombone : MusicalInstrument
        {
            public Trombone (string n, string d) : base(n, d) { }
            public override void Sound()
            {
                Console.WriteLine(" ► Trombone sound: Tu-tru-tu-tu!");
            }
            public override void Show()
            {
                Console.WriteLine(" ► Trombone name:  " + name);
            }
            public override void Desc()
            {
                Console.WriteLine(" ► Description of the trombone:\n" + description);
            }
        }
        class Ukulele : MusicalInstrument
        {
            public Ukulele (string n, string d) : base(n, d) { }
            public override void Sound()
            {
                Console.WriteLine(" ► Ukulele sound: Drin'-brin'!");
            }
            public override void Show()
            {
                Console.WriteLine(" ► Ukulele name:  " + name);
            }
            public override void Desc()
            {
                Console.WriteLine(" ► Description of the ukulele:\n" + description);
            }
        }
        class Сello : MusicalInstrument
        {
            public Сello (string n, string d) : base(n, d) { }         
            public override void Sound()
            {
                Console.WriteLine(" ► Сello sound: Tru-lya-lya!");
            }
            public override void Show()
            {
                Console.WriteLine(" ► Сello name:  " + name);
            }
            public override void Desc()
            {
                Console.WriteLine(" ► Description of the cello:\n" + description);
            }
        }
    }
}