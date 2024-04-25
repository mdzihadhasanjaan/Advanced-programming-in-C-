namespace Exercise005
{
    using System;

    public class SaveableDictionary
    {
        public Dictionary<string, string> dict;
        public string fileName;
        public SaveableDictionary()
        {
            dict = new Dictionary<string, string>();
        }

        public SaveableDictionary(string file)
        {
            dict = new Dictionary<string, string>();
            fileName = file;
        }

        public void Add(string words, string translation)
        {
            if (!dict.ContainsKey(words))
            {
                dict.Add(words, translation);
            }
        }

        public string Translate(string word)
        {
            string key = "";
            string value = "";

            foreach (KeyValuePair<string, string> pair in dict)
            {
                if (pair.Key.Contains(word))
                {
                    value = pair.Value;
                    key = pair.Key;
                    break;
                }
                else if (pair.Value.Contains(word))
                {
                    key = pair.Key;
                    value = pair.Value;
                    break;
                }
            }

            if (value == word)
            {
                return key;
            }
            else if (key == word)
            {
                return value;
            }
            else
            {
                return null;
            }
        }

        public void Delete(string word)
        {
            foreach (var key in dict.Keys)
            {
                if (key.Contains(word))
                {
                    dict.Remove(key);
                }
                foreach (var value in dict.Values)
                {
                    if (value.Contains(word))
                    {
                        dict.Remove(key);
                    }
                }
            }
        }

        public bool Load()
        {
            try
            {
                string[] lines = File.ReadAllLines(fileName);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(":");
                    string word = parts[0].Trim();
                    string translation = parts[1].Trim();

                    Add(word, translation);
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error loading dictionary from file: {e.Message}");
                return false;
            }
        }

        public bool Save()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (var entry in dict)
                    {
                        writer.WriteLine($"{entry.Key}:{entry.Value}");
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error saving dictionary to file: {e.Message}");
                return false;
            }
        }
    }


    public class Program
    {
        public static void Main(string[] args)
        {
            SaveableDictionary dictionary = new SaveableDictionary("words.txt");
            dictionary.Load();

            // Translate all the words in the file both ways
            Console.WriteLine(dictionary.Translate("apina"));
            Console.WriteLine(dictionary.Translate("monkey"));
            Console.WriteLine(dictionary.Translate("beer"));
            Console.WriteLine(dictionary.Translate("olut"));
            Console.WriteLine(dictionary.Translate("below"));
            Console.WriteLine(dictionary.Translate("alla oleva"));

            // Try adding, translating and removing a word, this should not affect the file
            dictionary.Add("poista", "remove");
            Console.WriteLine(dictionary.Translate("remove"));
            dictionary.Delete("remove");

            // Save the file
            dictionary.Save();
        }

    }
}