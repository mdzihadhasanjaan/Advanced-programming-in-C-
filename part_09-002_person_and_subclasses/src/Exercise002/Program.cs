namespace Exercise002
{
    using System;

    public class Person
    {
        public string Name {get; set;}
        public string Address {get; set;}

        public Person(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public override string ToString()
        {
            return $"{Name}, {Address}";
        }
    }

    public class Student : Person
    {
        public int Study_credits {get; set;}

        public Student(string name, string address) : base(name, address)
        {
            Study_credits = 0;
        }

        public void Study()
        {
            Study_credits++;
        }

        public override string ToString()
        {
            return $"{Name}, {Address} credits: {Study_credits}";
        }
    }

    public class Teacher : Person
    {
        public int Salary {get; set;}

        public Teacher(string name, string address, int salary) : base(name, address)
        {
            Salary = salary;
        }

        public override string ToString()
        {
            return $"{base.ToString()} salary {Salary} per month";
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            // Person ada = new Person("Ada Lovelace", "24 Maddox St. London W1S 2QN");
            // Person esko = new Person("Esko Ukkonen", "Mannerheimintie 15 00100 Helsinki");
            // Console.WriteLine(ada);
            // Console.WriteLine(esko);

            Student ollie = new Student("Ollie", "6381 Hollywood Blvd. Los Angeles 90028");
            Console.WriteLine(ollie);
            ollie.Study();
            Console.WriteLine(ollie);

            Teacher ada = new Teacher("Ada Lovelace", "24 Maddox St. London W1S 2QN", 1200);
            Teacher esko = new Teacher("Esko Ukkonen", "Mannerheimintie 15 00100 Helsinki", 5400);
            Console.WriteLine(ada);
            Console.WriteLine(esko);
        }
    }
}