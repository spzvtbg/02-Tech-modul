using System;
using System.Collections.Generic;
using System.Linq;
namespace _02.JapaneseRoulette
{
    class JapaneseRoulette
    {
        static void Main()
        {
            List<int> cylinder = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<string> players = Console.ReadLine().Split(' ').ToList();

            bool isDead = false;
            string pull = string.Empty;
            int place = cylinder.IndexOf(1) + 1;

            for (int a = 0; a < players.Count; a++)
            {
                string[] player = players[a].Split(',').ToArray();
                string direction = player[1];
                int strenght = int.Parse(player[0]);

                if (direction == "Left")
                {
                    place = 6 - Math.Abs(strenght - place) % 6;
                }
                else if (direction == "Right")
                {
                    place = Math.Abs(strenght + place) % 6;
                }

                if (place == 3)
                {
                    pull = $"Game over! Player {a} is dead.";
                    isDead = true;
                    break;
                }
                else
                {
                    place = place >= 1 && place < 6 ? place += 1 : 1;
                }
            }
            Console.WriteLine(isDead ? pull : "Everybody got lucky!");
        }
    }
}
