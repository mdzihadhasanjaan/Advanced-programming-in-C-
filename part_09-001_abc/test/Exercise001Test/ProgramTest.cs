namespace ProgramTests
{
    using System;
    using System.IO;
    using Xunit;
    using Exercise001;
    using TestMyCode.CSharp.API.Attributes;
    [Points("9-1")]
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
                A a = new A();
                B b = new B();
                C c = new C();

                a.APrint();
                b.BPrint();
                c.CPrint();
                Console.SetOut(stdout);
                string example = "A\nB\nC\n";
                Assert.Equal(example, sw.ToString());
            }
        }

        [Fact]
        public void ExampleWithInheritanceShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                C c = new C();

                c.APrint();
                c.BPrint();
                c.CPrint();
                Console.SetOut(stdout);
                string example = "A\nB\nC\n";
                Assert.Equal(example, sw.ToString());
            }
        }

        [Fact]
        public void InheritingBShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                B b = new B();

                b.APrint();
                b.BPrint();
                Console.SetOut(stdout);
                string example = "A\nB\n";
                Assert.Equal(example, sw.ToString());
            }
        }

        [Fact]
        public void AShouldWorkAlone()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                A a = new A();

                a.APrint();
                Console.SetOut(stdout);
                string example = "A\n";
                Assert.Equal(example, sw.ToString());
            }
        }
    }
}
