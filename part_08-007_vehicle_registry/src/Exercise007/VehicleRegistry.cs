namespace Exercise007
{
    using System;
    using System.Collections.Generic;
    public class VehicleRegistry
    {
        public Dictionary<LicensePlate, string> registry;
        public HashSet<string> Owners;
        public VehicleRegistry()
        {
            registry = new Dictionary<LicensePlate, string>();
            Owners = new HashSet<string>();
        }

        public bool Add(LicensePlate licensePlate, string owner)
        {
            if(!registry.ContainsKey(licensePlate))
            {
                registry.Add(licensePlate, owner);
                return true;
            }

            return false;
        }

        public string Get(LicensePlate licensePlate)
        {
            if(registry.ContainsKey(licensePlate))
            {
                return registry[licensePlate];
            }
            
            return "Error!";
        }

        public bool Remove(LicensePlate licensePlate)
        {
            return registry.Remove(licensePlate);
        }

        public void PrintLicensePlates()
        {
            foreach(var key in registry.Keys)
            {
                Console.WriteLine(key);
            }
        }

        public void PrintOwners()
        {
            foreach(var owner in registry.Values)
            {
                if(!this.Owners.Contains(owner))
                {
                    Owners.Add(owner);
                    Console.WriteLine(owner);
                }
            }
        }

    }
}