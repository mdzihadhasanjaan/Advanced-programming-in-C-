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
        [Points("11-3.2")]
        public void TestTooOld()
        {
            Assert.Throws<ArgumentException>(() => new Person("Matthew", 140));
        }

        [Fact]
        [Points("11-3.2")]
        public void TestTooYoung()
        {
            Assert.Throws<ArgumentException>(() => new Person("Mike", -1));
        }

        [Fact]
        [Points("11-3.1")]
        public void TestNullForName()
        {
            Assert.Throws<ArgumentException>(() => new Person(null, 32));
        }

        [Fact]
        [Points("11-3.1")]
        public void TestEmptyName()
        {
            Assert.Throws<ArgumentException>(() => new Person("", 42));
        }

        [Fact]
        [Points("11-3.1")]
        public void TestTooLongName()
        {
            Assert.Throws<ArgumentException>(() => new Person("Matthew Michael Bartholomew, Son of Matthew Jameson Junior Junior", 69));
        }

        [Fact]
        [Points("11-3.1")]
        public void TestProperPerson()
        {
            var exception = Record.Exception(() => new Person("Heikki", 36));
            Assert.Null(exception);
        }

        [Fact]
        [Points("11-3.2")]
        public void TestProperPersonAgain()
        {
            var exception = Record.Exception(() => new Person("Hank", 120));
            Assert.Null(exception);
        }
    }
}
