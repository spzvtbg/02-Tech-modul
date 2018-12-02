using System;
using System.Linq;
namespace ArraySymmetry
{
    public class arraySymmetry
    {
        public static void Main()
        {
            string[] elements = Console.ReadLine().Split(' ').ToArray();
            int first = elements.Length / 2;
            int second = elements.Length - 1;
            int ctr = 0;
            for (int i = 0; i < first; i++)
            {
               int res = elements[i] == elements[second] ? ctr++: ctr;
                second--;
            }
            Console.WriteLine(ctr == first ? "Yes" : "No");
        }
    }
}
