using System.Text;
namespace Ex._6
{

    internal class Program6
    {
        delegate string Find(string txt, StringBuilder w );
        static Find wrd = (txt, w) =>
        {
            if (txt.Contains(w.ToString()))
                return "the word was found!";
            else
                return "word was not found!";
        };

        // поиск слова должен учитывать пробел с двух сторон, иначе ищет одну букву в целом слове

        static void Main(string[] args)
        {
            Console.WriteLine("\t\t-Using a lambda expression to find a word in text-");
            Console.WriteLine(" Enter text:");
            // сделать проверку введенного текста
            string text = Console.ReadLine()!;
            Console.WriteLine(" Enter a search word: ");
            // сделать проверку введенного слова
            StringBuilder word = new (Console.ReadLine()!); // f может и не нужен тут стринг билдер

            word[1] = word[0];
            Console.WriteLine(" Result: " + wrd(text, word));
        }
    }
}