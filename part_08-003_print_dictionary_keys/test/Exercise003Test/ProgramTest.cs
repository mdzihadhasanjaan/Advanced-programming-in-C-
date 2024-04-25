namespace ProgramTests
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using Xunit;
    using Exercise003;
    using TestMyCode.CSharp.API.Attributes;
    [Points("8-3")]
    public partial class ProgramTest
    {
        [Fact]
        public void TestPrintKeys()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("f.e", "for example");
                dict.Add("etc.", "and so on");
                dict.Add("i.e", "more precisely");
                dict.Add("jne", "ja niin edelleen");
                dict.Add("lol", "laughing out loud");

                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Program.PrintKeys(dict);
                Console.SetOut(stdout);

                // Assert
                Assert.Contains("f.e", sw.ToString());
                Assert.Contains("etc", sw.ToString());
                Assert.Contains("i.e", sw.ToString());
                Assert.Contains("jne", sw.ToString());
                Assert.Contains("lol", sw.ToString());
            }
        }

        [Fact]
        public void TestPrintKeysWhereI()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("f.e", "for example");
                dict.Add("etc.", "and so on");
                dict.Add("i.e", "more precisely");
                dict.Add("jne", "ja niin edelleen");
                dict.Add("lol", "laughing out loud");

                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Program.PrintKeysWhere(dict, "i");
                Console.SetOut(stdout);

                // Assert
                Assert.Equal("i.e\n", sw.ToString());
            }
        }


        [Fact]
        public void TestPrintKeysWhereJ()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("f.e", "for example");
                dict.Add("etc.", "and so on");
                dict.Add("i.e", "more precisely");
                dict.Add("jne", "ja niin edelleen");
                dict.Add("lol", "laughing out loud");

                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Program.PrintKeysWhere(dict, "j");
                Console.SetOut(stdout);

                // Assert
                Assert.Equal("jne\n", sw.ToString());
            }
        }

        [Fact]
        public void TestPrintKeysWhereDotE()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("f.e", "for example");
                dict.Add("etc.", "and so on");
                dict.Add("i.e", "more precisely");
                dict.Add("jne", "ja niin edelleen");
                dict.Add("lol", "laughing out loud");

                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Program.PrintKeysWhere(dict, ".e");
                Console.SetOut(stdout);

                // Assert
                Assert.Contains("f.e", sw.ToString());
                Assert.Contains("i.e", sw.ToString());
            }
        }

        [Fact]
        public void TestPrintKeysWhereE()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("f.e", "for example");
                dict.Add("etc.", "and so on");
                dict.Add("i.e", "more precisely");
                dict.Add("jne", "ja niin edelleen");
                dict.Add("lol", "laughing out loud");

                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Program.PrintKeysWhere(dict, "e");
                Console.SetOut(stdout);

                // Assert
                Assert.Contains("f.e", sw.ToString());
                Assert.Contains("etc", sw.ToString());
                Assert.Contains("i.e", sw.ToString());
                Assert.Contains("jne", sw.ToString());
            }
        }

        [Fact]
        public void TestPrintValuesWhereDotE()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict.Add("f.e", "for example");
                dict.Add("etc.", "and so on");
                dict.Add("i.e", "more precisely");
                dict.Add("jne", "ja niin edelleen");
                dict.Add("lol", "laughing out loud");

                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Program.PrintValuesOfKeysWhere(dict, ".e");
                Console.SetOut(stdout);

                // Assert
                Assert.Contains("for example", sw.ToString());
                Assert.Contains("more precisely", sw.ToString());
                Assert.DoesNotContain("ja niin edelleen", sw.ToString());
            }
        }
    }
}
