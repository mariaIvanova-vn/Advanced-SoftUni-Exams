using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Drones
{
    public class Airfield
    {
        private List<Drone> Drones;
        public string Name { get; set; }
        public int Capacity { get; set; }
        public double LandingStrip { get; set; }
        public int Count { get { return Drones.Count; } }
        public Airfield(string name, int capacity, double landingStrip)
        {
            Drones=new List<Drone>();   
            Name = name;
            Capacity = capacity;
            LandingStrip = landingStrip;    
        }

        public string AddDrone(Drone drone)
        {
            if (drone.Range <5 || drone.Range>15 || string.IsNullOrEmpty(drone.Brand) || string.IsNullOrEmpty(drone.Name))
            {
                return "Invalid drone.";
            }
            if (Count >= Capacity)
            {
                return "Airfield is full.";
            }
            Drones.Add(drone);
            return $"Successfully added {drone.Name} to the airfield.";
        }
        public bool RemoveDrone(string name)
        {
            Drone drone = Drones.FirstOrDefault(d => d.Name == name);
            if (drone == null)
            {
                return false;
            }
            Drones.Remove(drone);
            return true;
        }
        //public int RemoveDroneByBrand(string brand)
        //{
        //    var drones = Drones.Where(predicate => predicate.Brand == brand).ToList();
        //    if (drones==null)
        //    {
        //        return 0;
        //    }
        //    return drones.Count();
        //    foreach (var item in drones)
        //    {
        //        drones.Remove(item);
        //    }            
        //}
        public int RemoveDroneByBrand(string brand)
        {
            var result = 0;
            var dronesToRemove = this.Drones.Where(d => d.Brand == brand).ToList();
            if (dronesToRemove.Count() > 0)
            {
                result = dronesToRemove.Count();
                foreach (var drone in dronesToRemove)
                {
                    Drones.Remove(drone);
                }
            }
            else
            {
                result = 0;
            }
            return result;
        }
        public Drone FlyDrone(string name)          //  Available -> prop -	Available: boolean - true by default
        {
            var currentDrone = this.Drones.FirstOrDefault(d => d.Name == name);
            if (currentDrone != null)
                currentDrone.Available = false;

            return currentDrone;
        }
        public List<Drone> FlyDronesByRange(int range)
        {
            var flyDrone=Drones.Where(predicate => predicate.Range >= range).ToList();
            return flyDrone;    
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Drones available at {Name}:");
            var dronesNotInFlight = Drones.Where(d => d.Available == true);
            foreach (var drone in dronesNotInFlight)
            {
                sb.AppendLine(drone.ToString());
            }
            return sb.ToString();   
        }
    }
}
//public int RemoveDroneByBrand(string brand)
//{
//    var result = 0;
//    var dronesToRemove = this.Drones.Where(d => d.Brand == brand).ToList();
//    if (dronesToRemove.Count() > 0)
//    {
//        result = dronesToRemove.Count();
//        foreach (var drone in dronesToRemove)
//        {
//            this.drones.Remove(drone);
//        }
//    }
//    else
//    {
//        result = 0;
//    }
//    return result;
//}