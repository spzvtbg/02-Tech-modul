using System;
using System.Collections.Generic;
using System.Linq;
namespace _04.ArrayHistogram
{
    class arrayHistogram
    {
        static void Main()
        {
            List<string> input = Console.ReadLine().Split().ToList();
            List<string> words = new List<string>();
            List<double> wordsCounter = new List<double>();

            SortTheInput(input, words, wordsCounter);
            SortData(words, wordsCounter);

            for (int i = 0; i < wordsCounter.Count; i++)
            {
                Console.Write($"{words[i]} -> {wordsCounter[i]} times ");
                Console.WriteLine($"({(wordsCounter[i] / input.Count) * 100:0.00}%)");
            }
        }

        private static void SortData(List<string> words, List<double> wordsCounter)
        {
            bool isDescendingOrder = false;
            do
            {
                isDescendingOrder = false;
        
                for (int i = 1; i < wordsCounter.Count; i++)
                {
                    double tempValue = 0;
                    string tempWord = string.Empty;
        
                    if (wordsCounter[i - 1] < wordsCounter[i])
                    {
                        tempValue = wordsCounter[i - 1];
                        tempWord = words[i - 1];
        
                        wordsCounter[i - 1] = wordsCounter[i];
                        words[i - 1] = words[i];
        
                        wordsCounter[i] = tempValue;
                        words[i] = tempWord;
        
                        isDescendingOrder = true;
                    }
        
                }
        
            } while (isDescendingOrder);
        }

        private static void SortTheInput(List<string> input, List<string> words, List<double> wordsCounter)
        {
            int c = 0;
            for (int j = 0; j < input.Count; j++)
            {
                if (words.Contains(input[j]))
                {
                    continue;
                }
                for (int i = 0; i < input.Count; i++)
                {
                    if (input[j] == input[i])
                    {
                        if (words.Contains(input[j]))
                        {
                            continue;
                        }
                        else
                        {
                            c++;
                        }
                    }
                }
                words.Add(input[j]);
                wordsCounter.Add(c);
                c = 0;
            }
        }
    }
}
