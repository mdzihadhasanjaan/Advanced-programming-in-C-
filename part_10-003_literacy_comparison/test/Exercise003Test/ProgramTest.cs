namespace ProgramTests
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using Xunit;
    using Exercise003;
    using TestMyCode.CSharp.API.Attributes;
    public partial class ProgramTest
    {
        [Fact]
        [Points("10-3.1")]
        public void TestTheUIWorks()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                // Save a reference to the standard output.
                TextWriter stdout = Console.Out;

                // Redirect standard output to variable.
                Console.SetOut(sw);

                var data = String.Join(Environment.NewLine, new[]
                {
          "The Ringing Lullaby Book","0", "The Exiting Transpotation Vehicles","0", "The Snowy Forest Calls","12", "Litmanen 10", "10","\n"
          });

                Console.SetIn(new System.IO.StringReader(data));

                // Call student's code
                Program.Main(null);

                // Restore the original standard output.
                Console.SetOut(stdout);
                string comparison = "The Ringing Lullaby Book (recommended for 0 year-olds or older)";
                Assert.Contains(comparison, sw.ToString());
                comparison = "The Exiting Transpotation Vehicles (recommended for 0 year-olds or older)";
                Assert.Contains(comparison, sw.ToString());
                comparison = "Litmanen 10 (recommended for 10 year-olds or older)";
                Assert.Contains(comparison, sw.ToString());
                comparison = "The Snowy Forest Calls (recommended for 12 year-olds or older)";
                Assert.Contains(comparison, sw.ToString());
            }
        }

        [Fact]
        [Points("10-3.1")]
        public void TestTheUIWorksWithOtherBooks()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                // Save a reference to the standard output.
                TextWriter stdout = Console.Out;

                // Redirect standard output to variable.
                Console.SetOut(sw);

                var data = String.Join(Environment.NewLine, new[]
                {
          "The Best Possible Book in the World","42", "The Best Trains of My Lifetime","6", "One Flew Over the Coding Course","21", "Magic Michael", "18","\n"
          });

                Console.SetIn(new System.IO.StringReader(data));

                // Call student's code
                Program.Main(null);

                // Restore the original standard output.
                Console.SetOut(stdout);
                string comparison = "The Best Possible Book in the World (recommended for 42 year-olds or older)";
                Assert.Contains(comparison, sw.ToString());
                comparison = "The Best Trains of My Lifetime (recommended for 6 year-olds or older)";
                Assert.Contains(comparison, sw.ToString());
                comparison = "One Flew Over the Coding Course (recommended for 21 year-olds or older)";
                Assert.Contains(comparison, sw.ToString());
                comparison = "Magic Michael (recommended for 18 year-olds or older)";
                Assert.Contains(comparison, sw.ToString());
            }
        }

        [Fact]
        [Points("10-3.3")]
        public void TestFinalOrderExample()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                // Save a reference to the standard output.
                TextWriter stdout = Console.Out;

                // Redirect standard output to variable.
                Console.SetOut(sw);

                var data = String.Join(Environment.NewLine, new[]
                {
          "The Ringing Lullaby Book","0", "The Exiting Transpotation Vehicles","0", "The Snowy Forest Calls","12", "Litmanen 10", "10","\n"
          });

                Console.SetIn(new System.IO.StringReader(data));

                // Call student's code
                Program.Main(null);

                // Restore the original standard output.
                Console.SetOut(stdout);
                string comparison = "The Exiting Transpotation Vehicles (recommended for 0 year-olds or older)\nThe Ringing Lullaby Book (recommended for 0 year-olds or older)\nLitmanen 10 (recommended for 10 year-olds or older)\nThe Snowy Forest Calls (recommended for 12 year-olds or older)";
                Assert.Contains(comparison, sw.ToString());
            }
        }

        [Fact]
        [Points("10-3.1")]
        public void TestBookCreation()
        {
            Book book = new Book("Awesome title", 18);
            Assert.Equal(typeof(Book), book.GetType());
            Assert.Equal(book.name, "Awesome title");
            Assert.Equal(book.ageRecommendation, 18);
        }

        [Fact]
        [Points("10-3.2")]
        public void TestSortingBookList()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                Book book1 = new Book("Awesome title", 18);
                Book book2 = new Book("Awesome title Too", 9);
                Book book3 = new Book("Awesome titl3", 12);
                List<Book> books = new List<Book> { book1, book3, book2 };
                books.Sort();
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                books.ForEach(Console.WriteLine);
                Console.SetOut(stdout);
                string example = "Awesome title Too (recommended for 9 year-olds or older)\nAwesome titl3 (recommended for 12 year-olds or older)\nAwesome title (recommended for 18 year-olds or older)\n";
                Assert.Equal(example, sw.ToString());
            }
        }

        [Fact]
        [Points("10-3.2")]
        public void TestSortingBookListWithDifferentAgeRecommendations()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                Book book1 = new Book("My good book", 6);
                Book book2 = new Book("My best book", 12);
                Book book3 = new Book("My better book", 9);
                Book book4 = new Book("My bestest book", 15);
                List<Book> books = new List<Book> { book4, book1, book3, book2 };
                books.Sort();
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                books.ForEach(Console.WriteLine);
                Console.SetOut(stdout);
                string example = "My good book (recommended for 6 year-olds or older)\nMy better book (recommended for 9 year-olds or older)\nMy best book (recommended for 12 year-olds or older)\nMy bestest book (recommended for 15 year-olds or older)\n";
                Assert.Equal(example, sw.ToString());
            }
        }

        [Fact]
        [Points("10-3.3")]
        public void TestSortingEqualAgesList()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                Book book1 = new Book("Awesome title", 9);
                Book book2 = new Book("Awesome title Too", 9);
                Book book3 = new Book("Awesome titl3", 9);
                List<Book> books = new List<Book> { book1, book3, book2 };
                books.Sort();
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                books.ForEach(Console.WriteLine);
                Console.SetOut(stdout);
                string example = "Awesome titl3 (recommended for 9 year-olds or older)\nAwesome title (recommended for 9 year-olds or older)\nAwesome title Too (recommended for 9 year-olds or older)\n";
                Assert.Equal(example, sw.ToString());
            }
        }

        [Fact]
        [Points("10-3.3")]
        public void TestFinalOrder()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                // Save a reference to the standard output.
                TextWriter stdout = Console.Out;

                // Redirect standard output to variable.
                Console.SetOut(sw);

                var data = String.Join(Environment.NewLine, new[]
                {
          "The Finest Book in the world","0", "The Testing book of all ages","0", "The Ultimate Cook Book","10", "Litmanen 10", "10","\n"
          });

                Console.SetIn(new System.IO.StringReader(data));

                // Call student's code
                Program.Main(null);

                // Restore the original standard output.
                Console.SetOut(stdout);
                string comparison = @"The Finest Book in the world (recommended for 0 year-olds or older)
The Testing book of all ages (recommended for 0 year-olds or older)
Litmanen 10 (recommended for 10 year-olds or older)
The Ultimate Cook Book (recommended for 10 year-olds or older)";
                Assert.Contains(comparison, sw.ToString());
            }
        }
    }
}
