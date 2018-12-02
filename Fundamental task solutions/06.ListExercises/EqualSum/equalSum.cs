using System;
using System.Linq;
using System.Collections.Generic;
namespace EqualSum
{
    public class equalSum
    {
        public static void Main()
        {
            List<int> excessNumbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            List<int> originalList = Console.ReadLine().Split().Select(int.Parse).ToList();

            List<int> nowList = RemoveNumbers(originalList, excessNumbers);

            int sumExcessNumbers = SumListNumbers(excessNumbers);
            int sumNowList = SumListNumbers(nowList);

            Console.WriteLine(sumExcessNumbers == sumNowList ? $"Yes. Sum: {sumNowList}" :
                $"No. Diff: {Math.Abs(sumNowList - sumExcessNumbers)}");
        }

        private static int SumListNumbers(List<int> list)
        {
            int sum = 0;
            for (int i = 0; i < list.Count; i++)
            {
                sum += list[i];
            }
            return sum;
        }

        private static List<int> RemoveNumbers(List<int> originalList, List<int> excessNumbers)
        {
            for (int a = 0; a < originalList.Count; a++)
            {
                for (int b = 0; b < excessNumbers.Count; b++)
                {
                    if (originalList[a] == excessNumbers[b])
                    {
                        a--;
                        originalList.Remove(excessNumbers[b]);
                        break;
                    }
                }
            }
            return originalList;
        }
    }
}
