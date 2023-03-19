using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_4
{
    internal class Program4
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Web site ");

            WebSite webSite = new WebSite();
            Console.Clear();                    // очистка буфера консоли
            int choice;
            do
            {
                Console.WriteLine(" Information Menu ");
                Console.WriteLine(" 1 - get site title\n 2 - get url");
                Console.WriteLine(" 3 - get description\n 4 - get IP adress");
                Console.WriteLine(" 5 - get all information\n 6 - exit");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine($" Title: {webSite.GetTitle()}\n");
                        break;

                    case 2:
                        Console.WriteLine($" URL: {webSite.GetUrl()}\n");
                        break;

                    case 3:
                        Console.WriteLine($" Description: {webSite.GetDescription()}\n");
                        break;

                    case 4:
                        Console.WriteLine($" IP adress: {webSite.GetIp()}\n");
                        break;

                    case 5:
                        webSite.Print();
                        break;

                    case 6:
                        return;

                    default:
                        Console.WriteLine(" Incorrect input!\n");
                        break;
                }   
            } while (true);           
        }
        class WebSite
        {
            public string title;        // название сайта
            public string url;          // путь к сайту
            public string description;  // описание сайта
            public string ip;           // ip адрес сайта

            public WebSite()
            {
                //Console.WriteLine(" C-tor by default");
                Console.WriteLine("\n Enter site name:");
                title = Console.ReadLine();

                Console.WriteLine("\n Enter the url:");
                url = Console.ReadLine();

                Console.WriteLine("\n Enter a description:");
                description = Console.ReadLine();

                Console.WriteLine("\n Enter ip address:");
                ip = Console.ReadLine();
            }

            public void Print()
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.ForegroundColor = ConsoleColor.Black; 
                Console.WriteLine("\n -Information about the site-");
                Console.ResetColor();
                Console.WriteLine(" Title: \t" + title);
                Console.WriteLine(" URL: \t\t" + url);
                Console.WriteLine(" Description: \t" + description);
                Console.WriteLine(" IP adress: \t" + ip + "\n");
            }
            public string GetTitle() { return title; }
            public string GetUrl() { return url; }
            public string GetDescription() {  return description; }
            public string GetIp() { return ip; }
        }
    }
}
