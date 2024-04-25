namespace Exercise007
{
    using System;
    public class LicensePlate
    {
        public string liNumber { get; }
        private string country;

        public LicensePlate(string country, string liNumber)
        {
            this.liNumber = liNumber;
            this.country = country;
        }

        public override bool Equals(object obj)
        {
            if(obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            LicensePlate new_obj = (LicensePlate)obj;
            return this.country == new_obj.country && this.liNumber == new_obj.liNumber;
        }

        public override int GetHashCode()
        {
            return country.GetHashCode() * 2 + liNumber.GetHashCode();
        }
        public override string ToString()
        {
            return country + " " + liNumber;
        }

    }
}



