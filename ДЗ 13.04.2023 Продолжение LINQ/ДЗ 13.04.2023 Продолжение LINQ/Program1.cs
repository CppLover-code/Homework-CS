namespace ДЗ_13._04._2023_Продолжение_LINQ
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            Console.Title = "LINQ запросы для массива телефонов";
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

            int choice;
            while (true)
            {
                Console.WriteLine("\t-Меню для получения информации-\n" +
                    " 1.Информация о всех телефонах\n" +
                    " 2.Количество всех телефонов\n" +
                    " 3.Количество телефонов с ценой больше 100\n" +
                    " 4.Количество телефонов с ценой в диапазоне от 400 до 700\n" +
                    " 5.Количество телефонов конкретного производителя\n" +
                    " 6.Найти телефон с минимальной ценой\n" +
                    " 7.Найти телефон с максимальной ценой\n" +
                    " 8.Отобразить информацию о самом старом телефоне\n" +
                    " 9.Отобразить информацию о самом свежем телефоне\n" +
                    " 10.Найти среднюю цену телефона\n" +
                    " 11.Отобразить пять самых дорогих телефонов\n" +
                    " 12.Отобразить пять самых дешевых телефонов\n" +
                    " 14.Отобразить три самых новых телефона\n" +
                    " 15.Отобразить статистику по количеству телефонов каждого производителя.\n" +
                    " 16.Отобразить статистику по количеству моделей телефонов\n" +
                    " 17.Отобразить статистику телефонов по годам\n" +
                    " 0 - выход\n");
                while (true)
                {
                    Console.Write(" Сделайте выбор: ");
                    try
                    {
                        choice = int.Parse(Console.ReadLine()!);
                        if (choice < 0 || choice > 17)
                        {
                            throw new Exception(" Некорректный выбор!");
                        }
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" Некорректный ввод!");
                        Console.ResetColor();
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ResetColor();
                    }
                }

                switch (choice)
                {
                    case 0:
                        return;

                    case 1:

                        break;
                    case 2:

                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:

                        break;
                    case 6:

                        break;
                    case 7:

                        break;
                    case 8:

                        break;
                    case 9:

                        break;
                    case 10:

                        break;
                    case 11:

                        break;
                    case 12:

                        break;
                    case 13:

                        break;
                    case 14:

                        break;
                    case 15:

                        break;
                    case 16:

                        break;
                    case 17:

                        break;
                }
                Console.WriteLine(" Для продолжения нажмите Enter!");
                Console.ReadLine();
                Console.Clear();

            }
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
            public void ShowPhones()
            {

            }
            public void ShowCount()
            {

            }
            public void ShowPhonesMore100()
            {

            }
            public void ShowPhonesRange()
            {

            }
            public void ShowCountConcreteManufacturer()
            {

            }
            public void ShowPhoneMinPrice()
            {

            }
            public void ShowPhoneMaxPrice()
            {

            }
            public void ShowPhoneOld()
            {

            }
            public void ShowPhoneNew()
            {

            }
            public void ShowAveragePrice()
            {

            }
            public void Show5Expensive()
            {

            }
            public void Show5Cheapest()
            {

            }
            public void Show3New()
            {

            }
            public void ShowStatisticsByQuantityManufacturer()
            {

            }
            public void ShowStatisticsByQuantityTitle()
            {

            }
            public void ShowStatisticsByDate()
            {

            }
        }
    }
}