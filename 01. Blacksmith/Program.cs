using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Blacksmith
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> steel = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> carbon = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int count = 0;
            SortedDictionary<string, int> result = new SortedDictionary<string, int>();
            while (steel.Count>0 && carbon.Count>0)
            {
                int currSteel = steel.Peek();
                int currCarbon = carbon.Peek();
                int sum = currSteel + currCarbon;
                string currSword = GetCurrSword(sum);
        
                if (currSword.Any())
                {
                    count++;    
                    steel.Dequeue();
                    carbon.Pop();
                    if (result.ContainsKey(currSword))
                    {
                        result[currSword] += 1;
                    }
                    else
                    {
                        result.Add(currSword, 1);
                    }                  
                }
                else
                {
                    steel.Dequeue();
                    carbon.Pop();
                    currCarbon += 5;
                    carbon.Push(currCarbon);    
                }
            }
            if (result.Count>0)
            {
                Console.WriteLine($"You have forged {count} swords.");
            }
            else
            {
                Console.WriteLine("You did not have enough resources to forge a sword.");
            }
            if (steel.Count==0)
            {
                Console.WriteLine("Steel left: none");
            }
            else
            {
                Console.WriteLine($"Steel left: {string.Join(", ", steel)}");
            }
            if (carbon.Count==0)
            {
                Console.WriteLine("Carbon left: none");
            }
            else
            {
                Console.WriteLine($"Carbon left: {string.Join(", ", carbon)}");
            }
            foreach (var item in result)
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
        }        
        static string GetCurrSword(int value)
        {           
            string currSword = "";
            if (value==70)
            {
                currSword = "Gladius";
            }
            else if (value==80)
            {
                currSword = "Shamshir";
            }           
            else if (value == 90)
            {
                currSword = "Katana";
            }
            else if (value == 110)
            {
                currSword = "Sabre";
            }
            else if (value == 150)
            {
                currSword = "Broadsword";
            }
            return currSword;
        }
    }
}