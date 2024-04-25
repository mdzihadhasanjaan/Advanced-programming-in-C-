
namespace Exercise001
{
    using System;
    public class Die
    {
        private Random random;
        private int numberOfFaces;

        public Die(int numberOfFaces)
        {
            this.random = new Random();
            // Initialize the value of numberOfFaces here
            this.numberOfFaces = numberOfFaces;
        }
        public int ThrowDie()
        {
            // generate a random number which may be any number
            // between one and the number of faces, and then return it
            int number = random.Next(1, numberOfFaces);
            return number;
        }
    }
}