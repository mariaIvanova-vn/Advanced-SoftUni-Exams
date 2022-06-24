using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;
        public SkiRental(string name, int capacity)
        {
            data=new List<Ski>();   
            Name = name;
            Capacity = capacity;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return data.Count; } }

        //•	Method Add(Ski ski) – adds an entity to the data if there is an empty slot for the Ski.
        public void Add(Ski ski)
        {
            if (Capacity>data.Count)
            {
                data.Add(ski);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            Ski ski = data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
            if (ski == null)
            {
                return false;
            }
            data.Remove(ski);
            return true;
        }
        public Ski GetNewestSki()
        {
            Ski ski = data.OrderByDescending(p => p.Year).FirstOrDefault();
            return ski;
        }
        public Ski GetSki(string manufacturer, string model)
        {
            Ski ski = data.FirstOrDefault(c => c.Manufacturer == manufacturer && c.Model == model);
            return ski;
        }
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {Name}:");
            foreach (var item in data)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString();
        }
    }
}
