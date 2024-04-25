namespace Exercise003
{

    public class Warehouse
    {
        public int balance { get; set; }
        public int capacity { get; set; }

        public Warehouse(int capacity)
        {
            if (capacity > 0)
            {
                this.capacity = capacity;
            }
            else
            {
                this.capacity = 0;
            }

            this.balance = 0;
        }

        public int HowMuchSpaceLeft()
        {
            return this.capacity - this.balance;
        }

        public void AddToWarehouse(int amount)
        {
            if (amount < 0)
            {
                return;
            }
            if (amount <= HowMuchSpaceLeft())
            {
                this.balance += amount;
            }
            else
            {
                this.balance = this.capacity;
            }
        }

        public int TakeFromWarehouse(int amount)
        {
            if (amount < 0)
            {
                return 0;
            }
            if (amount > this.balance)
            {
                int allThatWeCan = this.balance;
                this.balance = 0;
                return allThatWeCan;
            }
            this.balance -= amount;
            return amount;
        }

        public override string ToString()
        {
            return "balance: " + this.balance + ", space left " + HowMuchSpaceLeft();
        }
    }

    public class ProductWarehouse : Warehouse
    {
        public string productName;
        public ProductWarehouse(string productName, int capacity) : base(capacity)
        {
            this.productName = productName;
            this.capacity = capacity;
        }

        public override string ToString()
        {
            return $"{this.productName}: {base.ToString()}";
        }
    }

    public class ChangeHistory
    {
        private List<int> history;
        public ChangeHistory()
        {
            history = new List<int>();
        }

        public void Add(int status)
        {
            history.Add(status);
        }

        public void Clear()
        {
            history.Clear();
        }

        public int MaxValue()
        {
            return history.Count > 0 ? history.Max() : 0;
        }

        public int MinValue()
        {
            return history.Count > 0 ? history.Min() : 0;
        }

        public override string ToString()
        {
            int current = history.Count > 0 ? history.Last() : 0;
            return $"Current: {current} Min: {MinValue()} Max: {MaxValue()}";
        }
    }

    public class ProductWarehouseWithHistory : ProductWarehouse
    {
        private ChangeHistory history;
        public ProductWarehouseWithHistory(string productName, int capacity, int initialBalance) : base(productName, capacity)
        {
            history = new ChangeHistory();
            AddToWarehouse(initialBalance);
        }

        public string History()
        {
            return history.ToString();
        }

        new public void AddToWarehouse(int amount)
        {
            base.AddToWarehouse(amount);
            history.Add(base.balance);
        }

        new public int TakeFromWarehouse(int amount)
        {
            int take_amount = base.TakeFromWarehouse(amount);
            history.Add(base.balance);
            return take_amount;
        }
    }
}



