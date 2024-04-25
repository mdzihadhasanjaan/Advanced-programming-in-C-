
namespace Exercise003
{
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            // Comment out a line to test your exceptions, the uncommented is proper person

            Person person1 = new Person("Matthew", 40);
            Person person2 = new Person("", 40);
            Person person3 = new Person(null, 40);
            Person person4 = new Person("Matthew Michael Bartholomew, Son of Matthew Jameson Junior", 40);
            Person person5 = new Person("Matthew", 121);
            Person person6 = new Person("Matthew", -1);


        }
    }
}



