namespace Exercise003
{
    using System;
    public class Book : IComparable<Book>
    {

        public string name { get; set; }
        public int ageRecommendation { get; set; }

        public Book(string name, int ageRecommendation)
        {
            this.name = name;
            this.ageRecommendation = ageRecommendation;
        }


        public override string ToString()
        {
            // Don't touch this
            return this.name + " (recommended for " + this.ageRecommendation + " year-olds or older)";
        }


        public int CompareTo(Book other)
        {
            int ageComparison = this.ageRecommendation.CompareTo(other.ageRecommendation);  
            return ageComparison == 0 ? this.name.CompareTo(other.name) : ageComparison;  
        }

    }
}