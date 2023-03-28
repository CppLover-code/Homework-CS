namespace Ex._3
{
    internal class Program3
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t-RGB color-");
            RGB rgb = new RGB(35,16,89);
            rgb.ToHEX();    
        }
        struct RGB
        {
            int red, green, blue;
            public RGB(int r,int g, int b)
            {
                this.red = r;
                this.green = g;
                this.blue = b;
            }
            public override string ToString()
            {
                return " RGB(" + red + "," + green + "," + blue + ")";
            }
            public void ToHEX()
            {
                string r = Convert.ToString(this.red, 16);
                string g = Convert.ToString(this.green, 16);
                string b = Convert.ToString(this.blue, 16);
                //Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($" {this} в HEX: #" + r + g + b + "\n");
                //Console.ResetColor();
            }
            public void ToHSL()
            {

            }
            public void ToCMYK()
            {

            }
        }
    }
}