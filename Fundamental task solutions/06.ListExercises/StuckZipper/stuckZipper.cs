using System;
using System.Linq;
using System.Collections.Generic;
namespace StuckZipper
{
    public class stuckZipper
    {
        public static void Main()
        {
            List<int> firstList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> lastList = Console.ReadLine().Split().Select(int.Parse).ToList();

            int minDigitsElementFirstList = FindMinElementLenght(firstList);
            int minDigitsElementLastList = FindMinElementLenght(lastList);
            int minLenhgtNumbers = Math.Min(minDigitsElementFirstList, minDigitsElementLastList);

            firstList = RemovingLargerElements(minLenhgtNumbers, firstList);
            lastList = RemovingLargerElements(minLenhgtNumbers, lastList);

            List<int> newList = PasteLists(firstList, lastList);
            List<int> maxList = FindMaxList(firstList, lastList);
            List<int> minList = FindMinList(firstList, lastList);
            List<int> endList = CompleteTheTask(newList, minList, maxList);

            Console.WriteLine(string.Join(" ", endList));
        }

        private static int FindMinElementLenght(List<int> list)
        {
            int min = Math.Abs(list[0]).ToString().Length;
            for (int i = 1; i < list.Count; i++)
            {
                int b = Math.Abs(list[i]).ToString().Length;
                min = min < b ? min : b;
            }
            return min;
        }

        private static List<int> RemovingLargerElements(int n, List<int> list)
        {
            int need = n;
            List<int> newList = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                int lenght = Math.Abs(list[i]).ToString().Length;
                if (need == lenght)
                {
                    newList.Add(list[i]);
                }
            }
            return newList;
        }

        private static List<int> CompleteTheTask(List<int> newList, List<int> minList, List<int> maxList)
        {
            for (int i = minList.Count; i < maxList.Count; i++)
            {
                newList.Add(maxList[i]);
            }
           return newList;
        }

        private static List<int> FindMinList(List<int> firstList, List<int> lastList)
        {
            List<int> minList = firstList.Count < lastList.Count ? firstList : lastList;
            return minList;
        }

        private static List<int> PasteLists(List<int> firstList, List<int> lastList)
        {
            int a = 0;
            int b = 0;
            int min = Math.Min(lastList.Count, firstList.Count);

            List<int> newList = new List<int>();
            for (int i = 0; i < min + min; i ++)
            {
                if (i % 2 == 0)
                {
                    newList.Add(lastList[a]);
                    a++;
                }
                else
                {
                    newList.Add(firstList[b]);
                    b++;
                }
            }
            return newList;
        }

        private static List<int> FindMaxList(List<int> firstList, List<int> lastList)
        {
            List<int> maxList = firstList.Count > lastList.Count ? firstList : lastList;
            return maxList; 
        }
    }
}
