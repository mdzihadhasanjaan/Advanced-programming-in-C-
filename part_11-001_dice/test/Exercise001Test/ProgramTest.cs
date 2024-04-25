namespace ProgramTests
{
    using System;
    using System.IO;
    using System.Text;
    using Xunit;
    using Exercise001;
    using TestMyCode.CSharp.API.Attributes;
    [Points("11-1")]
    public partial class ProgramTest
    {
        [Fact]
        public void LargeExampleShouldWork()
        {
            StringBuilder sb = new StringBuilder();
            Die die = new Die(6);
            for (int i = 0; i < 100000; i++)
            {
                sb.Append(die.ThrowDie());
            }
            Assert.DoesNotContain("7", sb.ToString());
            Assert.DoesNotContain("0", sb.ToString());
        }

        [Fact]
        public void OneSidedDie()
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder comparison = new StringBuilder();
            Die die = new Die(1);

            for (int i = 0; i < 100000; i++)
            {
                comparison.Append("1");
                sb.Append(die.ThrowDie());
            }
            Assert.Equal(comparison.ToString(), sb.ToString());
            Assert.DoesNotContain("0", sb.ToString());
        }
    }
}
