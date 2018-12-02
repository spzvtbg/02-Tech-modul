using System;
using System.Linq;
namespace ArrayElementsEqualToTheirIndex
{
    public class equalElements
    {
        public static void Main()
        {
            int[] elements = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            for (int i = 0; i < elements.Length; i++)
            {
                Console.Write(i == elements[i]? elements[i] + " ": "");
            }
            Console.WriteLine();
        }
    }
}
