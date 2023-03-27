namespace ДЗ_24._03._2023_Интерфейсы
{
    internal class Program1
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                Array a = new();
                a.Show();
                a.Show(" Array with param");
            }
        }
        interface IOutput
        {
            void Show();
            void Show(string info);
        }
        interface IOutput2
        {
            void ShowEven();
            void ShowOdd();
        }
        interface ICalc
        {
            int Less(int valueToCompare);
            int Greater(int valueToCompare);
        }
        interface ICalc2
        {
            int CountDistinct();
            int EqualToValue(int valueToCompare);
        }

        class Array : IOutput, IOutput2, ICalc, ICalc2
        {
            public int[] ar;

            public Array()
            {
                ar = new int[5];
                Random random = new Random();
                for (int i = 0; i < ar.Length; i++)
                {
                    ar[i] = random.Next(1, 10);
                }
            }
            public void Show()
            {
                Console.WriteLine(" Array");
                foreach (int i in ar)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
            public void Show(string info)
            {
                Console.WriteLine(info);
                foreach (int i in ar)
                {
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }

            ///////////////////////
            public void ShowEven()
            {

            }
            public void ShowOdd()
            {

            }

            ///////////////////////
            public int Less(int valueToCompare)
            {
                return 1;
            }
            public int Greater(int valueToCompare)
            {  
                return 1; 
            }

            ///////////////////////
            public int CountDistinct()
            {
                return 1;
            }
            public int EqualToValue(int valueToCompare)
            {
                return 1;
            }
        }
    }
}