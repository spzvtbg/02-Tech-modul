using System;
namespace CountNegativeElements
{
    public class countNegativeElements
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[] arr = new int[n];
            int negative = 0;

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
                if (arr[i] < 0)
                {
                    negative ++;
                }
            }
            Console.WriteLine(negative);
        }
    }
}
