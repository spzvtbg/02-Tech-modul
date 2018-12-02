using System;
using System.Linq;
using System.Collections.Generic;
namespace DistinctList
{
    public class distinctList
    {
        public static void Main()
        {
            List<int> inputLine = Console.ReadLine().Split().Select(int.Parse).ToList();           
            List<int> newList = RepeatingNumbers(inputLine);

            Console.WriteLine(string.Join(" ", newList));
        }

        private static List<int> RepeatingNumbers(List<int> list)
        {
            List<int> newlist = new List<int>();
            for (int a = 0; a < list.Count; a++)
            {
                    if (newlist.Contains(list[a]))
                    {
                        continue;
                    }
                    else
                    {
                        newlist.Add(list[a]);
                    }
            }
            return newlist;
        }
    }
}
