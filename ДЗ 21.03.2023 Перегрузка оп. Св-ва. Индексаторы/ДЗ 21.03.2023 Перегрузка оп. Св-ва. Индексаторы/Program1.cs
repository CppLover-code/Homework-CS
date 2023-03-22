using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

            Magazine mag1 = new Magazine();
            Magazine mag2 = new Magazine();

            Clear();                            // очистка буфера консоли
            mag1.Print();
            mag2.Print();

            WriteLine("\n -Add employees-\n");  // добавление сотрудников
            mag1.Employees += 2;
            Console.WriteLine($" Add {2} employees for {mag1.Name}. Currently count of employees - {mag1.Employees}");

            mag2.Employees += 3;
            Console.WriteLine($" Add {3} employees for {mag2.Name}. Currently count of employees - {mag2.Employees}");

            WriteLine("\n -Fire employees-\n"); // увольнение сотрудников
            mag1.Employees -= 1;
            Console.WriteLine($" Fire {1} employees for {mag1.Name}. Currently count of employees - {mag1.Employees}");

            mag2.Employees -= 2;
            Console.WriteLine($" Fire {2} employees for {mag2.Name}. Currently count of employees - {mag2.Employees}");

            WriteLine("\n -Comparison of the number of employees in two magazines-\n");

            Console.WriteLine($"{mag1.Name} == {mag2.Name} - {mag1 == mag2} \n");
            Console.WriteLine($"{mag1.Name} != {mag2.Name} - {mag1 != mag2} \n");
            Console.WriteLine($"{mag1.Name}  > {mag2.Name} - {mag1  > mag2} \n");
            Console.WriteLine($"{mag1.Name}  < {mag2.Name} - {mag1  < mag2} \n");
            Console.WriteLine($"{mag1.Name} Equals {mag2.Name} - {mag1.Employees.Equals(mag2.Employees)}\n");
        }

        class Magazine
        {
            private string name;            // название журнала
            private int year;               // год основания
            private string description;     // описание
            private long tel;               // контактный телефон
            private string mail;            // контактный e-mail
            private int employees;          // кол-во сотрудников
            private static int counter = 0; // счётчик журналов

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
                set { employees = value; }
                get { return employees; }
            }

            public static int Counter
            {
                get { return counter; }
            }
            public Magazine()
            {

                counter++;

                WriteLine($"\n Magazine {counter}:");

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
                WriteLine($"\n -Information about the magazine {this.Name}-");
                ResetColor();
                WriteLine(" Name:\t\t\t" + name);
                WriteLine(" Year of foundation:\t" + year);
                WriteLine(" Contact phone:\t\t" + tel);
                WriteLine(" Contact e-mail:\t" + mail);
                WriteLine(" Count of employees:\t" + employees + "\n");
            }

            public static int operator +(Magazine m, int x)             // увеличение кол-ва сотрудников на X
            {
                return m.employees + x;
            }
            public static int operator -(Magazine m, int x)             // уменьшение кол-ва сотрудников на X
            {
                return m.employees - x;
            }
            public static bool operator ==(Magazine m1, Magazine m2)    // равенство сотрудников в двух журналах
            {
                return Object.Equals(m1.employees, m2.employees);
            }
            public static bool operator !=(Magazine m1, Magazine m2)    // НЕравенство сотрудников в двух журналах
            {
                return !Object.Equals(m1.employees, m2.employees);
            }
            public static bool operator <(Magazine m1, Magazine m2)
            {
                return m1.employees < m2.employees;
            }
            public static bool operator >(Magazine m1, Magazine m2)
            {
                return m1.employees >m2.employees;
            }
            public override bool Equals(object m)  
            {
                return this.ToString() == m.ToString();
            }
            public override int GetHashCode()
            {
                return this.ToString().GetHashCode();
            }
        }
    }
}