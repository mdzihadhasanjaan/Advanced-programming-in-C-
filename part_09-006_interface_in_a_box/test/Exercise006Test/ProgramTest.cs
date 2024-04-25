namespace ProgramTests
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using Xunit;
    using Exercise006;
    using TestMyCode.CSharp.API.Attributes;
    public partial class ProgramTest
    {
        [Fact]
        [Points("9-6.1")]
        public void BookShouldWork()
        {
            Book book = new Book("Heikki", "Great Adventures of Coding", 2021);
            Assert.Equal("Heikki: Great Adventures of Coding (2021)", book.ToString());
        }

        [Fact]
        [Points("9-6.1")]
        public void FurnitureShouldWork()
        {
            Furniture grill = new Furniture("Barbeque", "Charcoal", 15);
            Assert.Equal("Charcoal Barbeque - weight 15 kg", grill.ToString());
        }

        [Fact]
        [Points("9-6.2")]
        public void SecondExampleShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Book book1 = new Book("Fedor Dostojevski", "Crime and Punishment", 1866);
                Book book2 = new Book("Robert Martin", "Clean Code", 2008);
                Book book3 = new Book("Kent Beck", "Test Driven Development", 2000);
                Furniture sofa = new Furniture("Sofa", "Red", 20);
                Furniture bed = new Furniture("Twin bed", "White", 15);
                Furniture table = new Furniture("Dining room table", "Oak", 30);
                Box box = new Box(40);
                box.Add(book1);
                box.Add(book2);
                box.Add(book3);
                box.Add(sofa);
                box.Add(bed);
                box.Add(table);
                Console.WriteLine(box);
                Console.SetOut(stdout);
                string example = "5 items, total weight 38 kg\n";
                Assert.Equal(example, sw.ToString());
            }
        }


        [Fact]
        [Points("9-6.2")]
        public void ThirdExampleShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Book book1 = new Book("Fedor Dostojevski", "Crime and Punishment", 1866);
                Book book2 = new Book("Robert Martin", "Clean Code", 2008);
                Book book3 = new Book("Kent Beck", "Test Driven Development", 2000);
                Furniture sofa = new Furniture("Sofa", "Red", 20);
                Furniture bed = new Furniture("Twin bed", "White", 15);
                Furniture table = new Furniture("Dining room table", "Oak", 30);
                Box bookBox = new Box(5);
                bookBox.Add(book1);
                bookBox.Add(book2);
                bookBox.Add(book3);
                Console.WriteLine(bookBox);
                Box movingVan = new Box(800);
                movingVan.Add(bookBox);
                movingVan.Add(sofa);
                movingVan.Add(bed);
                movingVan.Add(table);
                Console.WriteLine(movingVan);
                Box shippingContainer = new Box(3000);
                shippingContainer.Add(movingVan);
                Console.WriteLine(shippingContainer);
                Console.SetOut(stdout);
                string example = "3 items, total weight 3 kg\n4 items, total weight 68 kg\n1 items, total weight 68 kg\n";
                Assert.Equal(example, sw.ToString());
            }
        }

        [Fact]
        [Points("9-6.2")]
        public void BoxesShouldRespectTheirLimits()
        {
            {
                Furniture sofa = new Furniture("Sofa", "Red", 20);
                Box movingVan1 = new Box(19);
                Box movingVan2 = new Box(20);
                movingVan1.Add(sofa);
                movingVan2.Add(sofa);
                Assert.Equal(0, movingVan1.Weight());
                Assert.NotEqual(20, movingVan1.Weight());
                Assert.Equal(20, movingVan2.Weight());
                Assert.NotEqual(0, movingVan2.Weight());
            }
        }

        [Fact]
        [Points("9-6.2")]
        public void BoxesShouldRespectTheirLimitsWithBooks()
        {
            {
                Book book1 = new Book("Fedor Dostojevski", "Crime and Punishment", 1866);
                Box smallbox = new Box(1);
                smallbox.Add(book1);
                Assert.Equal(1, smallbox.Weight());
                Assert.NotEqual(0, smallbox.Weight());
            }
        }

        [Fact]
        [Points("9-6.2")]
        public void BoxesShouldRespectTheirLimitsWithTwoBooks()
        {
            {
                Book book1 = new Book("Fedor Dostojevski", "Crime and Punishment", 1866);
                Box smallbox = new Box(1);
                smallbox.Add(book1);
                smallbox.Add(book1);
                Assert.Equal(1, smallbox.Weight());
                Assert.NotEqual(0, smallbox.Weight());
            }
        }

        [Fact]
        [Points("9-6.2")]
        public void ZeroBoxShouldNotContainAnything()
        {
            {
                Book book1 = new Book("Fedor Dostojevski", "Crime and Punishment", 1866);
                Box smallbox = new Box(0);
                smallbox.Add(book1);
                Assert.Equal(0, smallbox.Weight());
                Assert.Equal("0 items, total weight 0 kg", smallbox.ToString());
                Assert.NotEqual(1, smallbox.Weight());
            }
        }
    }
}
