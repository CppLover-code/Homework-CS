﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex._4
{
    internal class Program4
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Enter boolean expression:");
            //string expression;
            //expression = Console.ReadLine();
            String[] expressions = { "16 < 21", "31 > 3", "28 <= 3",
                       "42 >= 18", "12 == 7",
                       "2 != " };
            String pattern = @"(\d+)\s+([<>])\s+(\d+)";//[<.>.=.<=.>=.=.!=]

            foreach (string expression in expressions)
            {
                foreach (System.Text.RegularExpressions.Match m in
                System.Text.RegularExpressions.Regex.Matches(expression, pattern))
                {
                    int value1 = Int32.Parse(m.Groups[1].Value);
                    int value2 = Int32.Parse(m.Groups[3].Value);
                    switch (m.Groups[2].Value)
                    {
                        case "<":
                            Console.WriteLine("{0} = {1}", m.Value, value1 < value2);
                            break;
                        case ">":
                            Console.WriteLine("{0} = {1}", m.Value, value1 > value2);
                            break;
                        case "<=":
                            Console.WriteLine("{0} = {1}", m.Value, value1 <= value2);
                            break;
                        case ">=":
                            Console.WriteLine("{0} = {1:N2}", m.Value, value1 >= value2);
                            break;
                        case "=":
                            Console.WriteLine("{0} = {1:N2}", m.Value, value1 == value2);
                            break;
                        case "!=":
                            Console.WriteLine("{0} = {1:N2}", m.Value, value1 != value2);
                            break;
                    }
                }
            }


            //    / ([<=>]{ 1,2})(\d +)/
            // https://learn.microsoft.com/ru-ru/dotnet/standard/base-types/divide-up-strings
            // регулярные выражения

            //String[] expressions = { "16 + 21", "31 * 3", "28 / 3",
            //           "42 - 18", "12 * 7",
            //           "2, 4, 6, 8" };
            //String pattern = @"(\d+)\s+([-+*/])\s+(\d+)";

            //foreach (string expression in expressions)
            //{
            //    foreach (System.Text.RegularExpressions.Match m in
            //    System.Text.RegularExpressions.Regex.Matches(expression, pattern))
            //    {
            //        int value1 = Int32.Parse(m.Groups[1].Value);
            //        int value2 = Int32.Parse(m.Groups[3].Value);
            //        switch (m.Groups[2].Value)
            //        {
            //            case "+":
            //                Console.WriteLine("{0} = {1}", m.Value, value1 + value2);
            //                break;
            //            case "-":
            //                Console.WriteLine("{0} = {1}", m.Value, value1 - value2);
            //                break;
            //            case "*":
            //                Console.WriteLine("{0} = {1}", m.Value, value1 * value2);
            //                break;
            //            case "/":
            //                Console.WriteLine("{0} = {1:N2}", m.Value, value1 / value2);
            //                break;
            //        }
            //    }
            //}

            //The example displays the following output:
            //       16 + 21 = 37
            //       31 * 3 = 93
            //       28 / 3 = 9.33
            //       42 - 18 = 24
            //       12 * 7 = 84
        }
    }
}
