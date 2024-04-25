namespace Exercise002
{
    using System;

     public class Abbreviations
    {
        private Dictionary<string, string> abb_dict = new Dictionary<string, string>();
        
        public void AddAbbreviation(string abbreviation, string explanation)
        {
            abb_dict.Add(abbreviation, explanation);
        }

        public bool HasAbbreviation(string abbreviation)
        {
            return abb_dict.ContainsKey(abbreviation);
        }

        public string FindExplanationFor(string abbreviation)
        {
            if(!HasAbbreviation(abbreviation))
            {
                return "not found";
                
            }
            return abb_dict[abbreviation];
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
       
            Abbreviations abbreviations = new Abbreviations();
            abbreviations.AddAbbreviation("e.g", "for example");
            abbreviations.AddAbbreviation("etc.", "and so on");
            abbreviations.AddAbbreviation("i.e", "more precisely");


            string text = "e.g i.e etc. lol";

            foreach (string part in text.Split(" "))
            {
                Console.WriteLine(abbreviations.FindExplanationFor(part));
            }
        
        }
    }
}