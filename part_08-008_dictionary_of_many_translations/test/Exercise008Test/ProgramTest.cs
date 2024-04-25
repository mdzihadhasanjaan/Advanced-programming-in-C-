namespace ProgramTests
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using Xunit;
    using Exercise008;
    using TestMyCode.CSharp.API.Attributes;
    [Points("8-8")]
    public partial class ProgramTest
    {
        [Fact]
        public void ExampleShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                DictionaryOfManyTranslations dictionary = new DictionaryOfManyTranslations();
                dictionary.Add("lie", "maata");
                dictionary.Add("lie", "valehdella");

                dictionary.Add("bow", "jousi");
                dictionary.Add("bow", "kumartaa");

                foreach (string translation in dictionary.Translate("bow"))
                {
                    Console.WriteLine(translation);
                }

                foreach (string translation in dictionary.Translate("lie"))
                {
                    Console.WriteLine(translation);
                }

                dictionary.Remove("bow");
                foreach (string translation in dictionary.Translate("bow"))
                {
                    Console.WriteLine(translation);
                }

                Console.SetOut(stdout);
                string example = "jousi\nkumartaa\nmaata\nvalehdella\n";
                Assert.Equal(example, sw.ToString());
            }
        }

        [Fact]
        public void FinnishShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                DictionaryOfManyTranslations dictionary = new DictionaryOfManyTranslations();
                dictionary.Add("kuusi", "six");
                dictionary.Add("kuusi", "your birch");
                dictionary.Add("kuusi", "your moon");

                foreach (string translation in dictionary.Translate("kuusi"))
                {
                    Console.WriteLine(translation);
                }
                Console.SetOut(stdout);
                string example = "six\nyour birch\nyour moon\n";
                Assert.Equal(example, sw.ToString());
            }
        }

        [Fact]
        public void ArbitaryTranslationShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                DictionaryOfManyTranslations dictionary = new DictionaryOfManyTranslations();
                dictionary.Add("asd", "dsa");
                dictionary.Add("asd", "sad");
                dictionary.Add("asd", "das");

                foreach (string translation in dictionary.Translate("asd"))
                {
                    Console.WriteLine(translation);
                }
                Console.SetOut(stdout);
                string example = "dsa\nsad\ndas\n";
                Assert.Equal(example, sw.ToString());
            }
        }

        [Fact]
        public void AddShouldAdd()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                DictionaryOfManyTranslations dictionary = new DictionaryOfManyTranslations();
                dictionary.Add("kuusi", "six");
                foreach (string translation in dictionary.Translate("kuusi"))
                {
                    Console.WriteLine(translation);
                }
                Console.SetOut(stdout);
                string example = "six\n";
                Assert.Equal(example, sw.ToString());
            }
        }

        [Fact]
        public void TranslateShouldReturnAnEmptyList()
        {
            DictionaryOfManyTranslations dictionary = new DictionaryOfManyTranslations();
            Assert.Equal(new List<string>(), dictionary.Translate("kuusi"));
        }

        [Fact]
        public void RemoveShouldRemoveTheTranslations()
        {
            DictionaryOfManyTranslations dictionary = new DictionaryOfManyTranslations();
            dictionary.Add("kuusi", "six");
            dictionary.Add("kuusi", "your birch");
            dictionary.Add("kuusi", "your moon");
            dictionary.Remove("kuusi");

            Assert.Equal(new List<string>(), dictionary.Translate("kuusi"));

        }
    }
}
