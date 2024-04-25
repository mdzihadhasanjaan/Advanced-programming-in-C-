namespace ProgramTests
{
    using System;
    using System.IO;
    using Xunit;
    using Exercise004;
    using TestMyCode.CSharp.API.Attributes;
    public partial class ProgramTest
    {


        [Fact]
        [Points("11-4.1")]
        public void StandardSensorTenShouldWork()
        {
            StandardSensor ten = new StandardSensor(10);
            Assert.True(ten.IsOn());
            Assert.Equal(10, ten.Read());
            ten.SetOff();
            Assert.True(ten.IsOn());
        }

        [Fact]
        [Points("11-4.1")]
        public void StandardSensorFiveShouldWork()
        {
            StandardSensor five = new StandardSensor(5);
            Assert.True(five.IsOn());
            Assert.Equal(5, five.Read());
            five.SetOff();
            Assert.True(five.IsOn());
        }

        [Fact]
        [Points("11-4.1")]
        public void StandardSensorRandomShouldWork()
        {
            Random rand = new Random();
            int next = rand.Next(-10, 100);
            StandardSensor sensor = new StandardSensor(next);
            Assert.Equal(next, sensor.Read());
        }

        [Fact]
        [Points("11-4.2")]
        public void TemperatureSensorAllMethodsShouldWork()
        {
            TemperatureSensor temperatureSensor = new TemperatureSensor();
            Assert.False(temperatureSensor.IsOn());
            temperatureSensor.SetOn();
            Assert.True(temperatureSensor.IsOn());
            temperatureSensor.SetOff();
            Assert.False(temperatureSensor.IsOn());
            Assert.Throws<InvalidOperationException>(() => temperatureSensor.Read());
        }

        [Fact]
        [Points("11-4.2")]
        public void TemperatureSensorReadShouldWork()
        {
            TemperatureSensor temperatureSensor = new TemperatureSensor();
            temperatureSensor.SetOn();
            Assert.InRange(temperatureSensor.Read(), -30, 30);
        }

        [Fact]
        [Points("11-4.2")]
        public void TemperatureSensorShouldTurnOnAndOff()
        {
            TemperatureSensor temperatureSensor = new TemperatureSensor();
            temperatureSensor.SetOn();
            Assert.InRange(temperatureSensor.Read(), -30, 30);
            temperatureSensor.SetOff();
            Assert.Throws<InvalidOperationException>(() => temperatureSensor.Read());
        }
    }
}
