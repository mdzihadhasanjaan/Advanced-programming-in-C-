namespace Exercise004
{
  public class Book
  {
    public string name { get; set; }
    public string content { get; set; }
    public int published { get; set; }

    public Book(string name, int published, string content)
    {
      this.name = name;
      this.published = published;
      this.content = content;
    }

    public override string ToString()
    {
      return "Name: " + this.name + " (" + this.published + ")\n"
          + "Content: " + this.content;
    }

    public override bool Equals(object compared)
    {
      if (this == compared)
      {
        return true;
      }
      if ((compared == null) || !this.GetType().Equals(compared.GetType()))
      {
        return false;
      }
      else
      {
        Book compBook = (Book)compared;

        return
        this.name == compBook.name &&
        this.published == compBook.published &&
        this.content == compBook.content;
      }
    }

    public override int GetHashCode()
    {
      if (this.name == null)
      {
        return this.published;
      }
      return this.published + this.name.GetHashCode();
    }
  }
}





