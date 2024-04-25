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
        [Points("8-7.1")]
        public void TestEqualsString()
        {
            using (StringWriter sw = new StringWriter())
            {
                LicensePlate li1 = new LicensePlate("FI", "ABC-123");

                // Assert
                Assert.False(li1.Equals("heh"));
            }
        }

        [Fact]
        [Points("8-7.1")]
        public void TestEqualsSamePlateDifferentObject()
        {
            using (StringWriter sw = new StringWriter())
            {
                LicensePlate li1 = new LicensePlate("FI", "ABC-123");
                LicensePlate li2 = new LicensePlate("FI", "ABC-123");

                // Assert
                Assert.True(li1.Equals(li2));
            }
        }

        [Fact]
        [Points("8-7.1")]
        public void TestEqualsSamePlateSameObject()
        {
            using (StringWriter sw = new StringWriter())
            {
                LicensePlate li1 = new LicensePlate("FI", "ABC-123");
                LicensePlate li2 = new LicensePlate("FI", "ABC-123");

                // Assert
                Assert.True(li1.Equals(li2));
            }
        }

        [Fact]
        [Points("8-7.1")]
        public void TestHashCodeSameObject()
        {
            using (StringWriter sw = new StringWriter())
            {
                LicensePlate li1 = new LicensePlate("FI", "ABC-123");

                // Assert
                Assert.Equal(li1.GetHashCode(), li1.GetHashCode());
            }
        }

        [Fact]
        [Points("8-7.1")]
        public void TestHashCodeDifferentObjectSamePlate()
        {
            using (StringWriter sw = new StringWriter())
            {
                LicensePlate li1 = new LicensePlate("FI", "ABC-123");
                LicensePlate li2 = new LicensePlate("FI", "ABC-123");

                // Assert
                Assert.Equal(li1.GetHashCode(), li2.GetHashCode());
            }
        }

        [Fact]
        [Points("8-7.1")]
        public void TestHashCodeDifferentObjectDifferentPlate()
        {
            using (StringWriter sw = new StringWriter())
            {
                LicensePlate li1 = new LicensePlate("FI", "ABC-123");
                LicensePlate li2 = new LicensePlate("FI", "UXE-465");

                // Assert
                Assert.NotEqual(li1.GetHashCode(), li2.GetHashCode());
            }
        }


        [Fact]
        [Points("8-7.2")]
        public void AddShouldReturnTrue()
        {
            Assert.True(new VehicleRegistry().Add(new LicensePlate("FI", "ABC-123"), "Arto"));
        }

        [Fact]
        [Points("8-7.2")]
        public void AddShouldReturnFalse()
        {
            VehicleRegistry register = new VehicleRegistry();
            LicensePlate li5 = new LicensePlate("D", "B WQ-433");
            register.Add(li5, "Jürgen");
            Assert.False(register.Add(new LicensePlate("D", "B WQ-433"), "Arto"));
        }

        [Fact]
        [Points("8-7.2")]
        public void GetShouldReturnOwner()
        {
            VehicleRegistry register = new VehicleRegistry();
            LicensePlate li5 = new LicensePlate("D", "B WQ-433");
            LicensePlate li2 = new LicensePlate("FI", "UXE-465");
            register.Add(li2, "Arto");
            register.Add(li5, "Jürgen");
            Assert.Equal("Jürgen", register.Get(li5));
        }

        [Fact]
        [Points("8-7.2")]
        public void GetShouldReturnNotOwner()
        {
            VehicleRegistry register = new VehicleRegistry();
            LicensePlate li5 = new LicensePlate("D", "B WQ-433");
            LicensePlate li2 = new LicensePlate("FI", "UXE-465");
            register.Add(li2, "Arto");
            Assert.NotEqual("Arto", register.Get(li5));
        }

        [Fact]
        [Points("8-7.2")]
        public void RemoveShouldReturnTrue()
        {
            VehicleRegistry register = new VehicleRegistry();
            LicensePlate li5 = new LicensePlate("D", "B WQ-433");
            LicensePlate li2 = new LicensePlate("FI", "UXE-465");
            register.Add(li2, "Arto");
            Assert.True(register.Remove(li2));
        }

        [Fact]
        [Points("8-7.2")]
        public void RemoveShouldReturnFalse()
        {
            VehicleRegistry register = new VehicleRegistry();
            LicensePlate li5 = new LicensePlate("D", "B WQ-433");
            LicensePlate li2 = new LicensePlate("FI", "UXE-465");
            register.Add(li2, "Arto");
            Assert.False(register.Remove(li5));
        }

        [Fact]
        [Points("8-7.2")]
        public void ExampleShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                LicensePlate li1 = new LicensePlate("FI", "ABC-123");
                LicensePlate li2 = new LicensePlate("FI", "UXE-465");
                LicensePlate li3 = new LicensePlate("D", "B WQ-431");
                LicensePlate li4 = new LicensePlate("D", "B WQ-432");
                LicensePlate li5 = new LicensePlate("D", "B WQ-433");

                VehicleRegistry register = new VehicleRegistry();

                register.Add(li1, "Arto");
                register.Add(li2, "Arto");
                register.Add(li3, "Jürgen");
                register.Add(li4, "Jürgen");
                register.Add(li5, "Jürgen");

                Console.WriteLine("Plates:");
                register.PrintLicensePlates();

                Console.WriteLine("Owners:");
                register.PrintOwners();

                Console.SetOut(stdout);
                string example = @"Plates:
FI ABC-123
FI UXE-465
D B WQ-431
D B WQ-432
D B WQ-433
Owners:
Arto
Jürgen
";
                Assert.Equal(example, sw.ToString());
            }
        }
    }
}
