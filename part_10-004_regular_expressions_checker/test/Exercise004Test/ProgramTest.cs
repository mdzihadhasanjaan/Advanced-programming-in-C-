namespace ProgramTests
{
    using System;
    using System.IO;
    using Xunit;
    using Exercise004;
    using TestMyCode.CSharp.API.Attributes;
    public partial class ProgramTest
    {


        [Fact]
        [Points("10-4.1")]
        public void TestDaysOfWeekABC()
        {
            Checker check = new Checker();
            Assert.False(check.DayOfWeek("abc"));
        }
        [Fact]
        [Points("10-4.1")]
        public void TestDaysOfWeekMon()
        {
            Checker check = new Checker();
            Assert.True(check.DayOfWeek("mon"));
        }

        [Fact]
        [Points("10-4.1")]
        public void TestDaysOfWeekTue()
        {
            Checker check = new Checker();
            Assert.True(check.DayOfWeek("tue"));
        }

        [Fact]
        [Points("10-4.1")]
        public void TestDaysOfWeekWed()
        {
            Checker check = new Checker();
            Assert.True(check.DayOfWeek("wed"));
        }

        [Fact]
        [Points("10-4.1")]
        public void TestDaysOfWeekThursday()
        {
            Checker check = new Checker();
            Assert.True(check.DayOfWeek("thu"));
        }

        [Fact]
        [Points("10-4.1")]
        public void TestDaysOfWeekFriday()
        {
            Checker check = new Checker();
            Assert.True(check.DayOfWeek("fri"));
        }

        [Fact]
        [Points("10-4.1")]
        public void TestDaysOfWeekSaturday()
        {
            Checker check = new Checker();
            Assert.True(check.DayOfWeek("sat"));
        }

        [Fact]
        [Points("10-4.1")]
        public void TestDaysOfWeekSunday()
        {
            Checker check = new Checker();
            Assert.True(check.DayOfWeek("sun"));
        }

        [Fact]
        [Points("10-4.2")]
        public void TestWovels()
        {
            Checker check = new Checker();
            Assert.True(check.AllVowels("aeiouaaeeioiouoaaaaaaaaiaoueaiaeiou"));
        }

        [Fact]
        [Points("10-4.2")]
        public void TestWovelsShorter()
        {
            Checker check = new Checker();
            Assert.True(check.AllVowels("aeiouaaeeioiouoiaoueaiaeiou"));
        }

        [Fact]
        [Points("10-4.2")]
        public void TestWovelsShort()
        {
            Checker check = new Checker();
            Assert.True(check.AllVowels("auoie"));
        }

        [Fact]
        [Points("10-4.2")]
        public void TestWovelsFalseExample()
        {
            Checker check = new Checker();
            Assert.False(check.AllVowels("aeiouaaeeioiouoKiaoueaiaeiou"));
        }

        [Fact]
        [Points("10-4.2")]
        public void TestNordicWovelsShouldBeFalse()
        {
            Checker check = new Checker();
            Assert.False(check.AllVowels("öäå"));
        }

        [Fact]
        [Points("10-4.2")]
        public void TestConsonantsKShouldBeFalse()
        {
            Checker check = new Checker();
            Assert.False(check.AllVowels("k"));
        }

        [Fact]
        [Points("10-4.2")]
        public void TestConsonantsYShouldBeFalse()
        {
            Checker check = new Checker();
            Assert.False(check.AllVowels("y"));
        }

        [Fact]
        [Points("10-4.2")]
        public void TestConsonantsGShouldBeFalse()
        {
            Checker check = new Checker();
            Assert.False(check.AllVowels("g"));
        }

        [Fact]
        [Points("10-4.3")]
        public void TestTimesOfDayAlmostMidnight()
        {
            Checker check = new Checker();
            Assert.True(check.TimeOfDay("23:59:59"));
        }

        [Fact]
        [Points("10-4.3")]
        public void TestTimesOfDayMidnight()
        {
            Checker check = new Checker();
            Assert.True(check.TimeOfDay("00:00:00"));
        }

        [Fact]
        [Points("10-4.3")]
        public void TestTimesOfDayOverTime()
        {
            Checker check = new Checker();
            Assert.True(check.TimeOfDay("00:00:01"));
        }

        [Fact]
        [Points("10-4.3")]
        public void TestTimesOfDay24Hours()
        {
            Checker check = new Checker();
            Assert.False(check.TimeOfDay("24:00:00"));
        }

        [Fact]
        [Points("10-4.3")]
        public void TestTimesOfDayNoon()
        {
            Checker check = new Checker();
            Assert.True(check.TimeOfDay("12:00:00"));
        }

        [Fact]
        [Points("10-4.3")]
        public void TestTimesOfDayRandomTime()
        {
            Random random = new Random();
            int hours = random.Next(12, 24);
            int minutes = random.Next(10, 60);
            int seconds = random.Next(10, 60);
            Checker check = new Checker();
            Assert.True(check.TimeOfDay($"{hours}:{minutes}:{seconds}"));
        }

        [Fact]
        [Points("10-4.3")]
        public void TestTimesOfDayFalseOverSeconds()
        {
            Checker check = new Checker();
            Assert.False(check.TimeOfDay("15:47:72"));
        }

        [Fact]
        [Points("10-4.3")]
        public void TestTimesOfDayFalseOverMinutes()
        {
            Checker check = new Checker();
            Assert.False(check.TimeOfDay("23:60:59"));
        }
    }
}

