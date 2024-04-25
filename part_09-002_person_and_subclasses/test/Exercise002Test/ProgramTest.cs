namespace ProgramTests
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using Xunit;
    using Exercise002;
    using TestMyCode.CSharp.API.Attributes;
    public partial class ProgramTest
    {
        [Fact]
        [Points("9-2.1")]
        public void PersonExampleShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Person ada = new Person("Ada Lovelace", "24 Maddox St. London W1S 2QN");
                Person esko = new Person("Esko Ukkonen", "Mannerheimintie 15 00100 Helsinki");
                Console.WriteLine(ada);
                Console.WriteLine(esko);
                Console.SetOut(stdout);
                string example = "Ada Lovelace, 24 Maddox St. London W1S 2QN\nEsko Ukkonen, Mannerheimintie 15 00100 Helsinki\n";
                Assert.Equal(example, sw.ToString());
            }
        }

        [Fact]
        [Points("9-2.1")]
        public void OtherPeopleShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Person heikki = new Person("Heikki Ahonen", "Talonpojankatu 2 67100 Kokkola");
                Person mikko = new Person("Mikko Mallikas", "Mallitie 4 99999 Korvatunturi");
                Console.WriteLine(heikki);
                Console.WriteLine(mikko);
                Console.SetOut(stdout);
                string example = "Heikki Ahonen, Talonpojankatu 2 67100 Kokkola\nMikko Mallikas, Mallitie 4 99999 Korvatunturi\n";
                Assert.Equal(example, sw.ToString());
            }
        }


        [Fact]
        [Points("9-2.2")]
        public void StudentExampleShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Student ollie = new Student("Ollie", "6381 Hollywood Blvd. Los Angeles 90028");
                Console.WriteLine(ollie);
                ollie.Study();
                Console.WriteLine(ollie);
                string example = "Ollie, 6381 Hollywood Blvd. Los Angeles 90028 credits: 0\nOllie, 6381 Hollywood Blvd. Los Angeles 90028 credits: 1\n";
                Assert.Equal(example, sw.ToString());
            }
        }

        [Fact]
        [Points("9-2.2")]
        public void StudentStudiesMoreShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Student mikko = new Student("Mikko Mallikas", "Mallitie 4 99999 Korvatunturi");
                Random random = new Random();
                int rand = random.Next(1, 1000);
                for (int i = 0; i < rand; i++)
                {
                    mikko.Study();
                }
                Console.WriteLine(mikko);
                string example = $"Mikko Mallikas, Mallitie 4 99999 Korvatunturi credits: {rand}\n";
                Assert.Equal(example, sw.ToString());
            }
        }

        [Fact]
        [Points("9-2.3")]
        public void OtherTeachersShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Teacher heikki = new Teacher("Heikki Ahonen", "Talonpojankatu 2 67100 Kokkola", 9999);
                Teacher mikko = new Teacher("Mikko Mallikas", "Mallitie 4 99999 Korvatunturi", 1345);
                Console.WriteLine(heikki);
                Console.WriteLine(mikko);
                Console.SetOut(stdout);
                string example = "Heikki Ahonen, Talonpojankatu 2 67100 Kokkola salary 9999 per month\nMikko Mallikas, Mallitie 4 99999 Korvatunturi salary 1345 per month\n";
                Assert.Equal(example, sw.ToString());
            }
        }

        [Fact]
        [Points("9-2.3")]
        public void TeacherExampleShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                TextWriter stdout = Console.Out;
                Console.SetOut(sw);
                Teacher ada = new Teacher("Ada Lovelace", "24 Maddox St. London W1S 2QN", 1200);
                Teacher esko = new Teacher("Esko Ukkonen", "Mannerheimintie 15 00100 Helsinki", 5400);
                Console.WriteLine(ada);
                Console.WriteLine(esko);
                Console.SetOut(stdout);
                string example = "Ada Lovelace, 24 Maddox St. London W1S 2QN salary 1200 per month\nEsko Ukkonen, Mannerheimintie 15 00100 Helsinki salary 5400 per month\n";
                Assert.Equal(example, sw.ToString());
            }
        }
    }
}
