namespace Exercise008
{
    using System;

    public interface INoiseCapable
    {
        public void MakeNoise();
    }

    public abstract class Animal
    {
        public string name;
        public Animal(string name)
        {
            this.name = name;
        }

        public void Eat()
        {
            Console.WriteLine($"{name} eats");
        }

        public void Sleep()
        {
            Console.WriteLine($"{name} sleeps");
        }
    }

    public class Dog : Animal, INoiseCapable
    {
        public Dog(string name) : base(name)
        {

        }

        public Dog() : this("Dog")
        {

        }

        public void Bark()
        {
            Console.WriteLine($"{name} barks");
        }

        public void MakeNoise()
        {
            Bark();
        }
    }

    public class Cat : Animal, INoiseCapable
    {
        public Cat(string name) : base(name)
        {

        }

        public Cat() : this("Cat")
        {

        }

        public void Purr()
        {
            Console.WriteLine($"{name} purrs");
        }

        public void MakeNoise()
        {
            Purr();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Dog dog = new Dog();
            dog.Bark();
            dog.Eat();
            dog.Sleep();

            Dog fido = new Dog("Fido");
            fido.Bark();

            Cat cat = new Cat();
            cat.Purr();
            cat.Eat();
            cat.Sleep();

            Cat garfield = new Cat("Garfield");
            garfield.Purr();

            INoiseCapable doggy = new Dog();
            doggy.MakeNoise();

            INoiseCapable catty = new Cat("Garfield");
            catty.MakeNoise();

            Cat c = (Cat)catty;
            c.Purr();
        }
    }
}