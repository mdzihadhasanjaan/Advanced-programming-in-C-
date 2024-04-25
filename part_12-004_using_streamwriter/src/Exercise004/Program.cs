namespace Exercise004
{
    using System.IO;
    public class Program
    {
        public static void Main(string[] args)
        {
            using (StreamWriter writer = new StreamWriter("file.txt"))
            {
                writer.WriteLine("Hello file!"); 
                writer.WriteLine("More text");
                writer.Write("And a little extra"); 
            }
        }
    }
}