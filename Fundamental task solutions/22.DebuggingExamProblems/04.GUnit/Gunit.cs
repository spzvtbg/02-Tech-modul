namespace _04.GUnit
{
    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    using System.Linq;
  
    public class Gunit // 10 / 100 ???
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var regex = new Regex(@"^([A-Z][A-Za-z0-9]+)( \| )([A-Z][A-Za-z0-9]+)\2([A-Z][A-Za-z0-9]+)$");

            var isMatch = regex.IsMatch(input);

            var classCollection = new Dictionary<string, Dictionary<string, List<string>>>();

            while (input != "It's testing time!")
            {
                if (isMatch)
                {
                    var match = regex.Match(input);

                    var className = match.Groups[1].ToString();

                    var methodName = match.Groups[3].ToString();

                    var unitTestName = match.Groups[4].ToString();

                    if (!classCollection.ContainsKey(className))
                    {
                        classCollection[className] = new Dictionary<string, List<string>>();
                    }
                    if (!classCollection[className].ContainsKey(methodName))
                    {
                        classCollection[className][methodName] = new List<string>();
                    }
                    if (!classCollection[className][methodName].Contains(unitTestName))
                    {
                        classCollection[className][methodName].Add(unitTestName);
                    }
                }

                input = Console.ReadLine();
            }

            var sortedDoubleDictionary = classCollection
                
                .OrderByDescending(x => x.Value.Values.Sum(y => y.Count))

                 .ThenBy(x => x.Value.Count).ThenBy(x => x.Key)
                 
                 .ToDictionary(x => x.Key, x => x.Value);

            foreach (var clas in sortedDoubleDictionary)
            {
                Console.WriteLine(clas.Key + ":");

                var sortedMethods = clas.Value;/*.OrderByDescending(m => m.Value.Count)
                  
                    .ThenBy(m => m.Key)

                    .ToDictionary(m => m.Key, m => m.Value);*/

                foreach (var method in sortedMethods.OrderByDescending(m => m.Value.Count)

                    .ThenBy(m => m.Key)

                    .ToDictionary(m => m.Key, m => m.Value))
                {
                    Console.WriteLine("##" + method.Key);

                    var sortedUnitTest = method.Value;/*.OrderBy(u => u.Length)

                        .ThenBy(u => u).ToList();*/

                    foreach (var unit in sortedUnitTest.OrderBy(u => u.Length)

                        .ThenBy(u => u).ToList())
                    {
                        Console.WriteLine("####" + unit);
                    }
                }
            }
        }
    }
}
