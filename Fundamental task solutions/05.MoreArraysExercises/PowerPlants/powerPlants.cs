using System;
using System.Linq;
namespace PowerPlants
{
    public class powerPlants
    {
        public static void Main()
        {
            int[] p = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int ctr = -1;
            int days = 0;
            int sum = 0;
            int value = 0;

            CalculateAll(p, ref ctr, ref days, ref sum, ref value);
            string seasons = ctr / p.Length == 1 ? "season" : "seasons";

            Console.WriteLine($"survived {ctr + 1} days ({ctr / p.Length} {seasons})");
        }

        private static void CalculateAll(int[] p, ref int ctr, ref int days, ref int sum, ref int value)
        {
            for (int a = 0; a <= int.MaxValue; a++)
            {
                ctr++;
                sum = 0;
                PlantsPower(p, days, ref sum, ref value);
                days++;
                days = days == p.Length ? days = 0 : days += 0;
                if (days % p.Length == 0)
                {
                    NewSeason(p, sum);
                }
                if (sum == 0)
                {
                    break;
                }
            }
        }

        private static void PlantsPower(int[] p, int days, ref int sum, ref int value)
        {
            for (int c = 0; c < p.Length; c++)
            {
                p[c] = days == c ? p[c] : p[c] - 1;
                value = p[c] <= 0 ? p[c] = 0 : p[c] = p[c];
                sum += value;
            }
        }

        private static int[] NewSeason(int[] p, int sum)
        {
            if (sum > 0)
            {
                for (int i = 0; i < p.Length; i++)
                {
                    p[i] = p[i] > 0 ? p[i] += 1 : p[i] += 0;
                }
            }
            return p;
        }
    }
}
