using System.Drawing;
using System.Runtime.InteropServices;

namespace Ex._3
{
    internal class Program3
    {
        static void Main(string[] args)
        {
            Console.Title = " RGB Color Converter";
            Console.WriteLine("\t\t-RGB color converter-");
            RGB rgb = new RGB();
            Console.ReadLine();
            Console.Clear();

            ConsoleKey key;

            while (true)
            {
                Console.WriteLine(" Converter menu");
                Console.WriteLine(
                    " 1 - RGB to HEX\n" +
                    " 2 - RGB to HSL\n" +
                    " 3 - RGB to CMYK\n" +
                    " 4 - Enter new RGB data\n" +
                    " Esc - exit");

                ConsoleKeyInfo info = Console.ReadKey();
                key = info.Key;

                switch (key)
                {
                    case ConsoleKey.NumPad1:
                        rgb.ToHEX();
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case ConsoleKey.NumPad2:
                        rgb.ToHSL();
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case ConsoleKey.NumPad3:
                        rgb.ToCMYK();
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case ConsoleKey.NumPad4:
                        rgb = new RGB();
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case ConsoleKey.Escape:
                        return;

                    default:
                        Console.WriteLine("\n Incorrect input!\n");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }
        struct RGB
        {
            int red, green, blue;
            public RGB()                                              // конструктор без параметров с вводом от пользователя
            {
                while (true)
                {
                    Console.WriteLine("\n Enter color values from 0 to 255 ");
                    try
                    {
                        Console.Write(" Red: ");
                        red = int.Parse(Console.ReadLine()!);
                        Console.Write(" Green: ");
                        green = int.Parse(Console.ReadLine()!);
                        Console.Write(" Blue: ");
                        blue = int.Parse(Console.ReadLine()!);

                        if (red < 0 || red > 255 ||                   // если введенное число не входит
                            green < 0 || green > 255 ||               // в диапазон от 0 до 255
                            blue < 0 || blue > 255)
                        {
                            throw new Exception(" Incorrect input!"); // бросаем исключение
                        }
                        break;
                    }
                    catch (FormatException ex)                        // ловим некорректный ввод
                    {                                                 // не удалось спарсить число int
                        Console.WriteLine(" Incorrect input!", ex);
                    }
                    catch (Exception ex)                              // ловим нами созданное исключение
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
            public RGB(int r, int g, int b)                            // конструктор с параметрами
            {
                this.red = r;
                this.green = g;
                this.blue = b;
            }
            public override string ToString()                         // перегрузка для вывода структуры
            {
                return "RGB(" + red + "," + green + "," + blue + ")";
            }
            public void ToHEX()                                       // метод конвертации в HEX
            {
                string r = Convert.ToString(this.red, 16);
                string g = Convert.ToString(this.green, 16);
                string b = Convert.ToString(this.blue, 16);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n -Result- \n");
                Console.ResetColor();
                Console.WriteLine($" {this} in HEX: #" + r + g + b + "\n");
            }
            public void ToHSL()                                       // метод конвертации в HSL
            {
                float r, g, b;
                float diff, max, min;
                double H, S, L;

                r = (float)red / 255;
                g = (float)green / 255;
                b = (float)blue / 255;

                max = Math.Max(r, Math.Max(g, b));
                min = Math.Min(r, Math.Min(g, b));
                diff = max - min;
                L = (max + min) / 2;
                H = 0;

                if (diff == 0) S = 0;
                else S = Math.Round((diff / (1 - Math.Abs(2 * L - 1))) * 100);

                L = Math.Round(L * 100);

                if (max == r && max == g && max == b) H = 0;
                else
                {
                    if (max == r) H = Math.Round(60 * (((g - b) / diff) % 6));
                    if (max == g) H = Math.Round(60 * (2 + (b - r) / diff));
                    if (max == b) H = Math.Round(60 * (4 + (r - g) / diff));
                }


                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n -Result- \n");
                Console.ResetColor();
                Console.WriteLine($" {this} in HSL:\n" +
                    $" Hue\t\t{H}°\n" +
                    $" Saturation\t{S}%\n" +
                    $" Lightness\t{L}%\n");
            }
            public void ToCMYK()                                      // метод конвертации в CMYK
            {
                double cyan, magenta, yellow, black, max;
                double C, M, Y;

                if (red == 0 && green == 0 && blue == 0)
                {
                    cyan = magenta = yellow = 0;
                    C = M = Y = 0;
                }
                else
                {
                    C = (float)red / 255;
                    M = (float)green / 255;
                    Y = (float)blue / 255;
                }

                max = Math.Max(C, Math.Max(M, Y));

                cyan = Math.Round((max - C) / max * 100);
                magenta = Math.Round((max - M) / max * 100);
                yellow = Math.Round((max - Y) / max * 100);
                black = Math.Round((1 - max) * 100);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n -Result- \n");
                Console.ResetColor();
                Console.WriteLine($" {this} in СMYK:\n" +
                    $" Сyan\t\t{cyan}%\n" +
                    $" Magenta\t{magenta}%\n" +
                    $" Yellow\t\t{yellow}%\n" +
                    $" Key\t\t{black}%\n");
            }
        }
    }
    // три метода конвертации основаны на формулах
}