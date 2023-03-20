using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ДЗ_16._03._2023_Namespace__exception
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            ForegroundColor = ConsoleColor.DarkCyan;
            WriteLine("\t\t   -Калькулятор для перевода числа-\r\n\t\t-из одной системы исчисления в другую-");
            ResetColor();   
            int choice;

            do
            {
                ForegroundColor = ConsoleColor.Blue;
                WriteLine(" Меню систем исчисления ");
                ResetColor();
                WriteLine(" 1 - десятичное в двоичное");
                WriteLine(" 2 - двоичное в десятичное");
                WriteLine(" 3 - десятичное в шестнадцатеричное");
                WriteLine(" 4 - шестнадцатеричное в десятичное");
                WriteLine(" 0 - выход"); 
                choice = int.Parse(ReadLine());

                switch (choice)
                {
                    case 1:
                        DecToBin(DecInput());
                        break;

                    case 2:
                        BinToDec(BinInput());
                        break;

                    case 3:
                        DecToHex(DecInput());
                        break;

                    case 4:
                        HexToDec(HexInput());
                        break;

                    case 0:
                        return;

                    default:
                        WriteLine(" Некорректный ввод!\n");
                        break;
                }

            } while (true);
        }
        static int DecInput()
        {
            WriteLine(" Введите десятичное число:");
            int dec;
            while (true)
            {
                try
                {
                    dec = int.Parse(ReadLine());
                    return dec;
                }
                catch (OverflowException ex)    // выход за границы диапазона int
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine($"{ex.Message}");
                    ResetColor();
                    WriteLine(" Введите десятичное число:");
                }
                catch (FormatException ex)      // неверный формат
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine($"{ex.Message}");
                    ResetColor();
                    WriteLine("\n Введите десятичное число:");
                }
            } 
        }
        static string BinInput()
        {
            WriteLine(" Введите двоичное число:");
            string bin;
            while (true)
            {
                try
                {
                    bin = ReadLine();
                    char[] chars = bin.ToCharArray();
                    for (int i = 0; i < chars.Length; i++)
                    {
                        if (Char.IsLetter(chars[i]) ||           // если текущий символ - буква или
                           (chars[i] < 0 && chars[i] > 1) ||     // цифра меньше 0 и больше 1
                           Char.IsSymbol(chars[i]))              // или символьный знак
                        {
                            throw new Exception(" Некорректный ввод!");
                        }
                    }
                    return bin;
                }
                catch (Exception ex)    // исключение вручную
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine($"{ex.Message}");
                    ResetColor();
                    WriteLine(" 1Введите двоичное число:");
                }               
            }
        }
        static string HexInput()
        {
            WriteLine(" Введите шестнадцатеричное число:");
            string hex = ReadLine();
            return hex;            
        }
        static void DecToBin(int dec)            // десятичное в двоичное
        {
            string s = Convert.ToString(dec, 2);
            ForegroundColor = ConsoleColor.Green;
            WriteLine($" {dec} в двоичной системе счисления: " + s + "\n");
            ResetColor();
        }
        static void BinToDec(string bin)         // двоичное в десятичное
        {
            int dec = Convert.ToInt32(bin, 2);
            //double res = 0;
            //for (int i = 0; i < bin.Length; i++)
            //{
            //    res += Double.Parse(bin[i].ToString()) * Math.Pow(2, bin.Length - 1 - i);
            //}
            ForegroundColor = ConsoleColor.Green;
            WriteLine($" {bin} в десятичной системе счисления: " + dec + "\n");
            ResetColor();
        }
        static void DecToHex(int dec)            // двоичное в шестнадцатеричное   
        {
            string s = Convert.ToString(dec, 16);
            ForegroundColor = ConsoleColor.Green;
            WriteLine($" {dec} в шестнадцатеричной системе счисления: " + s + "\n");
            ResetColor();
        }
        static void HexToDec(string hex)         // шестнадцатеричное в двоичное
        {
            int dec = 0;
            try
            {
                dec = Convert.ToInt32(hex, 16);
                ForegroundColor = ConsoleColor.Green;
                WriteLine($" {hex} в десятичной системе счисления: " + dec + "\n");
                ResetColor();
            }
            catch(FormatException ex)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine($"{ex.Message}\n");
                ResetColor();
            }        
        }
    }
}
