
namespace Exercise001
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // DO NOT TOUCH THIS CODE!

            // Displays "ExampleMethod in NamespaceExample."
            NamespaceExample.Example outer = new NamespaceExample.Example();
            outer.ExampleMethod();

            // Displays "ExampleMethod in InnerNamespaceExample."
            NamespaceExample.InnerNamespaceExample.Example inner = new NamespaceExample.InnerNamespaceExample.Example();
            inner.ExampleMethod();
        }
    }
}

