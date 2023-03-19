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
            Clear();                    // очистка буфера консоли
            int choice;
            do
            {
                WriteLine(" Information Menu ");
                WriteLine(" 1 - get name\n 2 - get year of foundation");
                WriteLine(" 3 - get description\n 4 - get contact phone");
                WriteLine(" 5 - get contact mail\n 6 - get all information\n 7 - exit");

                choice = int.Parse(ReadLine());

                switch (choice)
                {
                    case 1:
                        WriteLine($" Magazine name: {mag.GetName()}\n");
                        break;

                    case 2:
                        WriteLine($" Year of foundation: {mag.GetYear()}\n");
                        break;

                    case 3:
                        WriteLine($" Description: {mag.GetDescription()}\n");
                        break;

                    case 4:
                        WriteLine($" Contact phone: {mag.GetTel()}\n");
                        break;

                    case 5:
                        WriteLine($" Contact e-mail: {mag.GetMail()}\n");
                        break;

                    case 6:
                        mag.Print();
                        break;

                    case 7:
                        return;

                    default:
                        WriteLine(" Incorrect input!\n");
                        break;
                }
            } while (true);
        }

        class Magazine
        {
            readonly string name;   // название журнала
            readonly int year;      // год основания
            readonly string description;  // описание
            readonly long tel;      // контактный телефон
            readonly string mail;   // контактный e-mail

            public Magazine()
            {
                //WriteLine(" C-tor by default");

                WriteLine("\n Enter magazine name:");
                name = ReadLine();

                WriteLine("\n Enter year of foundation:");
                year = int.Parse(ReadLine());

                WriteLine("\n Enter a description:");
                description = ReadLine();

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
            public string GetDescription() { return description; }  
            public long GetTel() { return tel; }
            public string GetMail() { return mail; }
        }
        // можно добавить проверку года, телефона
    }
}
