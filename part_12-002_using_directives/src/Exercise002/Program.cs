namespace Exercise002
{
    
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Linq;

    public class Program
    {
        // DO NOT TOUCH THE CODE BELOW
        public static void Main(string[] args)
        {

            List<int> integerList = new List<int>();
            List<string> stringList = new List<string>();

            string str = "This needs a using!";
            string another = "This does not need using!";
            stringList.Add(str);
            stringList.Add(another);

            Regex rgx = new Regex("needs");

            foreach (string sentence in stringList)
            {
                if (rgx.IsMatch(sentence))
                {
                    Console.WriteLine(sentence);
                }
            }

            Random rnd = new Random();
            for (int i = 0; i < 1000; i++)
            {
                integerList.Add(rnd.Next(1, 10001));
            }
            // See the API for Linq
            int largest = integerList.Max();
            int smallest = integerList.Min();
            Console.WriteLine(largest);
            Console.WriteLine(smallest);
        }
    }
}