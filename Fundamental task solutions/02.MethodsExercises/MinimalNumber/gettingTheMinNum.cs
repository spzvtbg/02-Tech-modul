using System;
namespace MinimalNumber
{
    public class gettingTheMinNum
    {
        public static void Main()
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());

            int min = getMinimal(n1, n2, n3);
            Console.WriteLine(min);
        }
        static int getMinimal(int n1, int n2, int n3)
        {
            int min = 0;
            if (n1 < n2 && n1 < n3)
            {
                min = n1;
            }
            else if (n2 < n1 && n2 < n3)
            {
                min = n2;
            }
            else
            {
                min = n3;
            }
            return min;
        }
    }
}
