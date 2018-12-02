using System;
using System.Collections.Generic;
using System.Linq;
namespace _04.Extremums
{
    class Extremums
    {
        static void Main()
        {
            List<int> enteredNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            string spinToMinOrMax = Console.ReadLine();
            List<int> minNumbers = new List<int>();
            List<int> maxNumbers = new List<int>();
            List<int> temporaryNumbers = new List<int>();

            for (int i = 0; i < enteredNumbers.Count; i++)
            {
                string nextNumber = enteredNumbers[i].ToString();
                if (nextNumber.Length > 1)
                {
                    temporaryNumbers = TakeAllNumbers(nextNumber);
                }
                else
                {
                    temporaryNumbers.Add(enteredNumbers[i]);
                }
                temporaryNumbers.Sort();
                minNumbers.Add(temporaryNumbers[0]);
                temporaryNumbers.Reverse();
                maxNumbers.Add(temporaryNumbers[0]);
            }
            if (spinToMinOrMax == "Min")
            {
                Console.WriteLine(string.Join(", ", minNumbers));
                Console.WriteLine(SummatingAllNumbers(minNumbers));
            }
            else if (spinToMinOrMax == "Max")
            {
                Console.WriteLine(string.Join(", ", maxNumbers));
                Console.WriteLine(SummatingAllNumbers(maxNumbers));
            }
        }

        private static int SummatingAllNumbers(List<int> numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Count; i++)
            {
                sum += numbers[i];
            }
            return sum;
        }

        private static List<int> TakeAllNumbers(string nextNumber)
        {
            List<int> list = new List<int>();
            list.Add(int.Parse(nextNumber));
            string currentNumber = string.Empty;
            for (int i = 0; i < nextNumber.Length; i++)
            {
                for (int j = 1; j < nextNumber.Length; j++)
                {
                    currentNumber = j != nextNumber.Length - 1 ? 
                        currentNumber += nextNumber[j].ToString(): 
                        currentNumber += nextNumber[j].ToString() + nextNumber[0].ToString();
                }
                nextNumber = currentNumber;
                list.Add(int.Parse(currentNumber));
                currentNumber = string.Empty;
            }
            return list;
        }
    }
}
