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
            Clear();                    // очистка буфера консоли
            int choice;
            do
            {
                WriteLine(" Information Menu ");
                WriteLine(" 1 - get name\n 2 - get address");
                WriteLine(" 3 - get description\n 4 - get contact phone");
                WriteLine(" 5 - get contact mail\n 6 - get all information\n 7 - exit");

                choice = int.Parse(ReadLine());

                switch (choice)
                {
                    case 1:
                        WriteLine($" Store name: {shop.GetName()}\n");
                        break;

                    case 2:
                        WriteLine($" Address: {shop.GetAddress()}\n");
                        break;

                    case 3:
                        WriteLine($" Description: {shop.GetDescription()}\n");
                        break;

                    case 4:
                        WriteLine($" Contact phone: {shop.GetTel()}\n");
                        break;

                    case 5:
                        WriteLine($" Contact e-mail: {shop.GetMail()}\n");
                        break;

                    case 6:
                        shop.Print();
                        break;

                    case 7:
                        return;

                    default:
                        WriteLine(" Incorrect input!\n");
                        break;
                }
            } while (true);
        }

        class Shop
        {
            readonly string name;           // название магазина
            readonly string address;        // адрес магазина
            readonly string description;    // описание профиля магазина
            readonly long tel;              // контактный телефон
            readonly string mail;           // контактный e-mail

            public Shop()
            {
                //WriteLine(" C-tor by default");

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
                WriteLine(" Contact e-mail:\t" + mail + "\n");
            }

            public string GetName() { return name; }
            public string GetAddress() { return address; }
            public string GetDescription() { return description; }
            public long GetTel() { return tel; }
            public string GetMail() { return mail; }
        }
    }
}
