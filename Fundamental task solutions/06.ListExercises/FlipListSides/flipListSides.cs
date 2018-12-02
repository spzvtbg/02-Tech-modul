using System;
using System.Linq;
using System.Collections.Generic;
namespace FlipListSides
{
    public class flipListSides
    {
        public static void Main()
        {
            List<int> inputList = Console.ReadLine().Split().Select(int.Parse).ToList();
            bool isTrue = inputList.Count % 2 == 0 ? true : false;
            int firstIndex = 0;
            int midleIndex = 0;
            int lastIndex = 0;
            if (isTrue)
            {
                firstIndex = inputList[0];
                lastIndex = inputList[inputList.Count - 1];
                inputList.Reverse();

                inputList.RemoveAt(0);
                inputList.Insert(0, firstIndex);
                inputList.RemoveAt(inputList.Count - 1);
                inputList.Insert(inputList.Count, lastIndex);
            }
            else
            {
                firstIndex = inputList[0];
                midleIndex = inputList[inputList.Count / 2];
                lastIndex = inputList[inputList.Count - 1];
                inputList.Reverse();

                inputList.RemoveAt(0);
                inputList.Insert(0, firstIndex);
                inputList.RemoveAt(inputList.Count / 2);
                inputList.Insert(inputList.Count / 2, midleIndex);
                inputList.RemoveAt(inputList.Count - 1);
                inputList.Insert(inputList.Count, lastIndex);
            }
            Console.WriteLine(string.Join(" ", inputList));
        }
    }
}
