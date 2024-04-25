namespace ProgramTests
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using Xunit;
    using Exercise004;
    using TestMyCode.CSharp.API.Attributes;

    [Points("8-4")]
    public partial class ProgramTest
    {
        [Fact]
        public void TestPrintValues()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                Dictionary<string, Book> books = new Dictionary<string, Book>();
                Book senseAndSensibility = new Book("Sense and Sensibility", 1811, "...");
                Book prideAndPrejudice = new Book("Pride and Prejudice", 1813, "....");
                Book heikkisTerrificBook = new Book("Heikki's Terrific Book", 2022, "The end");
                books.Add(senseAndSensibility.name, senseAndSensibility);
                books.Add(prideAndPrejudice.name, prideAndPrejudice);
                books.Add(heikkisTerrificBook.name, heikkisTerrificBook);

                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Program.PrintValues(books);
                Console.SetOut(stdout);
                string expectedSense = "Name: Sense and Sensibility (1811)\nContent: ...";
                string expectedPride = "Name: Pride and Prejudice (1813)\nContent: ....";
                string expectedHeikki = "Name: Heikki's Terrific Book (2022)\nContent: The end";

                // Assert
                Assert.Contains(expectedSense, sw.ToString());
                Assert.Contains(expectedPride, sw.ToString());
                Assert.Contains(expectedHeikki, sw.ToString());
            }
        }

        [Fact]
        public void TestPrintValueIfNameContainsPrejud()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                Dictionary<string, Book> books = new Dictionary<string, Book>();
                Book senseAndSensibility = new Book("Sense and Sensibility", 1811, "...");
                Book prideAndPrejudice = new Book("Pride and Prejudice", 1813, "....");
                Book heikkisTerrificBook = new Book("Heikki's Terrific Book", 2022, "The end");
                books.Add(senseAndSensibility.name, senseAndSensibility);
                books.Add(prideAndPrejudice.name, prideAndPrejudice);
                books.Add(heikkisTerrificBook.name, heikkisTerrificBook);

                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Program.PrintValueIfNameContains(books, "prejud");
                Console.SetOut(stdout);
                string expectedPride = "Name: Pride and Prejudice (1813)\nContent: ....\n";

                // Assert
                Assert.Equal(expectedPride, sw.ToString());
            }
        }

        [Fact]
        public void TestPrintValueIfNameContainsHeikki()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                Dictionary<string, Book> books = new Dictionary<string, Book>();
                Book senseAndSensibility = new Book("Sense and Sensibility", 1811, "...");
                Book prideAndPrejudice = new Book("Pride and Prejudice", 1813, "....");
                Book heikkisTerrificBook = new Book("Heikki's Terrific Book", 2022, "The end");
                books.Add(senseAndSensibility.name, senseAndSensibility);
                books.Add(prideAndPrejudice.name, prideAndPrejudice);
                books.Add(heikkisTerrificBook.name, heikkisTerrificBook);

                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Program.PrintValueIfNameContains(books, "heikki");
                Console.SetOut(stdout);
                string expectedHeikki = "Name: Heikki's Terrific Book (2022)\nContent: The end\n";

                // Assert
                Assert.Equal(expectedHeikki, sw.ToString());
            }
        }
    }
}
