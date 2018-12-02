using System;
using System.Linq;
namespace CountLargerNumbersArray
{
    public class counting
    {
        public static void Main()
        {
            double[] arr = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            //double n = double.Parse(Console.ReadLine());

            int ctr = 1;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int res = arr[i] == arr[i + 1] ? ctr++ : ctr = ctr;
            }
            Console.WriteLine(ctr == arr.Length ? "Yes" : "No");
        }
    }
}
