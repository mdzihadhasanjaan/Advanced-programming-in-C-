namespace Exercise002
{
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            Student first = new Student("jamo");
            Student second = new Student("jamo1");

            // Should print -1
            Console.WriteLine(first.CompareTo(second));
        }
    }
}


