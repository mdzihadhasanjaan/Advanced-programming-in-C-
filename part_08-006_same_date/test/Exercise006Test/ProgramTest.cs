namespace ProgramTests
{
    using System;
    using System.IO;
    using Xunit;
    using Exercise006;
    using TestMyCode.CSharp.API.Attributes;
    [Points("8-6")]
    public partial class ProgramTest
    {
        [Fact]
        public void TestEqualsString()
        {
            using (StringWriter sw = new StringWriter())
            {
                SimpleDate d = new SimpleDate(1, 2, 2000);

                // Assert
                Assert.False(d.Equals("1.2.2020"));
            }
        }

        [Fact]
        public void TestDoesNotEqualDifferentDate()
        {
            using (StringWriter sw = new StringWriter())
            {
                SimpleDate d = new SimpleDate(1, 2, 2000);

                // Assert
                Assert.False(d.Equals(new SimpleDate(5, 2, 2012)));
            }
        }
        [Fact]
        public void TestEqualsSameDate()
        {
            using (StringWriter sw = new StringWriter())
            {
                SimpleDate d = new SimpleDate(1, 2, 2000);

                // Assert
                Assert.True(d.Equals(new SimpleDate(1, 2, 2000)));
            }
        }

        [Fact]
        public void TestEqualsCopySameDate()
        {
            using (StringWriter sw = new StringWriter())
            {
                SimpleDate d = new SimpleDate(1, 2, 2000);
                SimpleDate copy = d;

                // Assert
                Assert.True(d.Equals(copy));
            }
        }

        [Fact]
        public void TestHashCodeSameObject()
        {
            using (StringWriter sw = new StringWriter())
            {
                SimpleDate d = new SimpleDate(1, 2, 2000);

                // Assert
                Assert.Equal(d.GetHashCode(), d.GetHashCode());
            }
        }

        [Fact]
        public void TestHashCodeDifferentObjectSameDate()
        {
            using (StringWriter sw = new StringWriter())
            {
                SimpleDate d = new SimpleDate(1, 2, 2000);
                SimpleDate d2 = new SimpleDate(1, 2, 2000);

                // Assert
                Assert.Equal(d.GetHashCode(), d2.GetHashCode());
            }
        }

        [Fact]
        public void TestHashCodeDifferentObjectDifferentDate()
        {
            using (StringWriter sw = new StringWriter())
            {
                SimpleDate d = new SimpleDate(1, 2, 2000);
                SimpleDate d2 = new SimpleDate(5, 2, 2000);

                // Assert
                Assert.NotEqual(d.GetHashCode(), d2.GetHashCode());
            }
        }
    }
}
