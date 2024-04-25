namespace Exercise008
{
    using System;

    public class DictionaryOfManyTranslations
    {
        public Dictionary<string, List<string>> dict;
        public DictionaryOfManyTranslations()
        {
            dict = new Dictionary<string, List<string>>();
        }
        public void Add(string word, string translation)
        {
            if(!dict.ContainsKey(word))
            {
                dict[word] = new List<string>();
            }

            dict[word].Add(translation);
        }

        public List<string> Translate(string word)
        {
            if(dict.ContainsKey(word))
            {
                return dict[word];
            }

            return new List<string>();
        }

        public void Remove(string word)
        {
            dict.Remove(word);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            DictionaryOfManyTranslations dictionary = new DictionaryOfManyTranslations();
            dictionary.Add("lie", "maata");
            dictionary.Add("lie", "valehdella");

            dictionary.Add("bow", "jousi");
            dictionary.Add("bow", "kumartaa");

            foreach (string translation in dictionary.Translate("bow"))
            {
                Console.WriteLine(translation);
            }
            Console.WriteLine();

            foreach (string translation in dictionary.Translate("lie"))
            {
                Console.WriteLine(translation);
            }

            dictionary.Remove("bow");
            foreach (string translation in dictionary.Translate("bow"))
            {
                Console.WriteLine(translation);
            }
        }
    }
}