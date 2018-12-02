using System;
using System.Numerics;
namespace FromTerabytesToBits
{
    public class convertingToBits
    {
        public static void Main()
        {
            //1TB == (1024 * 1024 * 1024 * 1024 * 8) bits
            decimal TB = decimal.Parse(Console.ReadLine());
            decimal result = TB * 1024m * 1024m * 1024m * 1024m * 8m;
            Console.WriteLine(Math.Round(result));
        }
    }
}
