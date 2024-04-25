namespace Exercise005
{
    public interface ITacoBox
    {
        int TacosRemaining();
        void Eat();
    }

    public class TripleTacoBox : ITacoBox
    {
        private int tacos;
        public TripleTacoBox()
        {
            tacos = 3;
        }

        public int TacosRemaining()
        {
            return Math.Max(0, tacos);
        }

        public void Eat()
        {
            if(tacos > 0)
                tacos--;
        }
    }

    public class CustomTacoBox : ITacoBox
    {
        private int tacos;
        public CustomTacoBox(int initialTacos)
        {
            tacos = Math.Max(0, initialTacos);
        }

        public int TacosRemaining()
        {
            return Math.Max(0, tacos);
        }

        public void Eat()
        {
            if(tacos > 0)
                tacos--;
        }
    }
}

