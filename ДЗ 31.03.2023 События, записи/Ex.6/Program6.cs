using System.Linq;
using System.Text;
namespace Ex._6
{

    internal class Program6
    {
        delegate string Find(string txt, string w);
        static Find wrd = (txt, w) =>                          // лямбда выражение
        {           
            if (txt.ToUpper().Contains(w.Trim(' ').ToUpper())) // убираем ненужные случайно введенные пробелы в слове и проверяем 
            {                                                  // содержит ли текст слово независимо от регистра
                Console.ForegroundColor = ConsoleColor.Green;
                return "the word was found!";
            }                
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return "word was not found!";
            }             
        };

        static void Main(string[] args)
        {
            Console.WriteLine("\t\t-Using a lambda expression to find a word in text-");
            Console.WriteLine(" Enter text:");
            string text = CheckStr();

            Console.WriteLine(" Enter a search word: ");
            string word = CheckStr();

            Console.WriteLine(" Result: " + wrd(text, word));
            Console.ResetColor();   
        }
        static string CheckStr() // метод для проверки введенных данных
        {
            string str; 
               
            while (true)
            {
                try
                {
                    str = Console.ReadLine()!;              
                    if(String.IsNullOrWhiteSpace(str))              // если введенные данные являются пустыми или пробелом,
                    {
                        throw new Exception(" Incorrect input!");   // то бросаем исключение
                    }
                    break;
                }
                catch(Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message);
                    Console.ResetColor();
                }
            }                
            return str;                                            // возврат введенных данных после проверки
        }
    }
}