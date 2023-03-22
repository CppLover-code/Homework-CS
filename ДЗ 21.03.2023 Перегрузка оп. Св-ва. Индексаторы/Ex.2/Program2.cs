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
            WriteLine(" Store ");
            Store store1 = new Store();
            Store store2 = new Store();
            Clear();                            // очистка буфера консоли

            store1.Print();
            store2.Print();

            WriteLine("\n -Adding Area-\n");  // добавление площади
            store1.Area += 2;
            Console.WriteLine($" Adding {2} to the area for {store1.Name}. Current area - {store1.Area}");

            store2.Area += 3;
            Console.WriteLine($" Adding {3} to the area for {store2.Name}. Current area - {store2.Area}");

            WriteLine("\n -Area reduction-\n"); // уменьшение площади
            store1.Area -= 1;
            Console.WriteLine($" Area reduction by {1} for {store1.Name}. Current area - {store1.Area}");

            store2.Area -= 2;
            Console.WriteLine($" Area reduction by {2} for {store2.Name}. Current area - {store2.Area}");

            WriteLine("\n -Comparison of the areas of two stores-\n");

            Console.WriteLine($"{store1.Name} == {store2.Name} - {store1 == store2} \n");
            Console.WriteLine($"{store1.Name} != {store2.Name} - {store1 != store2} \n");
            Console.WriteLine($"{store1.Name}  > {store2.Name} - {store1 > store2} \n");
            Console.WriteLine($"{store1.Name}  < {store2.Name} - {store1 < store2} \n");
            Console.WriteLine($"{store1.Name} Equals {store2.Name} - {store1.Area.Equals(store2.Area)}\n");

        }

        class Store
        {
            private string name;            // название магазина
            private string address;         // адрес магазина
            private string description;     // описание профиля магазина
            private long tel;               // контактный телефон
            private string mail;            // контактный e-mail
            private double area;            // площадь магазина
            private static int counter = 0; // счётчик магазинов

            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            public string Address
            {
                get { return address; }
                set { address = value; }
            }
            public string Description
            {
                get { return description; }
                set { description = value; }
            }
            public long Tel
            {
                get { return tel; }
                set { tel = value; }
            }
            public string Mail
            {
                get { return mail; }
                set { mail = value; }
            }
            public double Area
            {
                get { return area; }
                set { area = value; }
            }
            public static int Counter
            {
                get { return counter; }
            }
            public Store()
            {
                counter++;

                WriteLine($"\n Store {counter}:");

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
                WriteLine($"\n -Information about store {this.Name}-");
                ResetColor();
                WriteLine(" Store name:\t\t" + name);
                WriteLine(" Address:\t\t" + address);
                WriteLine(" Description:\t\t" + description);
                WriteLine(" Contact phone:\t\t" + tel);
                WriteLine(" Contact e-mail:\t" + mail);
                WriteLine(" Store area:\t\t" + area + "\n");
            }
            public static double operator +(Store s, double x)     // увеличение площади 
            {
                return s.area + x;
            }
            public static double operator -(Store s, double x)     // уменьшение площади
            {
                return s.area - x;
            }
            public static bool operator ==(Store s1, Store s2)    // равенство площадей
            {
                return Object.Equals(s1.area, s2.area);
            }
            public static bool operator !=(Store s1, Store s2)    // НЕравенство площадей
            {     
                return !Object.Equals(s1.area, s2.area);
            }
            public static bool operator <(Store s1, Store s2)
            {
                return s1.area < s2.area;
            }
            public static bool operator >(Store s1, Store s2)
            {
                return s1.area > s2.area;
            }
            public override bool Equals(object s)
            {
                return this.ToString() == s.ToString();
            }
            public override int GetHashCode()
            {
                return this.ToString().GetHashCode();
            }
        }
    }
}
