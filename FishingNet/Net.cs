using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        public List<Fish> Fish = new List<Fish>();
       // public List<Fish> Fish;

        public Net(string material, int capacity)
        {
          //  Fish = new List<Fish>();
            Material = material;
            Capacity = capacity;
        }
        public int Count { get { return Fish.Count; } }
        public string Material { get; set; }
        public int Capacity { get; set; }

        public string AddFish(Fish fish)
        {
            if (fish.Length<=0 || fish.Weight<=0 || string.IsNullOrWhiteSpace(fish.FishType))
            {
                return "Invalid fish.";
            }
            if (Count >= Capacity)
            {
                return "Fishing net is full.";
            }
            Fish.Add(fish);
            return $"Successfully added {fish.FishType} to the fishing net.";
        }
        public bool ReleaseFish(double weight)
        {
            Fish fish = Fish.FirstOrDefault(f => f.Weight == weight);
            if (fish==null)
            {
                return false;
            }
            Fish.Remove(fish);
            return true;
        }
        public	Fish GetFish(string fishType)
        {
            
            Fish fish = Fish.FirstOrDefault(f => f.FishType == fishType);
            return fish;
        }
        public	Fish GetBiggestFish()
        {
            double longestFish = this.Fish.Max(e => e.Length);
            Fish fish = Fish.FirstOrDefault(f => f.Length==longestFish);
            return fish;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {Material}:");
            foreach (var item in Fish.OrderByDescending(f=>f.Length))
            {
              //  Fish fish = item.OrderByDescending(f => f.Length);
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
