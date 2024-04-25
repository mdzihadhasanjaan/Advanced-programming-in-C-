namespace ProgramTests
{
    using System;
    using System.IO;
    using Xunit;
    using Exercise003;
    using TestMyCode.CSharp.API.Attributes;
    public partial class ProgramTest
    {
        [Fact]
        [Points("9-3.1")]
        public void TestBaseClass()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Warehouse wh = new Warehouse(100);
                wh.AddToWarehouse(12);
                wh.TakeFromWarehouse(1);
                wh.TakeFromWarehouse(-1);
                wh.AddToWarehouse(-1);
                Console.WriteLine(wh);

                Console.SetOut(stdout);
                string example = "balance: 11, space left 89\n";
                Assert.Equal(example, sw.ToString());
            }
        }

        [Fact]
        [Points("9-3.1")]
        public void TestProductWarehouse()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                ProductWarehouse juice = new ProductWarehouse("Juice", 1000);
                juice.AddToWarehouse(1000);
                juice.TakeFromWarehouse(11);
                Console.WriteLine(juice);
                Console.SetOut(stdout);
                string example = "Juice: balance: 989, space left 11\n";
                Assert.Equal(example, sw.ToString());
            }
        }

        [Fact]
        [Points("9-3.1")]
        public void TestAnotherProductWarehouse()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                ProductWarehouse milk = new ProductWarehouse("Maito", 200);
                milk.AddToWarehouse(1000);
                milk.TakeFromWarehouse(32);
                Console.WriteLine(milk);

                Console.SetOut(stdout);
                string example = "Maito: balance: 168, space left 32\n";
                Assert.Equal(example, sw.ToString());
            }
        }

        [Fact]
        [Points("9-3.2")]
        public void TestChangeHistory()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                ChangeHistory cs = new ChangeHistory();
                cs.Add(100);
                cs.Add(10);
                cs.Add(200);
                cs.Add(50);
                Console.WriteLine(cs);

                Console.SetOut(stdout);
                string example = "Current: 50 Min: 10 Max: 200\n";
                Assert.Equal(example, sw.ToString());
            }
        }

        [Fact]
        [Points("9-3.2")]
        public void TestAnotherChangeHistory()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                ChangeHistory cs = new ChangeHistory();
                cs.Add(100);
                cs.Add(10);
                cs.Add(2000);
                cs.Add(50);
                Console.WriteLine(cs);

                Console.SetOut(stdout);
                string example = "Current: 50 Min: 10 Max: 2000\n";
                Assert.Equal(example, sw.ToString());
            }
        }

        [Fact]
        [Points("9-3.3")]
        public void TestProductWarehouseWithHistory()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                ProductWarehouseWithHistory milk = new ProductWarehouseWithHistory("Milk", 1000, 100);
                milk.TakeFromWarehouse(10);
                milk.AddToWarehouse(100);
                milk.TakeFromWarehouse(-10000);
                Console.WriteLine(milk.History());
                Console.WriteLine(milk);
                Console.SetOut(stdout);
                string example = "Current: 190 Min: 90 Max: 190\nMilk: balance: 190, space left 810\n";
                Assert.Equal(example, sw.ToString());
            }
        }

        [Fact]
        [Points("9-3.3")]
        public void TestAnotherProductWarehouseWithHistory()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                ProductWarehouseWithHistory milk = new ProductWarehouseWithHistory("Chocolate", 10000, 1000);
                milk.TakeFromWarehouse(100);
                milk.AddToWarehouse(230);
                milk.TakeFromWarehouse(-1000000);
                Console.WriteLine(milk.History());
                Console.WriteLine(milk);
                Console.SetOut(stdout);
                string example = "Current: 1130 Min: 900 Max: 1130\nChocolate: balance: 1130, space left 8870\n";
                Assert.Equal(example, sw.ToString());
            }
        }

        [Fact]
        [Points("9-3.3")]
        public void TestThirdProductWarehouseWithHistory()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                ProductWarehouseWithHistory milk = new ProductWarehouseWithHistory("Chocolate", 11000, 1000);
                milk.TakeFromWarehouse(100);
                milk.AddToWarehouse(230);
                milk.TakeFromWarehouse(100);
                Console.WriteLine(milk.History());
                Console.WriteLine(milk);
                Console.SetOut(stdout);
                string example = "Current: 1030 Min: 900 Max: 1130\nChocolate: balance: 1030, space left 9970\n";
                Assert.Equal(example, sw.ToString());
            }
        }
    }
}
