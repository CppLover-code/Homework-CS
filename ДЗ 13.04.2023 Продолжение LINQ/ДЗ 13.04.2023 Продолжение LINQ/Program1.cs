namespace ДЗ_13._04._2023_Продолжение_LINQ
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            var phones = new Phones(new Phone[]
                {
                    new Phone("Iphone 14", "Apple", 1500, new DateTime(2020, 5, 15)),
                    new Phone("Iphone XR", "Apple", 579, new DateTime(2018, 3, 10)),
                    new Phone("H13", "Nokia", 285, new DateTime(2018, 4, 10)),
                    new Phone("Redmi 10", "Xiaomi", 399, new DateTime(2021, 2, 14)),
                    new Phone("ThinkPhone 8", "Motorola", 1000, new DateTime(2023, 2, 18)),
                    new Phone("Samsung A8", "Samsung", 1200, new DateTime(2020,10,25)),
                    new Phone("Hot 20", "Infinix", 100, new DateTime(2019, 10, 25)),
                    new Phone("Samsung S10", "Samsung", 300, new DateTime(2019,11,15)),
                    new Phone("Iphone 10", "Apple", 500, new DateTime(2020, 5, 15)),
                    new Phone("Samsung S20", "Samsung", 350, new DateTime(2020,8,13)),
                    new Phone("Nokia 5S", "Nokia", 125, new DateTime(2015,7,25)),
                    new Phone("Redmi 10", "Xiaomi", 600, new DateTime(2021, 2, 14)),
                    new Phone("Blade V40", "ZTE", 150, new DateTime(2020, 6, 17)),
                    new Phone("ThinkPhone 8", "Motorola", 1000, new DateTime(2022, 5, 8))
                });

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