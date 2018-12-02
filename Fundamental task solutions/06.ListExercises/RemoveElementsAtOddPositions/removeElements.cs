using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveElementsAtOddPositions
{
    public class removeElements
    {
        public static void Main()
        {
            List<string> array = Console.ReadLine().Split(' ').ToList();
            List<string> newArray = new List<string>();

            for (int i = 0; i < array.Count; i++)
            {
                if (i % 2 != 0)
                {
                    newArray.Add(array[i]);
                }
                else
                {
                    continue;
                }
            }
            for (int i = 0; i < newArray.Count; i++)
            {
                Console.Write(newArray[i]);
            }
            Console.WriteLine();
        }
    }
}
