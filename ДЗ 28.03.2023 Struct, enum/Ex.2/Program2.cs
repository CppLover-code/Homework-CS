namespace Ex._2
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t-Decimal number-");
            Decimal dec = new Decimal(125);
            dec.ToBinary();
            dec.ToOctal();
            dec.ToHexadecimal();    

        }
        struct Decimal
        {
            int number;
            public Decimal(int value)
            {
                number = value;
            }
            public void ToBinary()
            {
                string s = Convert.ToString(this.number, 2);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($" {this.number} в двоичной системе счисления: " + s + "\n");
                Console.ResetColor();
            }
            public void ToOctal()
            {
                string s = Convert.ToString(this.number, 8);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($" {this.number} в восьмеричной системе счисления: " + s + "\n");
                Console.ResetColor();
            }
            public void ToHexadecimal()
            {
                string s = Convert.ToString(this.number, 16);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($" {this.number} в шестнадцатеричной системе счисления: " + s + "\n");
                Console.ResetColor();
            }
        }
    }
}