namespace ProgramTests
{
    using System.Collections.Generic;
    using Xunit;
    using Exercise002;
    using TestMyCode.CSharp.API.Attributes;
    [Points("11-2")]
    public partial class ProgramTest
    {
        [Fact]
        public void TestLotteryContainsSevenNumbersInConstructor()
        {
            LotteryRow row = new LotteryRow();
            Assert.Equal(7, row.numbers.Count);
        }

        [Fact]
        public void TestListShouldBeSortedAndContainsSevenNumbers()
        {
            LotteryRow row = new LotteryRow();
            List<int> copy = new List<int>(row.numbers);
            copy.Sort();
            Assert.Equal(7, row.numbers.Count);
            Assert.Equal(copy, row.numbers);
        }


        [Fact]
        public void ContainsNumberShouldReturnTrue()
        {
            LotteryRow row = new LotteryRow();

            Assert.NotEmpty(row.numbers);
            Assert.Equal(7, row.numbers.Count);
            Assert.True(row.ContainsNumber(row.numbers[0]));
            Assert.True(row.ContainsNumber(row.numbers[1]));
            Assert.True(row.ContainsNumber(row.numbers[2]));
            Assert.True(row.ContainsNumber(row.numbers[3]));
            Assert.True(row.ContainsNumber(row.numbers[4]));
            Assert.True(row.ContainsNumber(row.numbers[5]));
            Assert.True(row.ContainsNumber(row.numbers[6]));
        }

        [Fact]
        public void ContainsNumberShouldReturnFalse()
        {
            LotteryRow row = new LotteryRow();
            Assert.False(row.ContainsNumber(0));
            Assert.False(row.ContainsNumber(41));
        }

        [Fact]
        public void NumbersInGivenRange()
        {
            LotteryRow row = new LotteryRow();
            Assert.InRange(row.numbers[0], 1, 40);
            Assert.InRange(row.numbers[1], 1, 40);
            Assert.InRange(row.numbers[2], 1, 40);
            Assert.InRange(row.numbers[3], 1, 40);
            Assert.InRange(row.numbers[4], 1, 40);
            Assert.InRange(row.numbers[5], 1, 40);
            Assert.InRange(row.numbers[6], 1, 40);
        }

        [Fact]
        public void NumbersAreDifferentAndIncreasing()
        {
            LotteryRow row = new LotteryRow();
            Assert.InRange(row.numbers[0], 1, 40);
            Assert.InRange(row.numbers[1], row.numbers[0] + 1, 40);
            Assert.InRange(row.numbers[2], row.numbers[1] + 1, 40);
            Assert.InRange(row.numbers[3], row.numbers[2] + 1, 40);
            Assert.InRange(row.numbers[4], row.numbers[3] + 1, 40);
            Assert.InRange(row.numbers[5], row.numbers[4] + 1, 40);
            Assert.InRange(row.numbers[6], row.numbers[5] + 1, 40);
        }
    }
}
