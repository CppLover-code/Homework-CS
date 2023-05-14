using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace Ex._2
{
    internal class Program2
    {
        static void Main(string[] args)
        {
            Console.Title = "Журнал";
            FileStream? stream = null;
            DataContractJsonSerializer? jsonFormatter = null;

            Journal[] journals =
            {
                new Journal("Best car", " Издательство Новый журнал", 35, new DateTime(2022,5,10), new List<Article>
                {
                    new Article("Сколько лошадинных сил у Феррари", "О Феррари и новом движке", 580),
                    new Article("Женщина за рулем - беда на дороге", "Почему женщине нельзя доверять машину", 1325),                   
                    new Article("Тонкости работы карбюратора", "Как работают карбюраторы на Жиге", 930)
                }),               
                new Journal("New york Times", "Издательство Time", 25, new DateTime(2021,2,14), new List<Article>
                {
                    new Article("Повышение цен не за горами", "Почему растут цены на продукты в Нью Йорке", 896),
                    new Article("Выборы губернатора", "Кому отдали предпочтение жители города", 997)
                })
            };
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine(" ДО сериализации:");
            Console.WriteLine("-------------------------------------------");
            Console.ResetColor();

            foreach (var item in journals)
                item.Show();          
            /// СЕРИАЛИЗАЦИЯ ///
            stream = new FileStream("journals.json", FileMode.Create);
            jsonFormatter = new DataContractJsonSerializer(typeof(Journal[]));
            jsonFormatter.WriteObject(stream, journals);
            stream.Close();
            Console.WriteLine("Сериализация успешно выполнена!");

            /// ДЕСЕРИАЛИЗАЦИЯ //
            stream = new FileStream("journals.json", FileMode.Open);
            jsonFormatter = new DataContractJsonSerializer(typeof(Journal[]));
            journals = (Journal[])jsonFormatter.ReadObject(stream)!;         
            stream.Close();
            Console.WriteLine("Десериализация успешно выполнена!");

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine(" ПОСЛЕ десериализации:");
            Console.WriteLine("-------------------------------------------");
            Console.ResetColor();

            foreach (var item in journals!)
                item.Show();

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
            public List<Article>? Articles = null;

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

                Console.WriteLine(" Введите дату выпуска (гг.мм.дд):");
                Date = DateTime.Parse(Console.ReadLine()!);

                Console.Write(" Введите количество страниц: ");
                int Pages = Convert.ToInt32(Console.ReadLine());
                List<Article>? Articles = new List<Article>();

                Console.Write(" Введите количество статей: ");
                int count = Convert.ToInt32(Console.ReadLine());
                while (count != 0)
                {
                    Article article = new Article();
                    article.InputArticle();
                    Articles.Add(article);
                    count--;
                }
                Journal journal = new Journal(name!, producerName!, Pages, Date, Articles);
                return journal;
            }
            public void Show()
            {
                Console.WriteLine(this.ToString());
                Console.WriteLine("---------------------------------------");
                foreach (var item in Articles!)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.WriteLine("---------------------------------------");
                Console.ResetColor();

            }


            public override string ToString()
            {
                return $" Название журнала: {Title}\n" +
                       $" Название издательства: {Publishing}\n" +
                       $" Кол-во страниц: {Pages}\n" +
                       $" Дата выпуска: {Date.ToShortDateString()}\n";
            }
        }
        [Serializable]
        [DataContract]
        public class Article
        {
            [DataMember]
            public string? ArticleTitle { get; set; }
            [DataMember]
            public string? ArticleAnnouncement { get; set; }
            [DataMember]
            public int? Symbols;
            public Article() { }

            public Article(string? articleText, string? articleAnnouncement, int symb)
            {
                ArticleTitle = articleText;
                ArticleAnnouncement = articleAnnouncement;
                Symbols = symb;
            }
            public void InputArticle()
            {
                Console.WriteLine(" Введите название статьи:");
                ArticleTitle = Console.ReadLine();
                Console.WriteLine(" Введите анонс статьи: ");
                ArticleAnnouncement = Console.ReadLine();
                Console.WriteLine(" Введите количество символов статьи: ");
                Symbols = int.Parse(Console.ReadLine()!);
            }
            public override string ToString()
            {
                return $" Название статьи: {ArticleTitle}\n" +
                    $" Анонс: {ArticleAnnouncement}\n" +                   
                    $" Кол-во страниц: {Symbols}\n";
            }
        }
    }
}
