namespace ProgramTests
{
    using System;
    using System.IO;
    using Xunit;
    using Exercise005;
    using TestMyCode.CSharp.API.Attributes;
    [Points("9-5")]
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
                TripleTacoBox trip = new TripleTacoBox();
                Console.WriteLine(trip.TacosRemaining());
                trip.Eat();
                Console.WriteLine(trip.TacosRemaining());
                trip.Eat();
                Console.WriteLine(trip.TacosRemaining());
                trip.Eat();
                Console.WriteLine(trip.TacosRemaining());
                // Try to eat one too much
                trip.Eat();
                Console.WriteLine(trip.TacosRemaining());

                Console.WriteLine();

                CustomTacoBox custom = new CustomTacoBox(2);
                Console.WriteLine(custom.TacosRemaining());
                custom.Eat();
                Console.WriteLine(custom.TacosRemaining());
                custom.Eat();
                Console.WriteLine(custom.TacosRemaining());
                // Try to eat one too much
                custom.Eat();
                Console.WriteLine(custom.TacosRemaining());
                Console.SetOut(stdout);
                string example = "3\n2\n1\n0\n0\n\n2\n1\n0\n0\n";
                Assert.Equal(example, sw.ToString());
            }
        }

        [Fact]
        public void TripleTacoEatWorks()
        {

            TripleTacoBox trip = new TripleTacoBox();
            trip.Eat();
            Assert.Equal(2, trip.TacosRemaining());

        }

        [Fact]
        public void TripleTacoEatFourWorks()
        {
            TripleTacoBox trip = new TripleTacoBox();
            trip.Eat();
            trip.Eat();
            trip.Eat();
            trip.Eat();
            Assert.Equal(0, trip.TacosRemaining());

        }

        [Fact]
        public void HugeCustomShouldWork()
        {
            CustomTacoBox custom = new CustomTacoBox(20000);
            custom.Eat();
            Assert.Equal(19999, custom.TacosRemaining());
        }

        [Fact]
        public void HugeCustomEatTooMuchShouldWork()
        {
            CustomTacoBox custom = new CustomTacoBox(2000);
            for (int i = 0; i < 3000; i++)
            {
                custom.Eat();
            }
            Assert.Equal(0, custom.TacosRemaining());
        }

        [Fact]
        public void ZeroCustomShouldWork()
        {
            CustomTacoBox custom = new CustomTacoBox(0);
            Assert.Equal(0, custom.TacosRemaining());
        }

        [Fact]
        public void ZeroCustomEatShouldWork()
        {
            CustomTacoBox custom = new CustomTacoBox(0);
            custom.Eat();
            Assert.Equal(0, custom.TacosRemaining());
        }
    }
}
