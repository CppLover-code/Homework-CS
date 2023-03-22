using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Ex._2
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            WriteLine(" Shop ");
            Shop shop = new Shop();
            Clear();                    // очистка буфера консоли
            
        }

        class Shop
        {
            private string name;           // название магазина
            private string address;        // адрес магазина
            private string description;    // описание профиля магазина
            private long tel;              // контактный телефон
            private string mail;           // контактный e-mail
            private double area;           // площадь магазина


            public Shop()
            {
                WriteLine("\n Enter store name:");
                name = ReadLine();

                WriteLine("\n Enter store address:");
                address = ReadLine();

                WriteLine("\n Enter a store profile description:");
                description = ReadLine();

                WriteLine("\n Enter contact phone:");
                tel = long.Parse(ReadLine());

                WriteLine("\n Enter contact e-mail:");
                mail = ReadLine();

                WriteLine("\n Enter store area:");
                area = double.Parse(ReadLine());
            }

            public void Print()
            {
                BackgroundColor = ConsoleColor.Blue;
                ForegroundColor = ConsoleColor.Black;
                WriteLine("\n -Information about store-");
                ResetColor();
                WriteLine(" Store name:\t\t" + name);
                WriteLine(" Address:\t\t" + address);
                WriteLine(" Description:\t\t" + description);
                WriteLine(" Contact phone:\t\t" + tel);
                WriteLine(" Contact e-mail:\t" + mail);
                WriteLine(" Store area:\t" + area + "\n");
            }

        }
    }
}
