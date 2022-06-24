using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Bakery_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<double> water = new Queue<double>(Console.ReadLine().Split().Select(double.Parse));
            Stack<double> flour = new Stack<double>(Console.ReadLine().Split().Select(double.Parse));
            Dictionary<string, int> result = new Dictionary<string, int>();
            while (water.Count > 0 && flour.Count > 0)
            {
                var currWater=water.Peek();
                var currFlour=flour.Peek();
                double percentWater=(currWater*100)/(currWater+currFlour);
                double percentFlour=(currFlour*100)/(currFlour+currWater);
                string ratio = GetCurrRatio(percentWater, percentFlour);
                if (ratio.Any())
                {
                    water.Dequeue();
                    flour.Pop();
                    if (result.ContainsKey(ratio))
                    {
                        result[ratio] += 1;
                    }
                    else
                    {
                        result.Add(ratio, 1);
                    }
                }
                else
                {
                    double currentF = currFlour - (currFlour - currWater);
                    water.Dequeue();
                    flour.Pop();
                    flour.Push(currFlour-currentF);
                    if (result.ContainsKey("Croissant"))
                    {
                        result["Croissant"] += 1;
                    }
                    else
                    {
                        result.Add("Croissant", 1);
                    }
                }
            }
            foreach (var item in result.OrderByDescending(k=>k.Value).ThenBy(v=>v.Key))
            {
                Console.WriteLine(item.Key + ": " + item.Value);
            }
            if (water.Count<=0)
            {
                Console.WriteLine("Water left: None");
            }
            else
            {
                Console.WriteLine($"Water left: {string.Join(", ", water)}");
            }
            if (flour.Count <= 0)
            {
                Console.WriteLine("Flour left: None");
            }
            else
            {
                Console.WriteLine($"Flour left: {string.Join(", ", flour)}");
            }
        }

        private static string GetCurrRatio(double percentWater, double percentFlour)
        {
            string currRatio = "";
            if (percentWater==50 && percentFlour==50)
            {
                currRatio = "Croissant";
            }
            else if (percentWater==40 && percentFlour == 60)
            {
                currRatio = "Muffin";
            }
            else if (percentWater == 30 && percentFlour == 70)
            {
                currRatio = "Baguette";
            }
            else if (percentWater == 20 && percentFlour == 80)
            {
                currRatio = "Bagel";
            }
            return currRatio;
        }
    }
}