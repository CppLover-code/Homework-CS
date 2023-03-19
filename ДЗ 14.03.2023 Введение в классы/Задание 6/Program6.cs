using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Задание_6
{
    internal class Program6
    {
        static void Main(string[] args)
        {
            WriteLine(" Shop ");
            Shop shop = new Shop();
            Clear();
            shop.Print();
        }

        class Shop
        {
            readonly string name; // название журнала
            readonly int year; // год основания
            readonly long tel; // контактный телефон
            readonly string mail; // контактный e-mail

            public Shop()
            {
                WriteLine(" C-tor by default");

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
                WriteLine(" Year of foundation:\t" + year);
                WriteLine(" Contact phone:\t\t" + tel);
                WriteLine(" Contact e-mail:\t" + mail);
            }

            public string GetName() { return name; }
            public int GetYear() { return year; }
            public long GetTel() { return tel; }
            public string GetMail() { return mail; }
        }
        // добавить проверку года, телефона хотя бы
    }
}
