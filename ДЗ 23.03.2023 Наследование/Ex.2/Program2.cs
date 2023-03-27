namespace Ex._2
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Console.Title = "Device";
            Console.WriteLine("\t\t\t-Device-");
  
            int s = 0;
            Device[] dev = new Device[s];
            int ind = 0;
            int ch1 = -1,ch2;
            while (true)
            {
                while (true)
                {
                    Console.WriteLine(" Menu");
                    Console.WriteLine(" 1 - add device\n 2 - show info\n 0 - exit");
                    try
                    {
                        ch1 = int.Parse(Console.ReadLine()!);
                        if (ch1 < 0 || ch1 > 2)
                        {
                            throw new Exception(" Incorrect input!");
                        }
                        break;
                    }
                    catch (FormatException)
                    {
                        Error(" Incorrect input!");
                    }
                    catch (Exception ex)
                    {
                        Error(ex.Message);
                    }
                }
                
                switch (ch1)
                {
                    case 1:
                        while(true)
                        {
                            Console.WriteLine(" Choose a device ");
                            Console.WriteLine(" 1 - Teapot\n 2 - Microwave");
                            Console.WriteLine(" 3 - Car\n 4 - Vessel\n");
                            try
                            {
                                ch2 = int.Parse(Console.ReadLine()!);
                                if (ch2 < 1 || ch2 > 4)
                                {
                                    throw new Exception(" Incorrect input!");
                                }
                                break;
                            }
                            catch (FormatException)
                            {
                                Error(" Incorrect input!");        
                            }
                            catch (Exception ex)
                            {
                                Error(ex.Message);                               
                            }
                        }
                        
                        switch (ch2)
                        {
                            case 1:
                                Array.Resize(ref dev, ++s);
                                dev[ind] = new Teapot();
                                ind++;
                                SuccessOutput();
                                break;

                            case 2:
                                Array.Resize(ref dev, ++s);
                                dev[ind] = new Microwave();                                
                                ind++;
                                Console.BackgroundColor = ConsoleColor.Green;
                                SuccessOutput();
                                break;

                            case 3:
                                Array.Resize(ref dev, ++s);
                                dev[ind] = new Car();
                                ind++;
                                SuccessOutput();
                                break;

                            case 4:
                                Array.Resize(ref dev, ++s);
                                dev[ind] = new Vessel();
                                ind++;
                                SuccessOutput();
                                break;
                        }
                        break;
                    case 2:
                        int numb = 0;
                        try
                        {
                            if (dev.Length == 0) throw new NullReferenceException();
                            foreach (var item in dev)
                            {
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine($" Device -{++numb}-");
                                Console.ResetColor();
                                item.Show();
                                item.Sound();
                                item.Desc();
                                Console.WriteLine();
                            }
                        }
                        catch(NullReferenceException)
                        {
                            Error(" Device list is empty!");
                        }
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 0:
                        break;
                }
            }             
        }
        abstract class Device
        {
            public string? name { get; set; }
            public string? description { get; set; }
            public abstract void Sound();
            public abstract void Show();
            public abstract void Desc();
        }
        class Teapot : Device
        {
            public Teapot()
            {
                Console.WriteLine("\n Enter the name of the teapot:");
                name = Console.ReadLine();
                Console.WriteLine(" Enter a description of the teapot:");
                description = Console.ReadLine();

            }

            public override void Sound()
            {
                Console.WriteLine(" Teapot sound: Psh-psh-pshshsh!");
            }
            public override void Show()
            {
                Console.WriteLine(" Teapot name: " + name);
            }
            public override void Desc()
            {
                Console.WriteLine(" Description of the teapot: " +  description);
            }
        }
        class Microwave : Device
        {
            public Microwave()
            {
                Console.WriteLine("\n Enter the name of the microwave:");
                name = Console.ReadLine();
                Console.WriteLine(" Enter a description of the microwave:");
                description = Console.ReadLine();
            }

            public override void Sound()
            {
                Console.WriteLine(" Tzz-tzz-tzzzzzz!");
            }
            public override void Show()
            {
                Console.WriteLine(" Microwave name " + name);
            }
            public override void Desc()
            {
                Console.WriteLine(" Description of the microwave: " + description);
            }
        }
        class Car : Device
        {
            public Car()
            {
                Console.WriteLine("\n Enter the name of the car:");
                name = Console.ReadLine();
                Console.WriteLine(" Enter a description of the car:");
                description = Console.ReadLine();
            }

            public override void Sound()
            {
                Console.WriteLine(" Vroom-vroom-vroom!");
            }
            public override void Show()
            {
                Console.WriteLine(" Car name " + name);
            }
            public override void Desc()
            {
                Console.WriteLine(" Description of the car: " + description);
            }
        }
        class Vessel : Device
        {
            public Vessel()
            {
                Console.WriteLine("\n Enter the name of the vessel:");
                name = Console.ReadLine();
                Console.WriteLine(" Enter a description of the vessel:");
                description = Console.ReadLine();
            }

            public override void Sound()
            {
                Console.WriteLine(" Tu-tuuuuuu!");
            }
            public override void Show()
            {
                Console.WriteLine(" Vessel name " + name);
            }
            public override void Desc()
            {
                Console.WriteLine(" Description of the vessel: " + description);
            }
        }
        static void SuccessOutput()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" Device added successfully!");
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();
        }
        static void Error(string m)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(m);
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();
        }
    }
}