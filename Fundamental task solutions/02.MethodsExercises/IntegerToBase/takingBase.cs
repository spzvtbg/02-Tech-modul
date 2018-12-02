using System;
namespace IntegerToBase
{
    public class takingBase
    {
        public static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            int baseNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(TakeBase(number, baseNumber));
        }

        private static string TakeBase(int num, int n )
        {
            string result = string.Empty;
            while (num > 0)
            {
                int rem = num % n;
                result = rem + result;
                num /= n;
            }
            return result;
        }
    }
}
