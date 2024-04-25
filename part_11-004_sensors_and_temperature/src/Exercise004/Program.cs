
namespace Exercise004
{
    using System;
    public class Program
    {
        public static void Main(string[] args)
        {
            //Section 01
            StandardSensor ten = new StandardSensor(10);
            StandardSensor minusFive = new StandardSensor(-5);

            Console.WriteLine(ten.Read());
            Console.WriteLine(minusFive.Read());

            Console.WriteLine(ten.IsOn());
            ten.SetOff();
            Console.WriteLine(ten.IsOn());

            //Seciton 02
            TemperatureSensor temperatureSensor = new TemperatureSensor();
            temperatureSensor.SetOn();
            Console.WriteLine(temperatureSensor.Read());
        }
    }
}

