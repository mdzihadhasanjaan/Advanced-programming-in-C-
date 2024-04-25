namespace Exercise002
{
    public class Student : IComparable<Student>
    {

        public string name { get; }

        public Student(string name)
        {
            this.name = name;
        }

        public int CompareTo(Student other)
        {
            return this.name.CompareTo(other.name);
        }


        public override string ToString()
        {
            return this.name;
        }
    }
}