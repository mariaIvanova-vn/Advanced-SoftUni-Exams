using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        List<Player> Roster;

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count { get { return Roster.Count; } }
        public Guild(string name, int capacity)
        {
            Roster=new List<Player>();  
            Name = name;
            Capacity = capacity;
        }
        public void AddPlayer(Player player)
        {
            if (Capacity> Count)
            {
                Roster.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            Player player1 = Roster.Find(x => x.Name == name);
            if (player1 == null)
            {
                return false;
            }
            Roster.Remove(player1);
            return true;
        }
        public void PromotePlayer(string name)
        {
            Player player1 = Roster.Where(p => p.Name == name).FirstOrDefault();
            if (player1 != null && player1.Rank != "Member")
            {
                player1.Rank = "Member";
            }
        }
        public void DemotePlayer(string name)
        {
            Player player1 = Roster.Where(p => p.Name == name).FirstOrDefault();
            if (player1 != null && player1.Rank != "Trial")
            {
                player1.Rank = "Trial";
            }
        }
        public Player[] KickPlayersByClass(string @class) 
        {
            
            Player[] player1 = Roster.FindAll(p=> p.Class == @class).ToArray();        
            Roster.RemoveAll(x=>x.Class == @class);
            return player1.ToArray();
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");
            foreach (var item in Roster)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();   
        }
    }
}
