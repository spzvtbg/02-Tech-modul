using System;
using System.Linq;
using System.Collections.Generic;
namespace UnunionLists
{
    public class ununionLists
    {
        public static void Main()
        {
            List<int> first = Console.ReadLine().Split().Select(int.Parse).ToList();
            int ctr = int.Parse(Console.ReadLine());
            for (int i = 0; i < ctr; i++)
            {
                List<int> next = Console.ReadLine().Split().Select(int.Parse).ToList();
                first = ChekingNumbers(first, next);
            }
            first.Sort();
            Console.WriteLine(string.Join(" ", first));
        }

        private static List<int> ChekingNumbers(List<int> first, List<int> next)
        {
            for (int a = 0; a < next.Count; a++)
            {
                if (first.Contains(next[a]))
                {
                    RemoveAllEquals(first, next[a]);
                }
                else
                {
                    first.Add(next[a]);
                }
            }
            return first;
        }

        private static List<int> RemoveAllEquals(List<int> list, int n)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list.Remove(n);
            }
            return list;
        }
    }
}
