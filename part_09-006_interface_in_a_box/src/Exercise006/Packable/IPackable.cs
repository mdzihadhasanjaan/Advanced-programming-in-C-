namespace Exercise006
{
  public interface IPackable
  {
    int Weight();
  }

  public class Book : IPackable
  {
    private string author;
    private string name;
    private int pub_year;

    public Book(string author, string name, int pub_year)
    {
      this.author = author;
      this.name = name;
      this.pub_year = pub_year;
    }

    public int Weight()
    {
      return 1;
    }

    public override string ToString()
    {
      return $"{this.author}: {this.name} ({this.pub_year})";
    }
  }

  public class Furniture : IPackable
  {
    private string Furn_type;
    private string Color;
    private int weight;

    public Furniture(string type, string color, int weight)
    {
      Furn_type = type;
      Color = color;
      this.weight = weight;
    }

    public int Weight()
    {
      return this.weight;
    }

    public override string ToString()
    {
      return $"{Color} {Furn_type} - weight {weight} kg";
    }
  }

  public class Box : IPackable
  {
    private List<IPackable> items;
    private int maxCapacity;

    public Box(int maxCapacity)
    {
      this.maxCapacity = maxCapacity;
      items = new List<IPackable>();
    }

    public int Weight()
    {
      int totalWeight = 0;
      foreach (var item in items)
      {
        totalWeight += item.Weight();
      }

      return totalWeight;
    }

    public void Add(IPackable item)
    {
      if (Weight() + item.Weight() <= maxCapacity)
      {
        items.Add(item);
      }
    }

    public override string ToString()
    {
      return $"{items.Count} items, total weight {Weight()} kg";
    }
  }
}



