namespace _02.DictRefAdvanced
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
  
    public class DictRefAdvanced
    {
        public static void Main()
        {
            var byNameAndValue = new Dictionary<string, List<int>>();
            var enteredLine = Console.ReadLine();
            while (enteredLine != "end")
            {
                var enter = enteredLine.Split(new char[] { ' ', ',', '-', '>' }).ToList();
                var first = enter[0];
                var last = enter[enter.Count - 1];
                enter.Remove(first);
                var num = 0;
                var listFromNumbers = new List<int>();

                if (!int.TryParse(enter[enter.Count - 1], out num))
                {
                    if (!byNameAndValue.ContainsKey(last))
                    {
                        enteredLine = Console.ReadLine();
                        continue;
                    }
                    else
                    {
                        byNameAndValue[first] = new List<int> (byNameAndValue[last]);
                    }
                }
                else
                {
                    listFromNumbers = TakeTheNumbers(enter);
                    if (!byNameAndValue.ContainsKey(first))
                    {
                        byNameAndValue[first] = new List<int>();
                        byNameAndValue[first] = listFromNumbers;
                    }
                    else
                    {
                        byNameAndValue[first].AddRange(listFromNumbers);
                    }
                }
                enteredLine = Console.ReadLine();
            }
            foreach (var name in byNameAndValue)
            {
                Console.WriteLine($"{name.Key} === {string.Join(", ", name.Value)}");
            }
        }

        private static List<int> TakeTheNumbers(List<string> numbers)
        {
            var listFromNumbers = new List<int>();
            for (int i = 1; i < numbers.Count; i++)
            {
                var number = 0;
                if (int.TryParse(numbers[i], out number))
                {
                    listFromNumbers.Add(int.Parse(numbers[i]));

                }
                else
                {
                    continue;
                }
            }
            return listFromNumbers;
        }
    }
}
