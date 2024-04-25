namespace ProgramTests
{
    using System;
    using System.IO;
    using Xunit;
    using Exercise007;
    using TestMyCode.CSharp.API.Attributes;
    public partial class ProgramTest
    {


        [Fact]
        [Points("9-7.1")]
        public void OrganismExampleShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Organism organism = new Organism(20, 30);
                Console.WriteLine(organism);
                organism.Move(-10, 5);
                Console.WriteLine(organism);
                organism.Move(50, 20);
                Console.WriteLine(organism);
                Console.SetOut(stdout);
                string example = "x: 20; y: 30\nx: 10; y: 35\nx: 60; y: 55";
                Assert.Contains(example, sw.ToString());
            }
        }


        [Fact]
        [Points("9-7.2")]
        public void HerdExampleShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Herd herd = new Herd();
                herd.AddToHerd(new Organism(57, 66));
                herd.AddToHerd(new Organism(73, 56));
                herd.AddToHerd(new Organism(46, 52));
                herd.AddToHerd(new Organism(19, 107));
                Console.WriteLine(herd);
                Console.SetOut(stdout);
                string example = "x: 57; y: 66\nx: 73; y: 56\nx: 46; y: 52\nx: 19; y: 107";
                Assert.Contains(example, sw.ToString());
            }
        }

        [Fact]
        [Points("9-7.1")]
        public void ModifiedFirstExampleShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Organism organism = new Organism(5, 10);
                Console.WriteLine(organism);
                organism.Move(-100, 50);
                Console.WriteLine(organism);
                organism.Move(500, 22);
                Console.WriteLine(organism);
                Console.SetOut(stdout);
                string example = "x: 5; y: 10\nx: -95; y: 60\nx: 405; y: 82";
                Assert.Contains(example, sw.ToString());
            }
        }

        [Fact]
        [Points("9-7.2")]
        public void ModifiedHerdExampleShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Herd herd = new Herd();
                herd.AddToHerd(new Organism(7, 6));
                herd.AddToHerd(new Organism(6, 2));
                herd.AddToHerd(new Organism(57, 66));
                herd.AddToHerd(new Organism(3, 6));
                herd.AddToHerd(new Organism(73, 56));
                herd.AddToHerd(new Organism(46, 52));
                herd.AddToHerd(new Organism(9, 7));
                herd.AddToHerd(new Organism(19, 107));
                Console.WriteLine(herd);
                Console.SetOut(stdout);
                string example = "x: 7; y: 6\nx: 6; y: 2\nx: 57; y: 66\nx: 3; y: 6\nx: 73; y: 56\nx: 46; y: 52\nx: 9; y: 7\nx: 19; y: 107";
                Assert.Contains(example, sw.ToString());
            }
        }

        [Fact]
        [Points("9-7.2")]
        public void MovingHerdExampleShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Herd herd = new Herd();
                herd.AddToHerd(new Organism(57, 66));
                herd.AddToHerd(new Organism(73, 56));
                herd.AddToHerd(new Organism(46, 52));
                herd.AddToHerd(new Organism(19, 107));
                herd.Move(5, 6);
                Console.WriteLine(herd);
                Console.SetOut(stdout);
                string example = "x: 62; y: 72\nx: 78; y: 62\nx: 51; y: 58\nx: 24; y: 113";
                Assert.Contains(example, sw.ToString());
            }
        }

        [Fact]
        [Points("9-7.2")]
        public void MovingHerdMoreShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Herd herd = new Herd();
                herd.AddToHerd(new Organism(57, 66));
                herd.AddToHerd(new Organism(73, 56));
                herd.AddToHerd(new Organism(46, 52));
                herd.AddToHerd(new Organism(19, 107));
                herd.Move(5, 6);
                herd.Move(5, 6);
                Console.WriteLine(herd);
                Console.SetOut(stdout);
                string example = "x: 67; y: 78\nx: 83; y: 68\nx: 56; y: 64\nx: 29; y: 119";
                Assert.Contains(example, sw.ToString());
            }
        }
    }
}
