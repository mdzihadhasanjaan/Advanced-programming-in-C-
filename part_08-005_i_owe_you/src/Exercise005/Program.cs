namespace Exercise005
{
    using System;

    public class IOU
    {
        public Dictionary<string, int> person;
        public IOU()
        {
            person = new Dictionary<string, int>();
        }

        public void ChangeDebt(string toWhom, int amount)
        {
            if(!person.ContainsKey(toWhom))
            {
                person.Add(toWhom, amount);
            }
            else
            {
                person[toWhom] += amount;
            }

            if(person[toWhom] < 0)
                person[toWhom] = 0;
        }

        public int HowMuchDoIOweTo(string toWhom)
        {
            if(person.ContainsKey(toWhom))
                return person[toWhom];
            else
                return 0;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            IOU mattsIOU = new IOU();
            mattsIOU.ChangeDebt("Arthur", 51);
            mattsIOU.ChangeDebt("Michael", 30);

            Console.WriteLine(mattsIOU.HowMuchDoIOweTo("Arthur"));
            Console.WriteLine(mattsIOU.HowMuchDoIOweTo("Michael"));
            Console.WriteLine(mattsIOU.HowMuchDoIOweTo("Heikki"));
        }
    }
}