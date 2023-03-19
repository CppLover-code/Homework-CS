using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Задание_5
{
    internal class Program5
    {
        static void Main(string[] args)
        {
            WriteLine(" Magazine ");
            Magazine mag = new Magazine();
            Console.Clear();                    // очистка буфера консоли
            int choice;
            do
            {
                Console.WriteLine(" Information Menu ");
                Console.WriteLine(" 1 - get name\n 2 - get year of foundation");
                Console.WriteLine(" 3 - get discription\n 4 - get IP adress");
                Console.WriteLine(" 5 - get all information\n 6 - exit");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine($" Magazine name: {mag.GetName()}\n");
                        break;

                    case 2:
                        Console.WriteLine($" Year of foundation: {mag.GetYear()}\n");
                        break;

                    case 3:
                        Console.WriteLine($" Contact phone: {mag.GetTel()}\n");
                        break;

                    case 4:
                        Console.WriteLine($" Contact e-mail: {mag.GetMail()}\n");
                        break;

                    case 5:
                        mag.Print();
                        break;

                    case 6:
                        return;

                    default:
                        Console.WriteLine(" Incorrect input!\n");
                        break;
                }
            } while (true);
        }

        class Magazine
        {
            readonly string name;   // название журнала
            readonly int year;      // год основания
            readonly long tel;      // контактный телефон
            readonly string mail;   // контактный e-mail

            public Magazine()
            {
                //WriteLine(" C-tor by default");

                WriteLine("\n Enter magazine name:");
                name = ReadLine();

                WriteLine("\n Enter year of foundation:");
                year = int.Parse(ReadLine());

                WriteLine("\n Enter contact phone:");
                tel = long.Parse(ReadLine());

                WriteLine("\n Enter contact e-mail:");
                mail = ReadLine();
            }

            public void Print()
            {
                BackgroundColor = ConsoleColor.Blue;
                ForegroundColor = ConsoleColor.Black;
                WriteLine("\n -Information about the magazine-");
                ResetColor();
                WriteLine(" Name:\t\t\t" + name);
                WriteLine(" Year of foundation:\t" +  year);
                WriteLine(" Contact phone:\t\t" +  tel);
                WriteLine(" Contact e-mail:\t" + mail + "\n");
            }

            public string GetName() { return name; }
            public int GetYear() { return year; }
            public long GetTel() { return tel; }
            public string GetMail() { return mail; }
        }
        // можно добавить проверку года, телефона
    }
}
