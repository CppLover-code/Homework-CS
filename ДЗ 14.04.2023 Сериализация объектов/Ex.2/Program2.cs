using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Ex._2
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Console.Title = "Журнал";

            Journal[] journals =
            {
                new Journal("Best car", " Издательство Новый журнал", 35, new DateTime(2022,5,10), new List<Article>
                {
                    new Article("A...", "A"),
                    new Article("B...", "B"),
                    new Article("C...", "C"),
                    new Article("D...", "D")
                }),
                new Journal("Wall street journal", "Издательство WallStreet", 40, new DateTime(2023,11,25), new List<Article>
                {
                    new Article("A...", "A"),
                    new Article("B...", "B"),
                    new Article("C...", "C"),
                    new Article("D...", "D")
                }),
                new Journal("New york Times", "Издательство Time", 25, new DateTime(2021,2,14), new List<Article>
                {
                    new Article("A...", "A"),
                    new Article("B...", "B"),
                    new Article("C...", "C"),
                    new Article("D...", "D")
                })
            };
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Before serialization:");
            Console.ResetColor();
            foreach (var item in journals)
                item.ShowAll();
            Console.WriteLine("-------------------------------------------");

            FileStream stream = new FileStream("journals.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer serializer = new XmlSerializer(typeof(Journal[]));
            if (stream.CanWrite)
            {
                serializer.Serialize(stream, journals);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Serialization successfully");
                stream.Close();
                stream.Dispose();
                Console.WriteLine("-------------------------------------------");
                Console.ResetColor();
            }

            stream = new FileStream("journals.xml", FileMode.Open, FileAccess.Read);
            if (stream.CanRead)
            {
                journals = (Journal[])serializer.Deserialize(stream);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Deserialization succesfully");
                stream.Close();
                stream.Dispose();
                Console.WriteLine("-------------------------------------------");
                Console.ResetColor();
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("After deserialization:");
            Console.ResetColor();
            foreach (var item in journals)
                item.ShowAll();

        }



        [Serializable]
        [DataContract]
        public class Journal
        {
            [DataMember]
            public string? Title { get; set; }
            [DataMember]
            public string? Publishing { get; set; }
            [DataMember]
            public DateTime Date;
            [DataMember]
            public int? Pages { get; set; }
            [DataMember]
            public List<Article> Articles;

            public Journal() { }
            public Journal(string name, string productName, int numberOfPages, DateTime dateOfIssue, List<Article> articles)
            {
                Title = name;
                Publishing = productName;
                Pages = numberOfPages;
                Date = dateOfIssue;
                Articles = articles;
            }
            public Journal InputInfo()
            {
                Console.WriteLine(" Введите название журнала:");
                string? name = Console.ReadLine();

                Console.Write(" Введите название издательства:");
                string? producerName = Console.ReadLine();

                Console.WriteLine(" Введите дату выпуска:");
                int day;
                int month;
                int year;
                Console.Write(" День: ");
                day = Convert.ToInt32(Console.ReadLine());
                Console.Write(" Месяц: ");
                month = Convert.ToInt32(Console.ReadLine());
                Console.Write(" Год: ");
                year = Convert.ToInt32(Console.ReadLine());
                DateTime Date = new DateTime(year, month, day);

                Console.Write(" Введите количество страниц: ");
                int Pages = Convert.ToInt32(Console.ReadLine());
                List<Article>? Articles = new List<Article>();

                Console.Write(" Введите количество статей: ");
                int count = Convert.ToInt32(Console.ReadLine());
                while (count != 0)
                {
                    Article article = new Article();
                    article.InputArticleData();
                    Articles.Add(article);
                    count--;
                }
                Journal journal = new Journal(name!, producerName!, Pages, Date, Articles);
                return journal;
            }
            public void ShowAll()
            {
                Console.WriteLine(this.ToString());
                Console.WriteLine("---------------------------------------");
                foreach (var item in Articles)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.WriteLine("---------------------------------------");
                Console.ResetColor();

            }


            public override string ToString()
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                return $"Name of journal: {Title}\n" +
                       $"Name of producer: {Publishing}\n" +
                       $"Number of pages: {Pages}\n" +
                       $"Date of issue: {Date.ToShortDateString()}\n" +
                       $"*************************************";
            }
        }
        [Serializable]
        [DataContract]
        public class Article
        {
            [DataMember]
            public string? ArticleText { get; set; }
            [DataMember]
            public string? ArticleAnnouncement { get; set; }
            [DataMember]
            public int? SymbolsAmount;

            public Article() { }

            public Article(string? articleText, string? articleAnnouncement)
            {
                ArticleText = articleText;
                ArticleAnnouncement = articleAnnouncement;
                SymbolsAmount = articleText?.Length;
            }
            public void InputArticleData()
            {
                Console.WriteLine("Enter article announcement: ");
                ArticleAnnouncement = Console.ReadLine();
                Console.WriteLine("Enter full article:");
                ArticleText = Console.ReadLine();
                SymbolsAmount = ArticleText?.Length;
            }
            public override string ToString()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                return $"#########################################\n" +
                    $"Article announcement: {ArticleAnnouncement}\n" +
                    $"Article text\n{ArticleText}\n" +
                    $"Amount of symbols in article: {SymbolsAmount}\n";

            }
        }
    }
}
