namespace Ex._2
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Management management = new Management(new Employee("Иванов Иван"), "vanya95", "In3R5_qw");
            management.Add(new Employee("Петров Петр"), "petya97", "Otr390_t_");
            management.Add(new Employee("Семенов Семен"), "semen90", "_Ui48y0_qe");
            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("\t\t\tАнгло-русский словарь");
                Console.WriteLine(" Меню операций");
                Console.WriteLine(" 1 - Показать базу данных\n 2 - Добавление логина и пароля\n" +
                    " 3 - Удаление логина\n 4 - Изменение логина и пароля\n" +
                    " 5 - Получение информации о пароле\n 0 - Выход\n");

                Console.Write(" Сделайте выбор: ");
                int choice = -1;
                try
                {
                    try { choice = int.Parse(Console.ReadLine()!); }
                    catch { throw new FormatException(" Некорректный ввод!\n"); }

                    if (choice < 0 || choice > 5)
                        throw new Exception(" Некорректный ввод!\n");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                    Console.Clear();
                }

                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        management.Output();
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 2:
                        management.Add();
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 3:
                        management.Delete();
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 4:
                        management.Change();
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 5:
                        management.PasInfo();
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 0:
                        return;
                }
            }
        }
    }
}