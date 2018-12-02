using System;
using System.Linq;
namespace CountLargerNumbersArray
{
    public class counting
    {
        public static void Main()
        {
            double[] arr = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            double n = double.Parse(Console.ReadLine());

            int ctr = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                int res = arr[i] > n ? ctr++ : ctr = ctr;
            }
            Console.WriteLine(ctr);
        }
    }
}
