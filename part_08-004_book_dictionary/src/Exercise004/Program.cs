namespace Exercise004
{
    using System;
    using System.Collections.Generic;
    public class Program
    {
         public static void Main()
        {
            Dictionary<string, Book> books = new Dictionary<string, Book>();
            Book senseAndSensibility = new Book("Sense and Sensibility", 1811, "...");
            Book prideAndPrejudice = new Book("Pride and Prejudice", 1813, "....");
            books.Add(senseAndSensibility.name, senseAndSensibility);
            books.Add(prideAndPrejudice.name, prideAndPrejudice);

            PrintValues(books);
            Console.WriteLine("-- -- -- --");
            PrintValueIfNameContains(books, "prejud");
        }
        public static void PrintValues(Dictionary< string, Book > dictionary)
        {
            foreach(var book in dictionary.Values)
            {
                Console.WriteLine(book.ToString());
            }
        }

        public static void PrintValueIfNameContains(Dictionary< string, Book > dictionary, string text)
        {
            foreach(var book in dictionary.Values)
            {
                var value = book.name.ToLower();
                if(value.Contains(text))
                {
                    Console.WriteLine(book.ToString());
                }
            }
        }
       
    }
}