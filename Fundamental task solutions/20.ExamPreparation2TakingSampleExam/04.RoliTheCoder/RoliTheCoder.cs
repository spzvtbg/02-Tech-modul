namespace _04.RoliTheCoder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RoliTheCoder
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var events = new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            while (input != "Time for Code")
            {
                var eventLine = input.Split(new[] { ' ', '\t', '\n', '\r' },

                             StringSplitOptions.RemoveEmptyEntries)

                             .Select(e => e.Trim()).ToArray();
                var number = 0;

                if (eventLine[1][0] == '#')
                {
                    if (events.ContainsKey(eventLine[0]) &&

                        !events[eventLine[0]].ContainsKey(eventLine[1]))
                    {
                        input = Console.ReadLine();

                        continue;
                    }

                    if (!events.ContainsKey(eventLine[0]))
                    {
                        events[eventLine[0]] = new Dictionary<string, SortedSet<string>>();
                    }

                    if (!events[eventLine[0]].ContainsKey(eventLine[1]))
                    {
                        events[eventLine[0]][eventLine[1]] = new SortedSet<string>();
                    }

                    foreach (var item in eventLine.Skip(2))
                    {
                        if (item[0] == '@')
                        {
                            events[eventLine[0]][eventLine[1]].Add(item);
                        }
                    }

                }

                input = Console.ReadLine();
            }

            var output = new Dictionary<string, SortedSet<string>>();

            foreach (var keyID in events)
            {
                foreach (var line in keyID.Value)
                {
                    output[line.Key] = line.Value;
                }
            }

            foreach (var item in output.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {

                Console.WriteLine($"{item.Key.Remove(0, 1)} - {item.Value.Count}");

                if (item.Value.Count == 0)
                {
                    continue;
                }

                Console.WriteLine(string.Join(Environment.NewLine, item.Value));

            }
        }
    }
}
