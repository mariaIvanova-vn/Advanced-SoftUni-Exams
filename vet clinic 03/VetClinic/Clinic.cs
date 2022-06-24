using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    public class Clinic
    {
        private List<Pet> data;
        public Clinic(int capacity)
        {
            Capacity = capacity;    
            data = new List<Pet>();
        }
        public int Capacity { get; set; }

        //•	Getter Count – returns the number of pets.
        public int Count { get { return data.Count; } }

        // methods:
        //•	Method Add(Pet pet) – adds an entity to the data if there is an empty cell for the pet.
        public void Add(Pet pet)
        {
            if (data.Count<Capacity)
            {
                data.Add(pet);
            }
        }
        //•	Method Remove(string name) – removes the pet by given name, if such exists, and returns bool.
        public bool Remove(string name)
        {
            Pet pet = data.FirstOrDefault(p => p.Name == name);
            if (pet==null)
            {
                return false;
            }
           data.Remove(pet);
            return true;    
        }
        //•	Method GetPet(string name, string owner) – returns the pet with the given name and owner or null if no such pet exists.
        public Pet GetPet(string name, string owner)
        {
            Pet pet = data.FirstOrDefault(p => p.Name == name &&  p.Owner == owner);

            return pet;
        }
        //•	Method GetOldestPet() – returns the oldest Pet.
        public Pet GetOldestPet()
        {
            Pet pet=data.OrderByDescending(p => p.Age).FirstOrDefault();   
            return pet;
        }
        //•	GetStatistics() – returns a string in the following format:
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");
            foreach (var item in data)
            {
                sb.AppendLine("Pet " + item.Name + " with owner: " + item.Owner);
                // or  ->  sb.AppendLine($"Pet {item.Name} with owner: {item.Owner}");
            }
            return sb.ToString();
        }

    }
}
