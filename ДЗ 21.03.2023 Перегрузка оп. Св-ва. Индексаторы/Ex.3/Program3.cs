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
            int count = 5;

            List list = new List(new Book[count]);
            int ind = -1;

            while (true)
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("\t\t\t-List of books to read-\n");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Menu ");
                Console.ResetColor();
                Console.WriteLine(" 1 - add book\n 2 - delete book");
                Console.WriteLine(" 3 - find a book in the list\n 4 - show list\n 0 - exit\n");

                Console.Write(" Make a choice: ");
                int choice =-1;  
                try
                {
                    try { choice = int.Parse(Console.ReadLine());}
                    catch { throw new FormatException(" Incorrect input!\n");}

                    if(choice < 0 || choice > 4)
                    throw new Exception(" Incorrect input!\n");
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                    Console.Clear();
                }

                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        ind++;
                        list[ind] = new Book();
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 2:
                        try { list.Delete(ref ind, list); }
                        catch (Exception ex) { Console.WriteLine(ex.Message); }
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 3:
                        list.Search(ind,list);
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case 4:
                        list.Show(ind,list);
                        Console.ReadLine();
                        Console.Clear();
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
            public Book() // было бы хорошо сделать проверки на вводимые данные
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

            public List()
            {
                books = null;
            }
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
                        throw new IndexOutOfRangeException(" Bounds Alert!"); // иначе генерируем исключение
                }
                set
                {
                    if (index >= 0 && books.Length > index)
                        books[index] = value;
                }
            }
            public string this[string index] // перегруженный индексатор
            {
                get
                {
                    foreach (var book in books)
                    {
                        if (book.Title == index) return book.Title;

                    }
                    throw new IndexOutOfRangeException(" Book not found!");
                }
            }
            public void Show(int ind, List list)
            {
                if (ind < 0)
                {
                    Console.WriteLine(" Your list is empty!\n");
                    return;
                }

                for (int i = 0; i < ind + 1; i++)
                {
                    Console.WriteLine($" -Book {i + 1}-");
                    list[i].Output();
                }
            }
            public void Search(int ind, List list)
            {
                if (ind < 0)
                {
                    Console.WriteLine(" Your list is empty!\n");
                    return;
                }

                Console.WriteLine(" Enter book title to search: ");
                string find = Console.ReadLine();
                int res = 0;
                for (int i = 0; i < ind + 1; i++)
                {
                    res = String.Compare(list[i].Title.ToString(), find);
                    if (res == 0)
                    {
                        Console.WriteLine($" The book -{list[find.ToString()]}- is in the list, serial number {i + 1}\n");
                        break;
                    }
                }

                if (res != 0) Console.WriteLine(" This book is not on your list!\n");
            }
            public void Delete(ref int ind, List list)
            {
                if (ind < 0)  // если список пуст, возврат в меню
                {
                    Console.WriteLine(" Your list is empty!\n");
                    return;
                }
                Console.WriteLine(" Select the book you wish to delete: ");
                int v;

                for (int i = 0; i < ind + 1; i++)
                {
                    Console.WriteLine($"{i + 1}. {list[i].Title}");
                }

                v = int.Parse(Console.ReadLine());
                for (int i = 0; i < ind + 1; i++)
                {
                    if (i == v - 1 && v - 1 != ind)
                    {
                        list[i].Title = list[i + 1].Title.ToString();
                        list[i].Author = list[i + 1].Author.ToString();
                        list[i].Year = Convert.ToInt32(list[i + 1].Year.ToString());
                        ind--;
                        Console.WriteLine(" Book deleted successfully!\n ");
                        return;
                    }
                    else if (i == v - 1 && v - 1 == ind)
                    {
                        ind--;
                        Console.WriteLine(" Book deleted successfully!\n ");
                        return;
                    }
                }
                throw new Exception(" Wrong choice!\n");
            }
        }     
    }
}