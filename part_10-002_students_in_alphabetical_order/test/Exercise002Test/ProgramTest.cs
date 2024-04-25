namespace ProgramTests
{
    using System;
    using System.IO;
    using Xunit;
    using Exercise002;
    using TestMyCode.CSharp.API.Attributes;
    [Points("10-2")]
    public partial class ProgramTest
    {


        [Fact]
        public void StudentImplementsIComparable()
        {
            Assert.True(typeof(IComparable<Student>).IsAssignableFrom(typeof(Student)));
        }

        [Fact]
        public void ExampleShouldWork()
        {
            Student first = new Student("jamo");
            Student second = new Student("jamo1");
            Assert.Equal(-1, first.CompareTo(second));
        }

        [Fact]
        public void EqualNamesShouldWork()
        {
            Student first = new Student("jamo1");
            Student second = new Student("jamo1");
            Assert.Equal(0, first.CompareTo(second));
        }

        [Fact]
        public void OtherWayNamesShouldWork()
        {
            Student first = new Student("jamo1");
            Student second = new Student("jamo");
            Assert.Equal(1, first.CompareTo(second));
        }

        [Fact]
        public void LeevingsShouldWork()
        {
            Student first = new Student("Jenna Elli-Noora Alexandra Jurvanen");
            Student second = new Student("Pikku Myy");
            Assert.Equal(-1, first.CompareTo(second));
        }

        [Fact]
        public void LeevingsEqualShouldWork()
        {
            Student first = new Student("Jenna Elli-Noora Alexandra Jurvanen");
            Student second = new Student("Jenna Elli-Noora Alexandra Jurvanen");
            Assert.Equal(0, first.CompareTo(second));
        }

        [Fact]
        public void LeevingsLowercaseEqualShouldWork()
        {
            Student first = new Student("jenna elli-noora alexandra jurvanen");
            Student second = new Student("jenna elli-noora alexandra jurvanen");
            Assert.Equal(0, first.CompareTo(second));
        }

        [Fact]
        public void LeevingsALLCAPSEqualShouldWork()
        {
            Student first = new Student("JENNA ELLI-NOORA ALEXANDRA JURVANEN");
            Student second = new Student("JENNA ELLI-NOORA ALEXANDRA JURVANEN");
            Assert.Equal(0, first.CompareTo(second));
        }

        [Fact]
        public void NullShouldWork()
        {
            Student first = new Student(null);
            Student second = new Student("Jenna Elli-Noora Alexandra Jurvanen");
            Assert.Equal(1, second.CompareTo(first));
        }
    }
}
