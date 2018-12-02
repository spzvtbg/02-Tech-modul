namespace _03.FlattenDictionary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FlattenDictionary
    {
        public static void Main()
        {
            var dictionary = new Dictionary<string, Dictionary<string, string>>();
            var input = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

            while (input[0] != "end")
            {
                if (input[0] != "flatten")
                {
                    var key = input[0];
                    var innerKey = input[1];
                    var value = input[2];

                    if (!dictionary.ContainsKey(key))
                    {
                        dictionary.Add(key, new Dictionary<string, string>());
                    }
                    dictionary[key][innerKey] = value;
                }
                else
                {
                    var flatt = input[1];
                    dictionary[flatt] = dictionary[flatt].ToDictionary(x => x.Key + x.Value, x => "flattened");
                }

                input = Console.ReadLine().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            }

            var ordered = dictionary.OrderByDescending(x => x.Key.Length).ToDictionary(x => x.Key, x => x.Value);

            foreach (var line in ordered)
            {
                Console.WriteLine(line.Key);

                var innerOrdered = line.Value.Where(x => x.Value != "flattened")
                    .OrderBy(x => x.Key.Length).ToDictionary(x => x.Key, x => x.Value);

                var flattened = line.Value.Where(x => x.Value == "flattened").ToDictionary(x => x.Key, x => x.Value);

                var count = 1;
                foreach (var item in innerOrdered)
                {
                    Console.WriteLine($"{count}. {item.Key} - {item.Value}");
                    count++;
                }
                
                foreach (var item in flattened)
                {
                    Console.WriteLine($"{count}. {item.Key}");
                    count++;
                }
            }
        }
    }
}
