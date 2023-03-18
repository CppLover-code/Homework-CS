using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_3
{
    internal class Program3
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Filtration");
            Console.WriteLine("\n Original array");
            int[] arr = { 1, -3, 10, 6, -4, 5 };
            Print(arr);

            Console.WriteLine("\n Filter array");
            int[] fArr = { 10, 6, 1 };
            Print(fArr);

            Console.WriteLine("\n Result after filtering ");
            Print(Filter.Filtration(arr, fArr));
        }
        class Filter
        {
            public static int[] Filtration(int[] orig, int[] filtr)
            {
                
                int[] res = new int[20];
                int ind = 0;
                bool flag = false;

                for (int i = 0; i < orig.Length; i++)
                {
                    for (int k = 0; k < filtr.Length; k++)
                    {
                        if (orig[i] != filtr[k]) flag = true;
                        else
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag)
                    {
                        res[ind] = orig[i];
                        ind++;
                    }
                }

                for (int i = res.Length-1; i>=0 ; i--)
                {
                    if (res[i] == 0) Array.Resize(ref res, res.Length - 1);
                }
                return res;
            }
        }
        static void Print(int[] arr)
        {
            foreach (int i in arr)
                Console.Write(i + " ");
            Console.WriteLine();
        }
    }
}
