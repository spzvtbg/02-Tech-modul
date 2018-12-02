using System;
using System.Linq;
using System.Collections.Generic;
namespace TearListInHalf
{
    public class tearList
    {
        public static void Main()
        {
            List<int> holeList = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> digitsList = TakeTheFirstHalf(holeList);
            List<int> firstHalf = TakeTheHalfList(holeList);
            Console.WriteLine(string.Join(" ", PastingLists(digitsList, firstHalf)));
        }

        private static List<int> PastingLists(List<int> digitsList, List<int> firstHalf)
        {
            int a = 0;
            for (int i = 1; i < digitsList.Count; i += 3)
            {
                int b = firstHalf[a];
                digitsList.Insert(i, b);
                a++;
            }
            return digitsList;
        }

        private static List<int> TakeTheHalfList(List<int> holeList)
        {
            List<int> newList = new List<int>();
            for (int i = 0; i < holeList.Count / 2; i++)
            {
                newList.Add(holeList[i]);
            }
            return newList;
        }

        private static List<int> TakeTheFirstHalf(List<int> holeList)
        {
            int n = holeList.Count / 2;
            List<int> newList = new List<int>();
            for (int i = n; i < holeList.Count; i++)
            {
                newList.Add(holeList[i]);
            }
            TakeTheDigits(newList);
            return TakeTheDigits(newList);
        }

        private static List<int> TakeTheDigits(List<int> newnewlist)
        {
            List<int> newList = new List<int>();
            for (int i = 0; i < newnewlist.Count; i ++)
            {
                newList.Add(newnewlist[i] / 10);
                newList.Add(newnewlist[i] % 10);
            }
            return newList;
        }
    }
}
