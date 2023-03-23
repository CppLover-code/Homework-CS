using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex._3
{
    internal class Program3
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" List of books to read\n");
            int count = 5;
            List list = new List(new Book[count]);
            int ind = 0;

            while(true)
            {
                Console.WriteLine(" Menu ");
                Console.WriteLine(" 1 - add book\n 2 - delete book");
                Console.WriteLine(" 3 - find a book in the list\n 4 - show list\n 0 - exit\n");
                Console.Write(" Make a choice: ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        list[ind] = new Book(1);
                        ind++;
                        break;

                    case 2:
                        Console.WriteLine(" Select the book you wish to delete: ");
                        int v;

                        for (int i = 0; i < ind; i++)
                        {
                            Console.WriteLine($"{i + 1}. {list[i].Title}");
                        }

                        v = int.Parse(Console.ReadLine());
                        for (int i = 0; i < ind; i++)
                        {
                            if(i == v - 1)
                            {
                                list[i].Title = list[i + 1].Title.ToString();
                                list[i].Author = list[i + 1].Author.ToString();
                                list[i].Year = Convert.ToInt32(list[i + 1].Year.ToString());
                                break;
                            }                                                                                                                          
                        }                       
                        ind--;

                        Console.WriteLine(" Book deleted successfully!\n ");
                        break;

                    case 3:
                        break;

                    case 4:

                        for (int i = 0; i < ind; i++)
                        {
                            Console.WriteLine($" -Book {i + 1}-");
                            list[i].Output();
                            //Console.WriteLine($"Book {i + 1} \n {list[i].Title}\n {list[i].Author}\n {list[i].Year}\n");
                        }
                        break;

                    case 0:
                        return;        
                }
            }
        }
        class Book
        {
            private string title;   // название книги
            private string author;  // автор книги
            private int year;       // год 

            public string Title
            {
                get { return title; }
                set { title = value; }
            }
            public string Author
            {
                get { return author; }
                set { author = value; }
            }
            public int Year
            {
                get { return year; }
                set { year = value; }
            }
            public Book()
            {
                title = null;      
                author = null;                
                year = 0;
            }
            public Book(int b)
            {
                Console.WriteLine(" Enter book title: ");
                title = Console.ReadLine();
                Console.WriteLine(" Enter the author's first and last name: ");
                author = Console.ReadLine();
                Console.WriteLine(" Enter the year of publication of the book: ");
                year = int.Parse(Console.ReadLine());
            }
            public void Output()
            {
                Console.WriteLine(" Book title: " + title);
                Console.WriteLine(" Author: " +  author);
                Console.WriteLine(" Year of publication: " + year + "\n"); 
            }
        }
        class List
        {
            Book [] books;

            public List(Book[] b)
            {
                books = b;
            }
            public Book this[int index]
            {
                get
                {
                    if (index >= 0 && books.Length > index)
                        return books[index]; // то возвращаем объект Book по индексу
                    else
                        throw new IndexOutOfRangeException("Bounds Alert!!!"); // иначе генерируем исключение
                }
                set
                {
                    if (index >= 0 && books.Length > index)
                        books[index] = value;
                }
            }
            public Book this[string index] // перегруженный индексатор
            {
                get
                {
                    foreach (var book in books)
                    {
                        if (book.Title == index) return book;

                    }
                    throw new IndexOutOfRangeException(" Not found ");
                }                
            }
        }
    }
}
