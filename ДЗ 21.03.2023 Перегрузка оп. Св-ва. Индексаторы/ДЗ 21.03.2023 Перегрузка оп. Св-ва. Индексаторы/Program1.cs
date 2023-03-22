using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ДЗ_21._03._2023_Перегрузка_оп.Св_ва.Индексаторы
{
    internal class Program1
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
                WriteLine(" 5 - get contact mail\n 6 - get count of employees");
                WriteLine(" 7 - get all information\n 8 - exit");

                choice = int.Parse(ReadLine());

                switch (choice)
                {
                    case 1:
                        WriteLine($" Magazine name: {mag.Name}\n");
                        break;

                    case 2:
                        WriteLine($" Year of foundation: {mag.Year}\n");
                        break;

                    case 3:
                        WriteLine($" Description: {mag.Description}\n");
                        break;

                    case 4:
                        WriteLine($" Contact phone: {mag.Tel}\n");
                        break;

                    case 5:
                        WriteLine($" Contact e-mail: {mag.Mail}\n");
                        break;

                    case 6:
                        WriteLine($" Count of employees: {mag.Employees}\n");
                        break;

                    case 7:
                        mag.Print();
                        break;

                    case 8:
                        return;

                    default:
                        WriteLine(" Incorrect input!\n");
                        break;
                }
            } while (true);
        }

        class Magazine
        {
            private string name;   // название журнала
            private int year;      // год основания
            private string description;  // описание
            private long tel;      // контактный телефон
            private string mail;   // контактный e-mail
            private int employees;    // кол-во сотрудников

            public string Name
            {
                get { return name; }
            }
            public int Year
            {
                get { return year; }
            }
            public string Description
            {
                get { return description; }
            }
            public long Tel
            {
                get { return tel; }
            }
            public string Mail
            {
                get { return mail; }
            }
            public int Employees
            {
                get { return employees; }
            }

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

                WriteLine("\n Enter count of employees:");
                employees = int.Parse(ReadLine());
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
                WriteLine(" Contact e-mail:\t" + mail + "\n");
                WriteLine(" Count of employees:\t" + employees + "\n");
            }          
        }
    }
}
