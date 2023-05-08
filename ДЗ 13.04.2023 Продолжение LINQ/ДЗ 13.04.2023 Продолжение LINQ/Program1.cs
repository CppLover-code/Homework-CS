using System.Numerics;

namespace ДЗ_13._04._2023_Продолжение_LINQ
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            Console.Title = "LINQ запросы для массива телефонов";
            var phones = new Phones(new Phone[]
                {
                    new Phone("Iphone 14", "Apple", 1500, new DateTime(2023, 1, 15)),
                    new Phone("Iphone XR", "Apple", 579, new DateTime(2018, 3, 10)),
                    new Phone("H13", "Nokia", 285, new DateTime(2018, 4, 10)),
                    new Phone("Redmi 10", "Xiaomi", 399, new DateTime(2021, 2, 14)),
                    new Phone("Iphone 14", "Apple", 1599, new DateTime(2020, 10, 25)),
                    new Phone("Samsung A8", "Samsung", 1200, new DateTime(2020,10,25)),
                    new Phone("Samsung A12", "Samsung", 55, new DateTime(2010,11,15)),
                    new Phone("Iphone 10", "Apple", 500, new DateTime(2020, 5, 15)),
                    new Phone("Samsung A10", "Samsung", 49, new DateTime(2008,8,13)),
                    new Phone("Nokia 5S", "Nokia", 89, new DateTime(2015,7,25)),
                    new Phone("Redmi 10", "Xiaomi", 600, new DateTime(2021, 2, 14)),
                    new Phone("Blade V40", "ZTE", 150, new DateTime(2020, 5, 15)),
                    new Phone("ThinkPhone 8", "Motorola", 99, new DateTime(2022, 5, 8))
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
                    " 13.Отобразить три самых старых телефона\n" +
                    " 14.Отобразить три самых новых телефона\n" +
                    " 15.Отобразить статистику по количеству телефонов каждого производителя\n" +
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
                        Console.WriteLine();
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
                        phones.ShowPhones();
                        break;
                    case 2:
                        phones.ShowCount();
                        break;
                    case 3:
                        phones.ShowPhonesMore100();
                        break;
                    case 4:
                        phones.ShowPhonesRange();
                        break;
                    case 5:
                        phones.ShowCountConcreteManufacturer();
                        break;
                    case 6:
                        phones.ShowPhoneMinPrice();
                        break;
                    case 7:
                        phones.ShowPhoneMaxPrice();
                        break;
                    case 8:
                        phones.ShowPhoneOld();
                        break;
                    case 9:
                        phones.ShowPhoneNew();
                        break;
                    case 10:
                        phones.ShowAveragePrice();
                        break;
                    case 11:
                        phones.Show5Expensive();
                        break;
                    case 12:
                        phones.Show5Cheapest();
                        break;
                    case 13:
                        phones.Show3Old();
                        break;
                    case 14:
                        phones.Show3New();
                        break;
                    case 15:
                        phones.ShowStatisticsByQuantityManufacturer();
                        break;
                    case 16:
                        phones.ShowStatisticsByQuantityTitle();
                        break;
                    case 17:
                        phones.ShowStatisticsByDate();
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(" Для продолжения нажмите Enter!");
                Console.ResetColor();
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
                return $"Название:\t{Title}\nПроизводитель:\t{Manufacturer}\nЦена:\t\t{Price}$\nДата выпуска:\t{Date.Year}.{Date.Month}.{Date.Day}\n";
            }
        }
        class Phones
        {
            public Phone[] phones;
            public Phones(Phone[] phones) => this.phones = phones;
            public void ShowPhones()
            {
                int counter = 1;
                foreach (Phone phone in phones)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\tТелефон #{counter}");
                    Console.ResetColor();
                    Console.WriteLine(phone);
                    counter++;
                }
            }
            public void ShowCount()
            {
                int count = phones.Count();
                Console.WriteLine($" Общее количество: всего {count} телефонов");
            }
            public void ShowPhonesMore100()
            {
                int count = phones.Count(i => i.Price > 100);
                Console.WriteLine($" Количество телефонов с ценой больше 100: всего {count} телефонов");
            }
            public void ShowPhonesRange()
            {
                int count = phones.Count(i => i.Price > 400 && i.Price < 700);
                Console.WriteLine($" Количество телефонов с ценой в диапазоне от 400 до 700: всего {count} телефонов");
            }
            public void ShowCountConcreteManufacturer()
            {
                Console.WriteLine(" Введите название производителя телефонов:");
                string s = Console.ReadLine()!;
                int count = phones.Count(i => i.Manufacturer!.ToLower().Contains(s.ToLower()));
                Console.WriteLine($" Количество телефонов конкретного производителя: всего {count} телефонов");
            }
            public void ShowPhoneMinPrice()
            {
                var min = phones.Min(i => i.Price);

                var phone = from item in phones
                            where item.Price == min
                            select item;

                Console.WriteLine($" Телефон с минимальной ценой\n");
                foreach( var item in phone ) Console.WriteLine(item);
            }
            public void ShowPhoneMaxPrice()
            {
                var max = phones.Max(i => i.Price);

                var phone = from item in phones
                            where item.Price == max
                            select item;

                Console.WriteLine($" Телефон с максимальной ценой\n");
                foreach (var item in phone) Console.WriteLine(item);
            }
            public void ShowPhoneOld()
            {
                var old = phones.Min(i => i.Date);

                var phone = from item in phones
                            where item.Date == old
                            select item;

                Console.WriteLine($" Самый старый телефон\n");
                foreach (var item in phone) Console.WriteLine(item);
            }
            public void ShowPhoneNew()
            {
                var newTel = phones.Max(i => i.Date);

                var phone = from item in phones
                            where item.Date == newTel
                            select item;

                Console.WriteLine($" Самый свежий телефон\n");
                foreach (var item in phone) Console.WriteLine(item);
            }
            public void ShowAveragePrice()
            {
                double aver = phones.Average(i => i.Price);
                Console.WriteLine($" Средняя цена телефона: всего {Math.Round(aver,2)}$");
            }
            public void Show5Expensive()
            {

                var result = phones.OrderByDescending(i => i.Price).Take(5);

                Console.WriteLine($" Пять самых дорогих телефонов\n");
                foreach (var item in result) Console.WriteLine(item);
            }
            public void Show5Cheapest()
            {
                var result = phones.OrderBy(i => i.Price).Take(5);

                Console.WriteLine($" Пять самых дешёвых телефонов\n");
                foreach (var item in result) Console.WriteLine(item);
            }
            public void Show3Old()
            {
                var result = phones.OrderBy(i => i.Date).Take(3);

                Console.WriteLine($" Три самых старых телефона\n");
                foreach (var item in result) Console.WriteLine(item);
            }
            public void Show3New()
            {
                var result = phones.OrderByDescending(i => i.Date).Take(3);

                Console.WriteLine($" Три самых новых телефона\n");
                foreach (var item in result) Console.WriteLine(item);
            }
            public void ShowStatisticsByQuantityManufacturer()
            {
                Console.WriteLine(" Статистика по количеству телефонов каждого производителя");

                var groups = phones.GroupBy(p => p.Manufacturer)
                        .Select(g => new { Name = g.Key, Count = g.Count() });
                foreach (var group in groups)
                    Console.WriteLine("{0,-15} - {1,5}", group.Name, group.Count);                
            }
            public void ShowStatisticsByQuantityTitle()
            {
                Console.WriteLine(" Статистика по количеству моделей телефонов");
                var groups = phones.GroupBy(p => p.Title)
                       .Select(g => new { Name = g.Key, Count = g.Count() });
                foreach (var group in groups)
                    Console.WriteLine("{0,-15} - {1,5}", group.Name, group.Count);
            }
            public void ShowStatisticsByDate()
            {
                Console.WriteLine(" Статистика телефонов по годам");
                var groups = phones.GroupBy(p => p.Date)
                      .Select(g => new { Date = g.Key, Count = g.Count() });
                foreach (var group in groups)
                    Console.WriteLine("{0,-20} - {1,5}", group.Date.ToLongDateString(), group.Count);
            }
        }
    }
}