using System;
using System.Collections.Generic;
using System.Linq;
namespace _01.RabbitHole
{
    class RabbitHole
    {
        static void Main()
        {
            List<string> ways = Console.ReadLine().Split().ToList();
            int lifePoints = int.Parse(Console.ReadLine());

            int step = 0;
            string result = string.Empty;
            List<string> comand = ways[step].Split('|').ToList();

            while (lifePoints > 0)
            {
                if (comand[0] == "Left")
                {
                    lifePoints -= int.Parse(comand[1]);
                    step = (int.Parse(comand[1]) - step) % ways.Count;

                }
                else if (comand[0] == "Right")
                {
                    lifePoints -= int.Parse(comand[1]);
                    step = (int.Parse(comand[1]) + step) % ways.Count;
                }
                else if (comand[0] == "Bomb")
                {
                    lifePoints -= int.Parse(comand[1]);
                    if (lifePoints <= 0)
                    {
                        result = "You are dead due to bomb explosion!";
                        break;
                    }
                    ways.RemoveAt(step);
                    step = 0;
                }
                else if (comand[0] == "RabbitHole")
                {
                    result = "You have 5 years to save Kennedy!";
                    break;
                }
                if (lifePoints <= 0)
                {
                    result = "You are tired. You can't continue the mission.";
                    break;
                }
                List<string> last = ways[ways.Count - 1].Split('|').ToList();
                if (last[0] != "RabbitHole")
                {
                    ways.RemoveAt(ways.Count - 1);
                    ways.Add($"Bomb|{lifePoints}");
                }
                else
                {
                    ways.Add($"Bomb|{lifePoints}");
                }
                comand = ways[step].Split('|').ToList();
            }
            Console.WriteLine(result);
        }
    }
}