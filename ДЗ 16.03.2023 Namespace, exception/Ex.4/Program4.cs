using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Ex._4
{
    internal class Program4
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Enter boolean expression:");
            string expressions;
            expressions = Console.ReadLine();

            String pattern = @"(\d+)\s?([<=]*[>=]*[==]*[!=]*)\s?(\d+)"; // https://cutt.ly/P4bZvWe https://cutt.ly/54bX2kE
            try
            {
                Match m = Regex.Match(expressions, pattern);
                if (!m.Success) { throw new Exception(" alyo "); }
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
            }
            try
            {
                foreach (System.Text.RegularExpressions.Match m in
                                System.Text.RegularExpressions.Regex.Matches(expressions, pattern))
                {
                    int value1;// = Int32.Parse(m.Groups[1].Value);

                    bool result = int.TryParse(m.Groups[1].Value, out value1);
                    if (result == true)
                        Console.WriteLine($"Преобразование прошло успешно. Число: {value1}");
                    else
                        Console.WriteLine("Преобразование завершилось неудачно");
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
                        case "==":
                            Console.WriteLine("{0} = {1:N2}", m.Value, value1 == value2);
                            break;
                        case "!=":
                            Console.WriteLine("{0} = {1:N2}", m.Value, value1 != value2);
                            break;
                        default:
                            throw new Exception(" huynya ");
                    }
                }


            }
            catch (Exception ex)
            { 
                Console.WriteLine(ex.Message);
            }
        }
            
    }
}
