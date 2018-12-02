using System;
using System.Collections.Generic;
using System.Linq;

public class LINQuistics
{
    public static void Main()
    {
        var collection = new Dictionary<string, HashSet<string>>();
        var input = Console.ReadLine().Split(" .()".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
        while (input[0] != "exit")
        {
            if (input.Count > 1)
            {
                var collectionsName = input[0];
                input.RemoveAt(0);
                if (!collection.ContainsKey(collectionsName))
                {
                    collection[collectionsName] = new HashSet<string>();
                }
                foreach (var method in input)
                {
                    collection[collectionsName].Add(method);
                }
            }
            else
            {
                int number = 0;
                if (int.TryParse(input[0], out number))
                {
                    collection.Values.OrderByDescending(coll => coll.Count).Take(1).ToList()
                        .ForEach(x => Console.WriteLine(
                            $"* {string.Join("\n* ", x.OrderBy(m => m.Length).Take(number))}"));
                }
                else
                {
                    if (collection.ContainsKey(input[0]))
                    {
                        collection[input[0]].OrderByDescending(x => x.Length).ThenByDescending(x => x.Distinct().Count()).ToList()
                            .ForEach(x => Console.WriteLine($"* {x}"));
                    }
                }
            }

            input = Console.ReadLine().Split(" .()".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
        }
        var LastInput = Console.ReadLine().Split(" .()".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

        if (LastInput[1] == "all")
        {
            var resultCollection = collection.OrderByDescending(coll => coll.Value.Count)
                .ThenByDescending(coll => coll.Value.Min(meth => meth.Length));
            foreach (var item in resultCollection.Where(coll => coll.Value.Contains(LastInput[0])))
            {
                Console.WriteLine(item.Key);
                foreach (var meth in item.Value.OrderByDescending(i => i.Length))
                {
                    Console.WriteLine($"* {meth}");
                }
            }
        }
        else
        {
            var resultCollection = collection.OrderByDescending(coll => coll.Value.Count)
               .ThenByDescending(coll => coll.Value.Min(meth => meth.Length));
            foreach (var item in resultCollection.Where(coll => coll.Value.Contains(LastInput[0])))
            {
                Console.WriteLine(item.Key);
            }
        }
    }
}
