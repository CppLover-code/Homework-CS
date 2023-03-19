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
            webSite.Print();
        }
        class WebSite
        {
            public string title;        // название сайта
            public string url;          // путь к сайту
            public string discription;  // описание сайта
            public string ip;           // ip адрес сайта

            public WebSite()
            {
                Console.WriteLine(" C-tor by default");

                Console.WriteLine("\n Enter site name:");
                title = Console.ReadLine();

                Console.WriteLine("\n Enter the url:");
                url = Console.ReadLine();

                Console.WriteLine("\n Enter a description:");
                discription = Console.ReadLine();

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
                Console.WriteLine(" Description: \t" + discription);
                Console.WriteLine(" IP adress: \t" + ip);
            }
            public string GetTitle() { return title; }
            public string GetUrl() { return url; }
            public string GetDiscription() {  return discription; }
            public string GetIp() { return ip; }
        }
    }
}
