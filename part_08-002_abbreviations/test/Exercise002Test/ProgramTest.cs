namespace ProgramTests
{
    using System;
    using System.IO;
    using Xunit;
    using Exercise002;
    using TestMyCode.CSharp.API.Attributes;
    [Points("8-2")]
    public partial class ProgramTest
    {
        [Fact]
        public void TestAbbreviationsClassHasAbbs()
        {
            {
                Abbreviations abbs = new Abbreviations();
                abbs.AddAbbreviation("np", "no problem");
                // Assert
                Assert.True(abbs.HasAbbreviation("np"));
            }
        }

        [Fact]
        public void TestAbbreviationsClassDoesNotHaveAbbs()
        {
            {
                Abbreviations abbs = new Abbreviations();
                // Assert
                Assert.False(abbs.HasAbbreviation("lost"));
            }
        }

        [Fact]
        public void TestAbbreviationsClassFindExpNP()
        {
            {
                Abbreviations abbs = new Abbreviations();
                abbs.AddAbbreviation("np", "no problem");
                // Assert
                Assert.Equal("no problem", abbs.FindExplanationFor("np"));
            }
        }

        [Fact]
        public void TestAbbreviationsClassFindExpETC()
        {
            {
                Abbreviations abbs = new Abbreviations();
                abbs.AddAbbreviation("etc", "et cetera");
                // Assert
                Assert.Equal("et cetera", abbs.FindExplanationFor("etc"));
            }
        }

        [Fact]
        public void TestAbbreviationsClassFindExpJNE()
        {
            {
                Abbreviations abbs = new Abbreviations();
                abbs.AddAbbreviation("jne", "ja niin edelleen");
                // Assert
                Assert.Equal("ja niin edelleen", abbs.FindExplanationFor("jne"));
            }
        }


        [Fact]
        public void TestAbbreviationsClassDoNotFindUnexisting()
        {
            {
                Abbreviations abbs = new Abbreviations();
                // Assert
                Assert.Equal("not found", abbs.FindExplanationFor("jne"));
            }
        }
    }
}
