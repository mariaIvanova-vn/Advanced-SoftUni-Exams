using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        List<Renovator> renovators;
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public int Count =>renovators.Count;
        public Catalog(string name, int neededRenovators, string project)
        {
            renovators = new List<Renovator>();
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
        }
        public string AddRenovator(Renovator renovator)
        {
            if (string.IsNullOrEmpty(renovator.Type) || string.IsNullOrEmpty(renovator.Name))
            {
                return "Invalid renovator's information.";
            }
            if (Count >= NeededRenovators)
            {
                return "Renovators are no more needed.";
            }
            if (renovator.Rate>350)
            {
                return "Invalid renovator's rate.";
            }
            renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }
        public bool RemoveRenovator(string name)
        {
            Renovator renovator = renovators.FirstOrDefault(d => d.Name == name);
            if (renovator == null)
            {
                return false;
            }
            renovators.Remove(renovator);
            return true;
        }
        public int RemoveRenovatorBySpecialty(string type)
        {
            var result = 0;
            var dronesToRemove = this.renovators.Where(d => d.Type == type).ToList();
            if (dronesToRemove.Count() > 0)
            {
                result = dronesToRemove.Count();
                foreach (var drone in dronesToRemove)
                {
                    renovators.Remove(drone);
                }
            }
            else
            {
                result = 0;
            }
            return result;
        }
        public Renovator HireRenovator(string name)
        {
            var current = this.renovators.FirstOrDefault(d => d.Name == name);
            if (current != null)
            {
                current.Hired = true;
                return current;
            }                
            else
            {
                return null;
            }
        }
        public List<Renovator> PayRenovators(int days)
        {
            var current = renovators.Where(predicate => predicate.Days >= days).ToList();
            return current;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {Project}:");
            foreach (var renovator in renovators)
            {
                sb.AppendLine(renovator.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}

