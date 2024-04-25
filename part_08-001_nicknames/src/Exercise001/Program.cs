namespace Exercise001
{
    using System;
    using System.Collections.Generic;
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, string> my_dict = new Dictionary<string, string>();
            my_dict.Add("matthew", "matt");
            my_dict.Add("michael", "mix");
            my_dict.Add("arthur", "artie");
            // Print using foreach and KeyValuePair
            foreach(KeyValuePair<string, string> pair in my_dict)
            {
                Console.WriteLine(pair.Key + "\'s nickname is " + pair.Value);
            }
        }
    }
}