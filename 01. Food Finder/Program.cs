using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Food_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<char> vowels = new Queue<char>(Console.ReadLine().Split().Select(char.Parse).ToArray());
            Stack<char> consonants = new Stack<char>(Console.ReadLine().Split().Select(char.Parse).ToArray());
            List<string> result = new List<string>();
            string pear = "pear";
            string flour = "flour";
            string pork = "pork";
            string olive = "olive";

            int pearCount = 4;
            int flourCount = 5;
            int porkCount = 4;
            int oliveCount = 5;

            int totalWordsFound = 0;

            while (consonants.Count > 0)
            {
                char currVowel = vowels.Dequeue();
                vowels.Enqueue(currVowel);   
                char currConsonant = consonants.Pop();
                if(pear.Contains(currVowel))
                {
                    pear = pear.Replace(currVowel, ' ');
                    pearCount--;
                }

                if (flour.Contains(currVowel))
                {
                    flour = flour.Replace(currVowel, ' ');
                    flourCount--;
                }

                if (pork.Contains(currVowel))
                {
                    pork = pork.Replace(currVowel, ' ');
                    porkCount--;
                }

                if (olive.Contains(currVowel))
                {
                    olive = olive.Replace(currVowel, ' ');
                    oliveCount--;
                }

                if (pear.Contains(currConsonant))
                {
                    pear = pear.Replace(currConsonant, ' ');
                    pearCount--;
                }

                if (flour.Contains(currConsonant))
                {
                    flour = flour.Replace(currConsonant, ' ');
                    flourCount--;
                }

                if (pork.Contains(currConsonant))
                {
                    pork = pork.Replace(currConsonant, ' ');
                    porkCount--;
                }

                if (olive.Contains(currConsonant))
                {
                    olive = olive.Replace(currConsonant, ' ');
                    oliveCount--;
                }
            }
            if (pearCount == 0)
            {
                totalWordsFound++;
                result.Add("pear");
            }

            if (flourCount == 0)
            {
                totalWordsFound++;
                result.Add("flour");
            }

            if (porkCount == 0)
            {
                totalWordsFound++;
                result.Add("pork");
            }

            if (oliveCount == 0)
            {
                totalWordsFound++;
                result.Add("olive");
            }
            Console.WriteLine($"Words found: {totalWordsFound}");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }     
    }
}
