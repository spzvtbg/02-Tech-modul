namespace _03.EnduranceRally
{
    using System;
    using System.Linq;
  
    public class EnduranceRally
    {
        public static void Main()
        {
            var players = Console.ReadLine().Split().Select(x => x.Trim()).ToArray();

            var positions = Console.ReadLine().Split().Select(double.Parse).ToArray();

            var chekPoints = Console.ReadLine().Split().Select(double.Parse).ToArray();

            foreach (var player in players)
            {
                double fuel = player[0];

                var hasFinished = true;

                for (int i = 0; i < positions.Length; i++)
                {
                    if (chekPoints.Contains(i))
                    {
                        fuel += positions[i];
                    }
                    else
                    {
                        fuel -= positions[i];
                    }
                    if (fuel <= 0)
                    {
                        Console.WriteLine($"{player} - reached {i}");

                        hasFinished = false;

                        break;
                    }
                }

                if (hasFinished)
                {
                    Console.WriteLine($"{player} - fuel left {fuel:F2}");
                }
            }
        }
    }
}
