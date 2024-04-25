
namespace Exercise003
{
    using System;
    public class Person
    {

        public string name { get; }
        public int age { get; }

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;

            if (string.IsNullOrWhiteSpace(name) || name.Length > 40)
            {
                throw new ArgumentException("Name must not be null, empty, or exceed 40 characters.");
            }

            if (age < 0 || age > 120)
            {
                throw new ArgumentException("Age must be between 0 and 120.");
            }
        }
    }
}