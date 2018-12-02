using System;
using System.Linq;
using System.Collections.Generic;
namespace Camel_sBack
{
    public class camelsBack
    {
        public static void Main()
        {
            List<int> cityLenght = Console.ReadLine().Split().Select(int.Parse).ToList();
            int needLenght = int.Parse(Console.ReadLine());
            int rounds = (cityLenght.Count - needLenght) / 2;
            if (cityLenght.Count == needLenght)
            {
                Console.WriteLine($"already stable: {string.Join(" ", cityLenght)}");
            }
            else
            {
                cityLenght = ReducingLenght(rounds, cityLenght);
                Console.WriteLine($"{rounds} rounds\nremaining: {string.Join(" ", cityLenght)}");
            }
        }

        private static List<int> ReducingLenght(int n, List<int> cityLenght)
        {
            for (int i = 0; i < n; i++)
            {
                cityLenght.RemoveAt(cityLenght.Count - 1);
                cityLenght.RemoveAt(0);
            }
            return cityLenght;
        }
    }
}