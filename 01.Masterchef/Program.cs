using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef        // 100/100
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ingredientsValues = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> freshnessValues = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            SortedDictionary<string, int> result = new SortedDictionary<string, int>();

            while (ingredientsValues.Count>0 && freshnessValues.Count>0)
            {
                int currIngredients = ingredientsValues.Peek();
                int currFreshness=freshnessValues.Peek();
                if (currIngredients==0)
                {
                    ingredientsValues.Dequeue();
                    continue;
                }
                int totalFreshnessLevel = currIngredients * currFreshness;
                string currDish = GetCurrDish(totalFreshnessLevel);
                if (currDish.Any())
                {
                    ingredientsValues.Dequeue();
                    freshnessValues.Pop();

                    if (result.ContainsKey(currDish))
                    {
                        result[currDish] += 1;
                    }
                    else
                    {
                        result.Add(currDish, 1);
                    }
                }
                else
                {
                    ingredientsValues.Dequeue();
                    freshnessValues.Pop();
                    currIngredients += 5;
                    ingredientsValues.Enqueue(currIngredients);
                }
            }
            if (result.Count==4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
            }
            if (ingredientsValues.Any())
            {
                Console.WriteLine($"Ingredients left: {ingredientsValues.Sum()}");
            }
            if (result.Any())
            {
                foreach (var item in result)
                {
                    Console.WriteLine($" # {item.Key} --> {item.Value}");
                }
            }           
        }
        private static string GetCurrDish(int value)
        {
            string currDish = "";                     
             if (value == 400)
            {
                currDish = "Lobster";
            }
            else if (value == 300)
            {
                currDish = "Chocolate cake";
            }
            else if (value == 250)
            {
                currDish = "Green salad";
            }
            else if (value == 150)
            {
                currDish = "Dipping sauce";
            }
            return currDish;
        }
    }
}
