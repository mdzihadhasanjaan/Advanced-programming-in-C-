namespace ProgramTests
{
    using System;
    using System.IO;
    using Xunit;
    using Exercise005;
    using TestMyCode.CSharp.API.Attributes;

    [Points("8-5")]
    public partial class ProgramTest
    {
        [Fact]
        public void TestSimpleAdd()
        {
            IOU myIou = new IOU();
            myIou.ChangeDebt("You", 69);
            // Assert
            Assert.Equal(69, myIou.HowMuchDoIOweTo("You"));
        }

        [Fact]
        public void TestSimpleNegativeAdd()
        {
            IOU myIou = new IOU();
            myIou.ChangeDebt("You", -1000);
            // Assert
            Assert.Equal(0, myIou.HowMuchDoIOweTo("You"));
        }

        [Fact]
        public void TestSimpleOwe()
        {
            IOU myIou = new IOU();
            myIou.ChangeDebt("You", 1000);
            // Assert
            Assert.Equal(1000, myIou.HowMuchDoIOweTo("You"));
        }

        [Fact]
        public void TestExample()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                IOU mattsIOU = new IOU();
                mattsIOU.ChangeDebt("Arthur", 51);
                mattsIOU.ChangeDebt("Michael", 30);

                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Console.WriteLine(mattsIOU.HowMuchDoIOweTo("Arthur"));
                Console.WriteLine(mattsIOU.HowMuchDoIOweTo("Michael"));
                Console.WriteLine(mattsIOU.HowMuchDoIOweTo("Heikki"));
                Console.SetOut(stdout);

                // Assert
                Assert.Equal(@"51
30
0
", sw.ToString());
            }
        }

        [Fact]
        public void TestSecondExample()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                IOU mattsIOU = new IOU();
                mattsIOU.ChangeDebt("Arthur", -10);
                Console.WriteLine(mattsIOU.HowMuchDoIOweTo("Arthur"));
                mattsIOU.ChangeDebt("Arthur", 51);
                mattsIOU.ChangeDebt("Arthur", 30);
                Console.WriteLine(mattsIOU.HowMuchDoIOweTo("Arthur"));
                mattsIOU.ChangeDebt("Arthur", -30);
                Console.WriteLine(mattsIOU.HowMuchDoIOweTo("Arthur"));
                mattsIOU.ChangeDebt("Arthur", -80);
                Console.WriteLine(mattsIOU.HowMuchDoIOweTo("Arthur"));
                Console.SetOut(stdout);
                Assert.Equal(@"0
81
51
0
", sw.ToString());
            }
        }

        [Fact]
        public void TestMultipleChanges()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                IOU mattsIOU = new IOU();
                mattsIOU.ChangeDebt("Heikki", 81);
                mattsIOU.ChangeDebt("Heikki", -30);
                Console.WriteLine(mattsIOU.HowMuchDoIOweTo("Heikki"));
                mattsIOU.ChangeDebt("Heikki", 20);
                Console.WriteLine(mattsIOU.HowMuchDoIOweTo("Heikki"));
                mattsIOU.ChangeDebt("Heikki", 80);
                Console.WriteLine(mattsIOU.HowMuchDoIOweTo("Heikki"));
                mattsIOU.ChangeDebt("Heikki", -121);
                Console.WriteLine(mattsIOU.HowMuchDoIOweTo("Heikki"));
                Console.SetOut(stdout);
                Assert.Equal(@"51
71
151
30
", sw.ToString());
            }
        }
    }
}
