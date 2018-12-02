using System;
namespace NthDigit
{
    public class checkingIndex
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int position = int.Parse(Console.ReadLine());

            Console.WriteLine(TakingIndex(number, position));
        }

        static int TakingIndex(int n, int pos)
        {
            for (int i = 1; i <= pos - 1; i++)
            {
                n /= 10;
            }
            int digit = DividingProcentual(n);
            return digit;
        }

         static int DividingProcentual(int n)
        {
            n %= 10;
            return n;
        }
    }
}
