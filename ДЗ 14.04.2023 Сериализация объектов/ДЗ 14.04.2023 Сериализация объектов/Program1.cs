using System.Xml.Serialization;

namespace ДЗ_14._04._2023_Сериализация_объектов
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            Console.Title = "Массив дробей";

            Console.WriteLine("Создание массива дробей");
            int size;
            
            while (true)
            {
                Console.WriteLine("Введите размер массива:");
                try
                {
                    size = Convert.ToInt32(Console.ReadLine());
                    if (size < 1)
                        throw new Exception(" Размер массива должен быть больше нуля!");
                    break;
                }
                catch (FormatException)
                {
                    Console.WriteLine(" Некорректный ввод!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            

            double[] arr = new double[size];

            for (int i = 0; i < size; i++)
            {
                while(true)
                {
                    Console.Write($" Введите {i + 1} элемент: ");
                    try
                    {
                        arr[i] = Double.Parse(Console.ReadLine()!);
                        break;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine(" Некорректный ввод!");
                    }
                }
            }
            Console.WriteLine("--------------------------------------------");

            Console.WriteLine("Entered array:");
            foreach (var item in arr)
                Console.Write(item + "  ");

            Console.WriteLine("\n--------------------------------------------");

            FileStream stream = new FileStream("text.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer serializer = new XmlSerializer(typeof(double[]));

            serializer.Serialize(stream, arr);
            if (stream.CanWrite)
                Console.WriteLine("Array has been serialised succesfully)))");
            stream.Close();
            Console.WriteLine("--------------------------------------------");

            stream = new FileStream("text.xml", FileMode.Open, FileAccess.Read);
            if (stream.CanRead)
            {
                arr = (double[])serializer.Deserialize(stream);
                Console.WriteLine("Deserialize successfully");
                Console.WriteLine("--------------------------------------------");
            }

            stream.Close();
            stream.Dispose();

            Console.WriteLine("Array after deserialization:");
            foreach (var item in arr)
                Console.Write(item + "  ");
        }
    }
    }
}