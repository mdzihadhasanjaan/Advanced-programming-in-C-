namespace ProgramTests
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using Xunit;
    using Exercise001;
    using TestMyCode.CSharp.API.Attributes;
    [Points("10-1")]
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
                List<Human> humans = new List<Human>();
                humans.Add(new Human("Merja", 500));
                humans.Add(new Human("Pertti", 80));
                humans.Add(new Human("Matti", 150000));
                humans.Sort();
                humans.ForEach(Console.WriteLine);
                Console.SetOut(stdout);
                string example = "Matti 150000\nMerja 500\nPertti 80\n";
                Assert.Equal(example, sw.ToString());
            }
        }

        [Fact]
        public void OtherPeopleShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                List<Human> humans = new List<Human>();
                humans.Add(new Human("Marja", 500));
                humans.Add(new Human("Perttu", 800));
                humans.Add(new Human("Matti", 1500000));
                humans.Sort();
                humans.ForEach(Console.WriteLine);
                Console.SetOut(stdout);
                string example = "Matti 1500000\nPerttu 800\nMarja 500\n";
                Assert.Equal(example, sw.ToString());
            }
        }


        [Fact]
        public void ShouldWorkOnMultiplePeople()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                List<Human> humans = new List<Human>();
                humans.Add(new Human("Merja", 600));
                humans.Add(new Human("Pertti", 80));
                humans.Add(new Human("Matti", 150000));
                humans.Add(new Human("Marja", 500));
                humans.Add(new Human("Perttu", 800));
                humans.Add(new Human("Matti", 1500000));
                humans.Sort();
                humans.ForEach(Console.WriteLine);
                Console.SetOut(stdout);
                string example = "Matti 1500000\nMatti 150000\nPerttu 800\nMerja 600\nMarja 500\nPertti 80\n";
                Assert.Equal(example, sw.ToString());
            }
        }

        [Fact]
        public void DirectComparisonShouldWork()
        {
            Assert.Equal(-1, Math.Sign(new Human("Mika", 800).CompareTo(new Human("Mike", 720))));
        }

        [Fact]
        public void DirectComparisonShouldWorkOtherWay()
        {
            Assert.Equal(1, Math.Sign(new Human("Mika", 880).CompareTo(new Human("Mike", 960))));
        }

        [Fact]
        public void DirectComparisonEqualityShouldWork()
        {
            Assert.Equal(0, Math.Sign(new Human("Mika", 97856).CompareTo(new Human("Mike", 97856))));
        }
    }
}
