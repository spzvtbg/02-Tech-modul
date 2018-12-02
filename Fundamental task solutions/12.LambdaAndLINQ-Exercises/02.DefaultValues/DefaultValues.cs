namespace _02.DefaultValues
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DefaultValues
    {
        public static void Main()
        {
            var valuePairs = new Dictionary<string, string>();
            var input = Console.ReadLine().Split(" ->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

            while (input[0] != "end")
            {
                valuePairs[input[0]] = input[1];

                input = Console.ReadLine().Split(" ->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            var defaultValue = Console.ReadLine();


            valuePairs.Where(x => x.Value != "null")
                .OrderByDescending(x => x.Value.Length)
               .ToList().ForEach(x => Console.WriteLine($"{x.Key} <-> {x.Value}"));

            valuePairs.Where(x => x.Value == "null")
                .Select(x => x.Key + " <-> " + defaultValue)
                .ToList().ForEach(Console.WriteLine);

            //valuePairs.Where(x => x.Value == "null")
            //    .ToList().ForEach(x => Console.WriteLine($"{x.Key} <-> {defaultValue}"));


            //var unChanged = valuePairs.Where(x => x.Value != "null")
            //    .OrderByDescending(x => x.Value.Length)
            //    .ToDictionary(x => x.Key, x => x.Value);

            //foreach (var item in unChanged)
            //{
            //    Console.WriteLine($"{item.Key} <-> {item.Value}");
            //}

            //var Changed = valuePairs.Where(x => x.Value == "null")
            //    .ToDictionary(x => x.Key, x => defaultValue);

            //foreach (var item in Changed)
            //{
            //    Console.WriteLine($"{item.Key} <-> {item.Value}");
            //}
        }
    }
}
