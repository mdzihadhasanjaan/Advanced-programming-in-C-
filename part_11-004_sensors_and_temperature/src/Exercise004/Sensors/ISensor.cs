namespace Exercise004
{
  public interface ISensor
  {
    bool IsOn();    // returns true if the sensor is on
    void SetOn();      // sets the sensor on
    void SetOff();     // sets the sensor off
    int Read();        // returns the value of the sensor if it's on
                       // if the sensor is not on throw a IllegalStateException
  }

  public class StandardSensor : ISensor
  {
    public int value;
    public StandardSensor(int value)
    {
      this.value = value;
    }

    public bool IsOn()
    {
      return true;
    }

    public void SetOn()
    {

    }

    public void SetOff()
    {

    }

    public int Read()
    {
      return this.value;
    }
  }

  public class TemperatureSensor: ISensor
  {
    public bool isSensorOn;
    public Random random;
    public TemperatureSensor()
    {
      isSensorOn = false;
      random = new Random();
    }

    public bool IsOn()
    {
      return isSensorOn;
    }

    public void SetOn()
    {
      isSensorOn = true;
    }

    public void SetOff()
    {
      isSensorOn = false;
    }

    public int Read()
    {
      if(!IsOn())
      {
         throw new InvalidOperationException("Temperature sensor is off.");
      }

      int temperature = random.Next(-30, 31);
      return temperature;
    }
  }
}