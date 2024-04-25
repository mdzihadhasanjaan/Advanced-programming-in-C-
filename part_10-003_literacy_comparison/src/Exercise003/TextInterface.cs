

namespace Exercise003
{
    using System;
    using System.Collections.Generic;
    public class TextInterface
    {
        public List<Book> books;
        public TextInterface()
        {
            books = new List<Book>();
        }

        public void Start()
        {
            Readbooks();
            Printbooks();
        }
        public void Readbooks()
        {
            while (true)
            {
                Console.WriteLine("Input the name of the book, empty stops:");
                string name = Console.ReadLine();

                if(name == "")
                {
                    break;
                }

                Console.WriteLine("Input the age recommendation:");
                int ageRecommendation = int.Parse(Console.ReadLine());
                books.Add(new Book(name, ageRecommendation));
            }

            books.Sort();
        }

        public void Printbooks()
        {
            Console.WriteLine($"{books.Count} books in total.\nBooks:");
            foreach(Book book in books)
            {
                Console.WriteLine(book.ToString());
            }
        }
    }
}

