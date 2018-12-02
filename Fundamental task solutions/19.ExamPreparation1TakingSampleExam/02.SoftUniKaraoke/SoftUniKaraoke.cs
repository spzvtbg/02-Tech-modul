namespace _02.SoftUniKaraoke
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SoftUniKaraoke
    {
        public static void Main()
        {
            var participants = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)

                .Select(x => x.Trim()).ToArray();

            var songsList = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)

                .Select(x => x.Trim()).ToArray();

            var nextLine = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                
                .Select(x => x.Trim()).ToArray();

            var awardsList = new Dictionary<string, List<string>>();

            while (nextLine[0] != "dawn")
            {
                var name = nextLine[0];

                var song = nextLine[1];

                var award = nextLine[2];

                if (participants.Contains(name) && songsList.Contains(song))
                {
                    if (!awardsList.ContainsKey(name))
                    {
                        awardsList[name] = new List<string>();
                    }
                    if (!awardsList[name].Contains(award))
                    {
                        awardsList[name].Add(award);
                    }
                }

                nextLine = Console.ReadLine().Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)

                    .Select(x => x.Trim()).ToArray();
            }

            if (awardsList.Values.Count == 0)
            {
                Console.WriteLine("No awards");
            }
            else
            {
                foreach (var item in awardsList.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{item.Key}: {item.Value.Count} awards");

                    foreach (var awards in item.Value.OrderBy(x => x))
                    {
                        Console.WriteLine("--" + awards);
                    }
                }
            }
        }
    }
}
