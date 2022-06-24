using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Birthday_Celebration      //100/100
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> eatingCapacity = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> plates = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int wastedFood = 0;

            while (eatingCapacity.Count > 0 && plates.Count > 0)
            {
                int currCapacity=eatingCapacity.Peek();
                int currPlates=plates.Peek();
                int diference = currPlates - currCapacity;
                if (diference>=0)
                {
                    eatingCapacity.Dequeue();
                    plates.Pop();
                    wastedFood+=diference;
                }
                else if(diference<0)
                {
                    eatingCapacity.Dequeue();
                    plates.Pop();
                    // It is possible that the current guest's value is greater than the current food's value.
                    // In that case you pick plates until you reduce the guest's integer value to 0 or less. :
                    eatingCapacity = new Queue<int>(eatingCapacity.Reverse());
                    eatingCapacity.Enqueue(currCapacity - currPlates);
                    eatingCapacity = new Queue<int>(eatingCapacity.Reverse());                  
                }               
            }
            if (eatingCapacity.Count>0)
            {
                Console.WriteLine($"Guests: {string.Join(" ", eatingCapacity)}");
            }
            else if (plates.Count>0)
            {
                Console.WriteLine($"Plates: {string.Join(" ", plates)}");
            }
            Console.WriteLine($"Wasted grams of food: {wastedFood}");
        }
    }
}
