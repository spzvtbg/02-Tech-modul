using System;
namespace DistanceOfTheStars
{
    public class calculateLightYears
    {
        public static void Main()
        {
            decimal nearestStar = 4.22m * 9450000000000m;
            Console.WriteLine(nearestStar.ToString("e2"));
            decimal galaxyCenter = 26000m * 9450000000000m;
            Console.WriteLine(galaxyCenter.ToString("e2"));
            decimal MilkyWay = 100000m * 9450000000000m;
            Console.WriteLine(MilkyWay.ToString("e2"));
            decimal universe = 46500000000m * 9450000000000m;
            Console.WriteLine(universe.ToString("e2"));
        }
    }
}
