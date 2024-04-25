namespace Exercise003
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            Dictionary<string, string> my_dict = new Dictionary<string, string>();
            my_dict.Add("f.e", "for example");
            my_dict.Add("etc.", "and so on");
            my_dict.Add("i.e", "more precisely");

            PrintKeys(my_dict);
            Console.WriteLine("---");
            PrintKeysWhere(my_dict, "i");
            Console.WriteLine("---");
            PrintValuesOfKeysWhere(my_dict, ".e");
        }
        public static void PrintKeys(Dictionary<string, string> dict)
        {
            foreach (var key in dict.Keys)
            {
                Console.WriteLine(key);
            }
        }

        public static void PrintKeysWhere(Dictionary<string, string> dict, string text)
        {
            foreach (var key in dict.Keys)
            {
                if (key.Contains(text))
                {
                    Console.WriteLine(key);
                }
            }
        }

        public static void PrintValuesOfKeysWhere(Dictionary<string, string> dict, string text)
        {
            foreach (var value in dict)
            {
                if (value.Key.Contains(text))
                {
                    Console.WriteLine(value.Value);
                }
            }
        }  
    }
}