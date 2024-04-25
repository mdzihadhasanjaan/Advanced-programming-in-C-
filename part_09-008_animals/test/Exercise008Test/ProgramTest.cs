namespace ProgramTests
{
    using System;
    using System.IO;
    using Xunit;
    using Exercise008;
    using TestMyCode.CSharp.API.Attributes;
    public partial class ProgramTest
    {

        [Fact]
        [Points("9-8.1")]
        public void DogExampleShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Dog dog = new Dog();
                Console.SetOut(sw);
                dog.Bark();
                dog.Eat();
                Dog fido = new Dog("Fido");
                fido.Bark();
                Console.SetOut(stdout);
                string example = "Dog barks\nDog eats\nFido barks\n";
                Assert.Equal(example, sw.ToString());
            }
        }

        [Fact]
        [Points("9-8.1")]
        public void DogShouldSleep()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Dog dog = new Dog();
                Console.SetOut(sw);
                dog.Sleep();
                Console.SetOut(stdout);
                string example = "Dog sleeps\n";
                Assert.Equal(example, sw.ToString());
            }
        }

        [Fact]
        [Points("9-8.1")]
        public void AnotherDogShouldBark()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Dog rex = new Dog("Rex");
                rex.Bark();
                Console.SetOut(stdout);
                string example = "Rex barks\n";
                Assert.Equal(example, sw.ToString());
            }
        }

        [Fact]
        [Points("9-8.1")]
        public void CatExampleShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Cat cat = new Cat();
                cat.Purr();
                cat.Eat();
                Cat garfield = new Cat("Garfield");
                garfield.Purr();
                Console.SetOut(stdout);
                string example = "Cat purrs\nCat eats\nGarfield purrs\n";
                Assert.Equal(example, sw.ToString());
            }
        }

        [Fact]
        [Points("9-8.1")]
        public void CatSleepShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Cat cat = new Cat();
                cat.Sleep();
                Console.SetOut(stdout);
                string example = "Cat sleeps\n";
                Assert.Equal(example, sw.ToString());
            }
        }

        [Fact]
        [Points("9-8.1")]
        public void AnotherCatShouldMeow()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Cat fluffers = new Cat("Fluffer");
                fluffers.Purr();
                Console.SetOut(stdout);
                string example = "Fluffer purrs\n";
                Assert.Equal(example, sw.ToString());
            }
        }

        [Fact]
        [Points("9-8.2")]
        public void NoisyExampleShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                INoiseCapable noisyDog = new Dog();
                noisyDog.MakeNoise();
                INoiseCapable noisyCat = new Cat("Garfield");
                noisyCat.MakeNoise();
                Cat c = (Cat)noisyCat;
                c.Purr();
                Console.SetOut(stdout);
                string example = "Dog barks\nGarfield purrs\nGarfield purrs\n";
                Assert.Equal(example, sw.ToString());
            }
        }

        [Fact]
        [Points("9-8.2")]
        public void MoreNoiseShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                INoiseCapable noisyDog = new Dog();
                noisyDog.MakeNoise();
                INoiseCapable noisyCat = new Cat("Fluffers");
                noisyCat.MakeNoise();
                Cat c = (Cat)noisyCat;
                c.Purr();
                Console.SetOut(stdout);
                string example = "Dog barks\nFluffers purrs\nFluffers purrs\n";
                Assert.Equal(example, sw.ToString());
            }
        }

        [Fact]
        [Points("9-8.2")]
        public void NoisyDogBarks()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                INoiseCapable noisyDog = new Dog("Beanie");
                noisyDog.MakeNoise();
                Console.SetOut(stdout);
                string example = "Beanie barks\n";
                Assert.Equal(example, sw.ToString());
            }
        }

        [Fact]
        [Points("9-8.2")]
        public void NoisyCatMakesNoise()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                INoiseCapable noisyCat = new Cat("Potato");
                noisyCat.MakeNoise();
                Console.SetOut(stdout);
                string example = "Potato purrs\n";
                Assert.Equal(example, sw.ToString());
            }
        }

        [Fact]
        [Points("9-8.2")]
        public void NoisyCatPurrs()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                INoiseCapable noisyCat = new Cat("Monster");
                Cat c = (Cat)noisyCat;
                c.Purr();
                Console.SetOut(stdout);
                string example = "Monster purrs\n";
                Assert.Equal(example, sw.ToString());
            }
        }

    }
}
