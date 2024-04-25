namespace ProgramTests
{
    using System;
    using System.IO;
    using Xunit;
    using Exercise005;
    using TestMyCode.CSharp.API.Attributes;
    public partial class ProgramTest
    {
        [Fact]
        [Points("11-5.1")]
        public void Section1ExampleShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                // Save a reference to the standard output.
                TextWriter stdout = Console.Out;

                // Redirect standard output to variable.
                Console.SetOut(sw);
                SaveableDictionary dictionary = new SaveableDictionary();
                dictionary.Add("apina", "monkey");
                dictionary.Add("banaani", "banana");
                dictionary.Add("apina", "apfe");

                Console.WriteLine(dictionary.Translate("apina"));
                Console.WriteLine(dictionary.Translate("monkey"));
                Console.WriteLine(dictionary.Translate("ohjelmointi"));
                Console.WriteLine(dictionary.Translate("banana"));
                Console.SetOut(stdout);
                string comparison = "monkey\napina\n\nbanaani\n";
                Assert.Equal(comparison, sw.ToString());
            }
        }

        [Fact]
        [Points("11-5.1")]
        public void SectionOneSimpleTranslateShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                // Save a reference to the standard output.
                TextWriter stdout = Console.Out;

                // Redirect standard output to variable.
                Console.SetOut(sw);
                SaveableDictionary dictionary = new SaveableDictionary();

                dictionary.Add("apina", "el mono");

                Console.WriteLine(dictionary.Translate("apina"));
                Console.WriteLine(dictionary.Translate("el mono"));
                Console.SetOut(stdout);
                string comparison = "el mono\napina\n";
                Assert.Equal(comparison, sw.ToString());
            }
        }

        [Fact]
        [Points("11-5.2")]
        public void Section2ExampleShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                // Save a reference to the standard output.
                TextWriter stdout = Console.Out;

                // Redirect standard output to variable.
                Console.SetOut(sw);
                SaveableDictionary dictionary = new SaveableDictionary();
                dictionary.Add("apina", "monkey");
                dictionary.Add("banaani", "banana");
                dictionary.Add("apina", "apfe");
                dictionary.Add("ohjelmointi", "programming");
                dictionary.Delete("apina");
                dictionary.Delete("banana");
                Console.WriteLine(dictionary.Translate("apina"));
                Console.WriteLine(dictionary.Translate("monkey"));
                Console.WriteLine(dictionary.Translate("banana"));
                Console.WriteLine(dictionary.Translate("banaani"));
                Console.WriteLine(dictionary.Translate("ohjelmointi"));
                Console.SetOut(stdout);
                string comparison = "\n\n\n\nprogramming\n";
                Assert.Equal(comparison, sw.ToString());
            }
        }

        [Fact]
        [Points("11-5.2")]
        public void SectionTwoSimpleAddAndDeleteShouldWork()
        {
            SaveableDictionary dictionary = new SaveableDictionary();
            dictionary.Add("apina", "ahv");
            dictionary.Add("banaani", "banaan");
            dictionary.Delete("ahv");
            dictionary.Delete("banaani");
            Assert.Null(dictionary.Translate("apina"));
            Assert.Null(dictionary.Translate("banaan"));

        }

        [Fact]
        [Points("11-5.3")]
        public void Section3ExampleShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                // Save a reference to the standard output.
                TextWriter stdout = Console.Out;
                // Redirect standard output to variable.
                Console.SetOut(sw);
                SaveableDictionary dictionary = new SaveableDictionary("words.txt");
                bool wasSuccessful = dictionary.Load();
                if (wasSuccessful)
                {
                    Console.WriteLine("Successfully loaded the dictionary from file");
                }
                Console.WriteLine(dictionary.Translate("apina"));
                Console.WriteLine(dictionary.Translate("ohjelmointi"));
                Console.WriteLine(dictionary.Translate("alla oleva"));
                Console.SetOut(stdout);
                string comparison = "Successfully loaded the dictionary from file\nmonkey\n\nbelow\n";
                Assert.Equal(comparison, sw.ToString());
            }
        }

        [Fact]
        [Points("11-5.3")]
        public void SectionThreeOtherTranslationsShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                // Save a reference to the standard output.
                TextWriter stdout = Console.Out;
                // Redirect standard output to variable.
                Console.SetOut(sw);
                SaveableDictionary dictionary = new SaveableDictionary("words.txt");
                bool wasSuccessful = dictionary.Load();
                if (wasSuccessful)
                {
                    Console.WriteLine("Successfully loaded the dictionary from file");
                }
                dictionary.Add("banaani", "banana");
                Console.WriteLine(dictionary.Translate("banana"));
                Console.WriteLine(dictionary.Translate("apina"));
                Console.WriteLine(dictionary.Translate("alla oleva"));
                Console.SetOut(stdout);
                string comparison = "Successfully loaded the dictionary from file\nbanaani\nmonkey\nbelow\n";
                Assert.Equal(comparison, sw.ToString());
            }
        }

        [Fact]
        [Points("11-5.4")]
        public void Section4and5ExampleShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                // Save a reference to the standard output.
                TextWriter stdout = Console.Out;
                // Redirect standard output to variable.
                Console.SetOut(sw);
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
                Console.SetOut(stdout);
                string comparison = "monkey\napina\nolut\nbeer\nalla oleva\nbelow\npoista\n";
                Assert.Equal(comparison, sw.ToString());
            }
        }

        [Fact]
        [Points("11-5.4")]
        public void SectionFourReturnsShouldWork()
        {

            SaveableDictionary dictionary = new SaveableDictionary("words.txt");
            dictionary.Load();
            // Translate all the words in the file both ways
            Assert.Equal("monkey", dictionary.Translate("apina"));
            Assert.Equal("apina", dictionary.Translate("monkey"));
            Assert.Equal("beer", dictionary.Translate("olut"));
            Assert.Equal("olut", dictionary.Translate("beer"));
            Assert.Equal("below", dictionary.Translate("alla oleva"));
            Assert.Equal("alla oleva", dictionary.Translate("below"));

            // Try adding, translating and removing a word, this should not affect the file
            dictionary.Add("poista", "remove");
            Assert.Equal("poista", dictionary.Translate("remove"));
            dictionary.Delete("remove");
            Assert.Null(dictionary.Translate("remove"));
        }

        [Fact]
        [Points("11-5.5")]
        public void SavingToFileShouldWork()
        {
            string fileName = "hiddenfile.txt";
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            File.CreateText(fileName).Close();
            SaveableDictionary dictionary = new SaveableDictionary(fileName);
            dictionary.Load();
            // Translate all the words in the file both ways
            dictionary.Add("apina", "monkey");
            dictionary.Add("banaani", "banana");
            dictionary.Add("apina", "apfe");
            dictionary.Add("ohjelmointi", "programming");
            dictionary.Save();
            string code = File.ReadAllText(fileName).Replace("\r\n", "\n");
            string content = "apina:monkey\nbanaani:banana\nohjelmointi:programming\n";
            File.Delete(fileName);
            Assert.Equal(content, code);
        }

        [Fact]
        [Points("11-5.5")]
        public void SavingToFileOtherWordsShouldWork()
        {
            string fileName = "hiddenfile.txt";
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            File.CreateText(fileName).Close();
            SaveableDictionary dictionary = new SaveableDictionary(fileName);
            dictionary.Load();
            // Translate all the words in the file both ways
            dictionary.Add("peruna", "potato");
            dictionary.Add("tomato", "tomaatti");
            dictionary.Add("apina", "apfe");
            dictionary.Save();
            string code = File.ReadAllText(fileName).Replace("\r\n", "\n");
            string content = "peruna:potato\ntomato:tomaatti\napina:apfe\n";
            File.Delete(fileName);
            Assert.Equal(content, code);
        }
    }
}
