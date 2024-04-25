namespace ProgramTests
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using Xunit;
    using Exercise005;
    using TestMyCode.CSharp.API.Attributes;

    public partial class ProgramTest
    {

        [Fact]
        [Points("10-5.1")]
        public void CardImplementsIComparable()
        {
            Assert.True(typeof(IComparable<Card>).IsAssignableFrom(typeof(Card)));
        }


        [Fact]
        [Points("10-5.1")]
        public void ExampleShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                // Save a reference to the standard output.
                TextWriter stdout = Console.Out;

                // Redirect standard output to variable.
                Console.SetOut(sw);
                Card first = new Card(2, Suit.Diamond);
                Card second = new Card(14, Suit.Spade);
                Card third = new Card(12, Suit.Heart);

                Console.WriteLine(first);
                Console.WriteLine(second);
                Console.WriteLine(third);
                Console.SetOut(stdout);
                string comparison = "Diamond 2\nSpade A\nHeart Q\n";
                Assert.Equal(comparison, sw.ToString());
            }
        }
        [Fact]
        [Points("10-5.1")]
        public void TestAceOfSpades()
        {
            Card card = new Card(14, Suit.Spade);
            Assert.Equal("Spade A", card.ToString());
        }

        [Fact]
        [Points("10-5.1")]
        public void TestKingOfHearts()
        {
            Card card = new Card(13, Suit.Heart);
            Assert.Equal("Heart K", card.ToString());
        }

        [Fact]
        [Points("10-5.1")]
        public void TestJackOfDiamonds()
        {
            Card card = new Card(11, Suit.Diamond);
            Assert.Equal("Diamond J", card.ToString());
        }

        [Fact]
        [Points("10-5.1")]
        public void TestQueenOfClugs()
        {
            Card card = new Card(12, Suit.Club);
            Assert.Equal("Club Q", card.ToString());
        }


        [Fact]
        [Points("10-5.2")]
        public void Example2ShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                // Save a reference to the standard output.
                TextWriter stdout = Console.Out;

                // Redirect standard output to variable.
                Console.SetOut(sw);
                Card first = new Card(2, Suit.Club);
                Card second = new Card(14, Suit.Spade);
                Card third = new Card(12, Suit.Heart);
                Card fourth = new Card(14, Suit.Heart);
                Card fifth = new Card(12, Suit.Diamond);

                List<Card> list = new List<Card> { first, second, third, fourth, fifth };
                list.Sort();
                list.ForEach(Console.WriteLine);
                string comparison = "Club 2\nDiamond Q\nHeart Q\nHeart A\nSpade A\n";
                Assert.Equal(comparison, sw.ToString());
            }
        }

        [Fact]
        [Points("10-5.2")]
        public void TestCompareClubsToSpades()
        {
            Assert.Equal(-1, Math.Sign(new Card(2, Suit.Club).CompareTo(new Card(2, Suit.Spade))));
        }

        [Fact]
        [Points("10-5.2")]
        public void TestCompareSpadeToHeart()
        {
            Assert.Equal(1, Math.Sign(new Card(12, Suit.Spade).CompareTo(new Card(12, Suit.Heart))));
        }

        [Fact]
        [Points("10-5.2")]
        public void TestCompareEqual()
        {
            Assert.Equal(0, Math.Sign(new Card(9, Suit.Spade).CompareTo(new Card(9, Suit.Spade))));
        }

        [Fact]
        [Points("10-5.2")]
        public void TestCompareHeartToHeart()
        {
            Assert.Equal(-1, Math.Sign(new Card(8, Suit.Heart).CompareTo(new Card(9, Suit.Heart))));
        }

        [Fact]
        [Points("10-5.3")]
        public void Example3ShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                // Save a reference to the standard output.
                TextWriter stdout = Console.Out;

                // Redirect standard output to variable.
                Console.SetOut(sw);
                Hand hand = new Hand();

                hand.Add(new Card(2, Suit.Diamond));
                hand.Add(new Card(14, Suit.Spade));
                hand.Add(new Card(12, Suit.Heart));
                hand.Add(new Card(2, Suit.Spade));

                hand.Print();
                string comparison = "Diamond 2\nSpade A\nHeart Q\nSpade 2\n";
                Assert.Equal(comparison, sw.ToString());
            }
        }

        [Fact]
        [Points("10-5.3")]
        public void DiamondHandShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                // Save a reference to the standard output.
                TextWriter stdout = Console.Out;

                // Redirect standard output to variable.
                Console.SetOut(sw);
                Hand hand = new Hand();

                hand.Add(new Card(2, Suit.Diamond));
                hand.Add(new Card(14, Suit.Diamond));
                hand.Add(new Card(12, Suit.Diamond));
                hand.Add(new Card(11, Suit.Diamond));

                hand.Print();
                string comparison = "Diamond 2\nDiamond A\nDiamond Q\nDiamond J\n";
                Assert.Equal(comparison, sw.ToString());
            }
        }

        [Fact]
        [Points("10-5.3")]
        public void ReorderedCardsShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                // Save a reference to the standard output.
                TextWriter stdout = Console.Out;

                // Redirect standard output to variable.
                Console.SetOut(sw);
                Hand hand = new Hand();

                hand.Add(new Card(14, Suit.Spade));
                hand.Add(new Card(12, Suit.Heart));
                hand.Add(new Card(2, Suit.Diamond));
                hand.Add(new Card(2, Suit.Spade));

                hand.Print();
                string comparison = "Spade A\nHeart Q\nDiamond 2\nSpade 2\n";
                Assert.Equal(comparison, sw.ToString());
            }
        }

        [Fact]
        [Points("10-5.3")]
        public void HandHasNoDuplicateCards()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                // Save a reference to the standard output.
                TextWriter stdout = Console.Out;

                // Redirect standard output to variable.
                Console.SetOut(sw);
                Hand hand = new Hand();

                hand.Add(new Card(4, Suit.Diamond));
                hand.Add(new Card(14, Suit.Diamond));
                hand.Add(new Card(12, Suit.Diamond));
                hand.Add(new Card(11, Suit.Diamond));
                hand.Add(new Card(4, Suit.Diamond));
                hand.Add(new Card(14, Suit.Diamond));
                hand.Add(new Card(12, Suit.Diamond));
                hand.Add(new Card(11, Suit.Diamond));
                hand.Add(new Card(4, Suit.Diamond));
                hand.Add(new Card(14, Suit.Diamond));
                hand.Add(new Card(12, Suit.Diamond));
                hand.Add(new Card(11, Suit.Diamond));
                hand.Add(new Card(4, Suit.Diamond));
                hand.Add(new Card(14, Suit.Diamond));
                hand.Add(new Card(12, Suit.Diamond));
                hand.Add(new Card(11, Suit.Diamond));

                hand.Print();
                string comparison = "Diamond 4\nDiamond A\nDiamond Q\nDiamond J\n";
                Assert.Equal(comparison, sw.ToString());
            }
        }

        [Fact]
        [Points("10-5.4")]
        public void Example4ShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                // Save a reference to the standard output.
                TextWriter stdout = Console.Out;

                // Redirect standard output to variable.
                Console.SetOut(sw);
                Hand hand = new Hand();

                hand.Add(new Card(2, Suit.Diamond));
                hand.Add(new Card(14, Suit.Spade));
                hand.Add(new Card(12, Suit.Heart));
                hand.Add(new Card(2, Suit.Spade));

                hand.Sort();
                hand.Print();
                string comparison = "Diamond 2\nSpade 2\nHeart Q\nSpade A\n";
                Assert.Equal(comparison, sw.ToString());
            }
        }

        [Fact]
        [Points("10-5.4")]
        public void AnotherOrderBeforeSortShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                // Save a reference to the standard output.
                TextWriter stdout = Console.Out;

                // Redirect standard output to variable.
                Console.SetOut(sw);
                Hand hand = new Hand();

                hand.Add(new Card(12, Suit.Heart));
                hand.Add(new Card(2, Suit.Diamond));
                hand.Add(new Card(14, Suit.Spade));
                hand.Add(new Card(2, Suit.Spade));

                hand.Sort();
                hand.Print();
                string comparison = "Diamond 2\nSpade 2\nHeart Q\nSpade A\n";
                Assert.Equal(comparison, sw.ToString());
            }
        }

        [Fact]
        [Points("10-5.4")]
        public void HandOfClubsSortShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                // Save a reference to the standard output.
                TextWriter stdout = Console.Out;

                // Redirect standard output to variable.
                Console.SetOut(sw);
                Hand hand = new Hand();

                hand.Add(new Card(12, Suit.Club));
                hand.Add(new Card(2, Suit.Club));
                hand.Add(new Card(14, Suit.Club));
                hand.Add(new Card(8, Suit.Club));

                hand.Sort();
                hand.Print();
                string comparison = "Club 2\nClub 8\nClub Q\nClub A\n";
                Assert.Equal(comparison, sw.ToString());
            }
        }

        [Fact]
        [Points("10-5.4")]
        public void NoDuplicatesWithSort()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                // Save a reference to the standard output.
                TextWriter stdout = Console.Out;

                // Redirect standard output to variable.
                Console.SetOut(sw);
                Hand hand = new Hand();

                hand.Add(new Card(4, Suit.Diamond));
                hand.Add(new Card(14, Suit.Diamond));
                hand.Add(new Card(12, Suit.Diamond));
                hand.Add(new Card(11, Suit.Diamond));
                hand.Add(new Card(4, Suit.Diamond));
                hand.Add(new Card(14, Suit.Diamond));
                hand.Add(new Card(12, Suit.Diamond));
                hand.Add(new Card(11, Suit.Diamond));
                hand.Add(new Card(4, Suit.Diamond));
                hand.Add(new Card(14, Suit.Diamond));
                hand.Add(new Card(12, Suit.Diamond));
                hand.Add(new Card(11, Suit.Diamond));
                hand.Add(new Card(4, Suit.Diamond));
                hand.Add(new Card(14, Suit.Diamond));
                hand.Add(new Card(12, Suit.Diamond));
                hand.Add(new Card(11, Suit.Diamond));

                hand.Sort();
                hand.Print();

                string comparison = "Diamond 4\nDiamond J\nDiamond Q\nDiamond A\n";
                Assert.Equal(comparison, sw.ToString());
            }
        }


        [Fact]
        [Points("10-5.5")]
        public void HandImplementsIComparable()
        {
            Assert.True(typeof(IComparable<Hand>).IsAssignableFrom(typeof(Hand)));
        }

        [Fact]
        [Points("10-5.5")]
        public void Example5ShouldWork()
        {
            using (StringWriter sw = new StringWriter())
            {
                sw.NewLine = "\n";
                // Save a reference to the standard output.
                TextWriter stdout = Console.Out;

                // Redirect standard output to variable.
                Console.SetOut(sw);
                Hand hand1 = new Hand();

                hand1.Add(new Card(2, Suit.Diamond));
                hand1.Add(new Card(14, Suit.Spade));
                hand1.Add(new Card(12, Suit.Heart));
                hand1.Add(new Card(2, Suit.Spade));

                Hand hand2 = new Hand();

                hand2.Add(new Card(11, Suit.Diamond));
                hand2.Add(new Card(11, Suit.Spade));
                hand2.Add(new Card(11, Suit.Heart));

                int comparison = hand1.CompareTo(hand2);

                if (comparison < 0)
                {
                    Console.WriteLine("better hand is");
                    hand2.Print();
                }
                else if (comparison > 0)
                {
                    Console.WriteLine("better hand is");
                    hand1.Print();
                }
                else
                {
                    Console.WriteLine("hands are equal");
                }
                string compare = "better hand is\nDiamond J\nSpade J\nHeart J\n";
                Assert.Equal(compare, sw.ToString());
            }
        }

        [Fact]
        [Points("10-5.5")]
        public void HandComparisonShouldWork()
        {
            Hand hand1 = new Hand();
            hand1.Add(new Card(2, Suit.Diamond));
            hand1.Add(new Card(14, Suit.Spade));
            hand1.Add(new Card(12, Suit.Heart));
            hand1.Add(new Card(2, Suit.Spade));

            Hand hand2 = new Hand();

            hand2.Add(new Card(11, Suit.Diamond));
            hand2.Add(new Card(11, Suit.Spade));
            hand2.Add(new Card(11, Suit.Heart));
            Assert.Equal(-1, Math.Sign(hand1.CompareTo(hand2)));
        }

        [Fact]
        [Points("10-5.5")]
        public void HandComparisonShouldWorkOtherWay()
        {
            Hand hand1 = new Hand();
            hand1.Add(new Card(2, Suit.Diamond));
            hand1.Add(new Card(14, Suit.Spade));
            hand1.Add(new Card(12, Suit.Heart));
            hand1.Add(new Card(2, Suit.Spade));

            Hand hand2 = new Hand();

            hand2.Add(new Card(11, Suit.Diamond));
            hand2.Add(new Card(11, Suit.Spade));
            hand2.Add(new Card(11, Suit.Heart));
            Assert.Equal(1, Math.Sign(hand2.CompareTo(hand1)));
        }

        [Fact]
        [Points("10-5.5")]
        public void HandComparisonShouldWorkEqualValues()
        {
            Hand hand1 = new Hand();
            hand1.Add(new Card(5, Suit.Diamond));
            hand1.Add(new Card(14, Suit.Spade));
            hand1.Add(new Card(12, Suit.Heart));
            hand1.Add(new Card(2, Suit.Spade));

            Hand hand2 = new Hand();

            hand2.Add(new Card(11, Suit.Diamond));
            hand2.Add(new Card(11, Suit.Spade));
            hand2.Add(new Card(11, Suit.Heart));
            Assert.Equal(0, Math.Sign(hand2.CompareTo(hand1)));
        }
    }

}
