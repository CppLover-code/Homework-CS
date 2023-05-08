namespace ДЗ_13._04._2023_Продолжение_LINQ
{
    internal class Program1
    {
        static void Main(string[] args)
        {


        }
        class Phone
        {
            public string? Title { get; set; }
            public string? Manufacturer { get; set; }
            public double Price { get; set; }
            public DateTime Date { get; set; }

            public Phone() { }
            public Phone(string title, string manufacturer, double price, DateTime date)
            {
                this.Title = title;
                this.Manufacturer = manufacturer;
                this.Price = price;
                this.Date = date;
            }
            public override string ToString()
            {
                return $"Phone model:{Title}\nManufacturer:{Manufacturer}\nPrice:{Price}\n Date of issue:{Date}";
            }
        }
        class Phones
        {
            public Phone[] phones;
            public Phones(Phone[] phones) => this.phones = phones;

        }
    }
}