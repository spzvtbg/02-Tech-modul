using System;
using System.Linq;
namespace CountGivenElement
{
    public class countGivenElement
    {
        public static void Main()
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());

            int ctr = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int res = arr[i] == n ? ctr++ : ctr = ctr;
            }
            Console.WriteLine(ctr);
        }
    }
}
