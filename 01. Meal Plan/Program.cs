using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Meal_Plan
{
    internal class Program
    {
        static void Main(string[] args)
        {         
            Queue<string> meals = new Queue<string>(Console.ReadLine().Split());
            int numOfMeals=meals.Count;
            Stack<int> calories = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            
            string currMeal = "";
            int currMealCal = 0;
            if (meals.Count>0)
            {
                currMeal = meals.Dequeue();
                currMealCal = GetCurrMealCal(currMeal);
            }
            int dayCalories = 0;
            while (calories.Count>0)
            {
                dayCalories = calories.Pop();
                if (dayCalories == 0)
                {
                    break;
                }
                if (dayCalories > currMealCal)
                {
                    dayCalories -= currMealCal;
                    calories.Push(dayCalories);
                    if (meals.Count > 0)
                    {
                        currMeal = meals.Dequeue();
                        currMealCal = GetCurrMealCal(currMeal);
                    }
                    else  {   break;   }
                }
                else if (dayCalories == currMealCal)
                {
                    if (meals.Count > 0)
                    {
                        currMeal = meals.Dequeue();
                        currMealCal = GetCurrMealCal(currMeal);
                    }
                    else { break; }
                }
                else
                {
                    currMealCal -= dayCalories;
                }
            }
            if (meals.Count==0)
            {
                Console.WriteLine($"John had {numOfMeals} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", calories)} calories.");
            }
            else
            {
                Console.WriteLine($"John ate enough, he had {numOfMeals - meals.Count} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
        }
        static int GetCurrMealCal(string meal)
        {
            int saladCal = 350;
            int soupCal = 490;
            int pastaCal = 680;
            int steakCal = 790;

            int currMealCal = 0;
            if (meal == "salad")
            {
                currMealCal = saladCal;
            }
            else if (meal == "soup")
            {
                currMealCal = soupCal;
            }
            else if (meal == "pasta")
            {
                currMealCal = pastaCal;
            }
            else if (meal == "steak")
            {
                currMealCal = steakCal;
            }
            return currMealCal;
        }
    }
}
