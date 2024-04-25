namespace Exercise007
{
    public interface IMovable
    {
        void Move(int dx, int dy);
    }

    public class Organism : IMovable
    {
        public int x;
        public int y;
        public Organism(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            return $"x: {this.x}; y: {this.y}";
        }

        public void Move(int dx, int dy)
        {
            this.x += dx;
            this.y += dy;
        }
    }

    public class Herd : IMovable
    {
        public List<IMovable> list_of_obj;
        public Herd()
        {
            list_of_obj = new List<IMovable>();
        }

        public void AddToHerd(IMovable movable)
        {
            list_of_obj.Add(movable);
        }

        public override string ToString()
        {
            string result = "";
            foreach (IMovable member in list_of_obj)
            {
                result += member.ToString() + "\n";
            }

            return result;
        }

        public void Move(int dx, int dy)
        {
            foreach(IMovable member in list_of_obj)
            {
                member.Move(dx, dy);
            }
        }
    }
}



