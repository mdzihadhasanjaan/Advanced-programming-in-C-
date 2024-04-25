namespace ProgramTests
{
    using System;
    using System.IO;
    using Xunit;
    using Exercise004;
    using TestMyCode.CSharp.API.Attributes;
    public partial class ProgramTest
    {

        [Fact]
        [Points("9-4.1")]
        public void TestEquals()
        {
            Item coffee = new Item("Kahvi", 23);
            Item another = new Item("Kahvi", 2);
            Assert.Equal(coffee, another);
        }

        [Fact]
        [Points("9-4.1")]
        public void TestAnotherEquals()
        {
            Item coffee = new Item("Potato", 23);
            Item another = new Item("Potato", 200);
            Assert.Equal(coffee, another);
        }

        [Fact]
        [Points("9-4.1")]
        public void TestHashCode()
        {
            Item coffee = new Item("Kahvi", 23);
            Item another = new Item("Kahvi", 2);
            Assert.Equal(coffee.GetHashCode(), another.GetHashCode());
        }

        [Fact]
        [Points("9-4.1")]
        public void TestAnotherHashCode()
        {
            Item coffee = new Item("Potato", 42);
            Item another = new Item("Potato", 69);
            Assert.Equal(coffee.GetHashCode(), another.GetHashCode());
        }


        [Fact]
        [Points("9-4.2")]
        public void MaxWeightExampleShouldWork()
        {
            BoxWithMaxWeight coffeeBox = new BoxWithMaxWeight(10);
            coffeeBox.Add(new Item("Saludo", 5));
            coffeeBox.Add(new Item("Pirkka", 5));
            coffeeBox.Add(new Item("Kopi Luwak", 5));
            bool one = coffeeBox.IsInBox(new Item("Saludo"));
            bool two = coffeeBox.IsInBox(new Item("Pirkka"));
            bool three = coffeeBox.IsInBox(new Item("Kopi Luwak"));
            Assert.True(one);
            Assert.True(two);
            Assert.False(three);
        }

        [Fact]
        [Points("9-4.2")]
        public void MaxWeightOthersShouldWork()
        {
            BoxWithMaxWeight coffeeBox = new BoxWithMaxWeight(15);
            coffeeBox.Add(new Item("Rosamunda", 5));
            coffeeBox.Add(new Item("Golden Green", 5));
            coffeeBox.Add(new Item("Peruna", 5));
            bool one = coffeeBox.IsInBox(new Item("Rosamunda"));
            bool two = coffeeBox.IsInBox(new Item("Golden Green"));
            bool three = coffeeBox.IsInBox(new Item("Peruna"));
            Assert.True(one);
            Assert.True(two);
            Assert.True(three);
        }

        [Fact]
        [Points("9-4.2")]
        public void MaxWeightTooLargeSingleShouldWork()
        {
            BoxWithMaxWeight coffeeBox = new BoxWithMaxWeight(1);
            coffeeBox.Add(new Item("Saludo", 5));
            Assert.False(coffeeBox.IsInBox(new Item("Saludo")));
        }

        [Fact]
        [Points("9-4.2")]
        public void MaxWeightFittingSingleShouldWork()
        {
            BoxWithMaxWeight coffeeBox = new BoxWithMaxWeight(5);
            coffeeBox.Add(new Item("Potato", 5));
            Assert.True(coffeeBox.IsInBox(new Item("Potato")));
        }

        [Fact]
        [Points("9-4.2")]
        public void OneItemBoxShouldWork()
        {
            OneItemBox box = new OneItemBox();
            box.Add(new Item("Saludo", 5));
            box.Add(new Item("Pirkka", 5));
            bool one = box.IsInBox(new Item("Saludo"));
            bool two = box.IsInBox(new Item("Pirkka"));
            Assert.True(one);
            Assert.False(two);
        }

        [Fact]
        [Points("9-4.2")]
        public void OtherOneItemBoxShouldWork()
        {
            OneItemBox box = new OneItemBox();
            box.Add(new Item("Peruna", 5));
            box.Add(new Item("Potato", 5));
            Assert.True(box.IsInBox(new Item("Peruna")));
            Assert.False(box.IsInBox(new Item("Potato")));
        }

        [Fact]
        [Points("9-4.2")]
        public void MisplacingBoxShouldWork()
        {
            MisplacingBox box = new MisplacingBox();
            box.Add(new Item("Saludo", 5));
            box.Add(new Item("Pirkka", 5));
            bool one = box.IsInBox(new Item("Saludo"));
            bool two = box.IsInBox(new Item("Pirkka"));
            Assert.False(one);
            Assert.False(two);
        }
    }
}
