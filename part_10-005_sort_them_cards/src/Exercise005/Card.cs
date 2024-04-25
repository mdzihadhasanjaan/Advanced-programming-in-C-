
namespace Exercise005
{
    using System;
    public class Card : IComparable<Card>
    {
        public int value { get; }
        public Suit suit { get; }

        public Card(int value, Suit suit)
        {
            this.value = value;
            this.suit = suit;
        }

        public override string ToString()
        {
            string stringValue = (value >= 2 && value <= 10) ? value.ToString() :
                     (value == 11) ? "J" :
                     (value == 12) ? "Q" :
                     (value == 13) ? "K" :
                     (value == 14) ? "A" : "";

            return $"{this.suit} {stringValue}";
        }

        public int CompareTo(Card another)
        {
            int comparison = this.value.CompareTo(another.value);
            return comparison != 0 ? comparison : this.suit.CompareTo(another.suit);
        }


        public override bool Equals(object compared)
        {
            // if the variables are located in the same position, they are equal
            if (this == compared)
            {
                return true;
            }

            // if the compared object is null or not of type Card, the objects are not equal
            if ((compared == null) || !this.GetType().Equals(compared.GetType()))
            {
                return false;
            }
            else
            {
                // convert the object to a Card object
                Card comparedCard = (Card)compared;

                // if the values of the object variables are equal, the objects are, too
                return this.value == comparedCard.value && this.suit == comparedCard.suit;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.value, this.suit.GetHashCode());
        }

    }

    public class Hand : IComparable<Hand>
    {
        private List<Card> cards = new List<Card>();

        public void Add(Card card)
        {
            if (!cards.Contains(card))
            {
                cards.Add(card);
            }
        }

        public void Print()
        {
            foreach (Card card in cards)
            {
                Console.WriteLine(card);
            }
        }

        public void Sort()
        {
            cards.Sort();
        }

        public int CompareTo(Hand other)
        {
            int sumThis = cards.Sum(card => card.value);
            int sumOther = other.cards.Sum(card => card.value);

            return sumThis.CompareTo(sumOther);
        }
    }
}


