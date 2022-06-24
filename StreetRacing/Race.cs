using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetRacing
{
    public class Race
    {
        public List<Car> Participants { get; set; }

        public Race(string name, string type, int laps, int capacity, int maxHorsePower)
        {
            Participants = new List<Car>();
            Name = name;
            Type = type;
            Laps = laps;
            Capacity = capacity;
            MaxHorsePower = maxHorsePower;
        }
        public int Count { get { return Participants.Count; } }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Laps { get; set; }
        public int Capacity { get; set; }
        public int MaxHorsePower { get; set; }

        public void Add(Car car)
        {
            if (!Participants.Contains(car) && Capacity > Participants.Count && car.HorsePower <= MaxHorsePower)
            {
                Participants.Add(car);
            }
        }
        public bool Remove(string licensePlate)
        {
            var car = Participants.Find(x => x.LicensePlate == licensePlate);
            if (car == null)
            {
                return false;
            }
            else
            {
                Participants.Remove(car);
                return true;
            }
        }
        public Car FindParticipant(string licensePlate)
        {
            Car car = Participants.Find(c => c.LicensePlate == licensePlate);
            if (car!=null)
            {
                return car;
            }
            return null;
        }
        public Car GetMostPowerfulCar()
        {
            Car car = Participants.FirstOrDefault(c => c.HorsePower == MaxHorsePower);
            if (car != null)
            {
                return car;
            }
            return null;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Race: {Name} - Type: {Type} (Laps: {Laps})");
            foreach (var car in Participants)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString();
        }
    }
}

