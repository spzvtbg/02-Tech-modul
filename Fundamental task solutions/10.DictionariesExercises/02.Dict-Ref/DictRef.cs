namespace _02.Dict_Ref
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DictRef
    {
        public static void Main()
        {
            Dictionary<string, int> resultDict = new Dictionary<string, int>();
            string line = Console.ReadLine();           
            while (line != "end")
            {
                string[] tokens = line.Split(' ').ToArray();
                var first = tokens[0];
                var last = tokens[tokens.Length - 1];

                var number = 0;
                if (int.TryParse(last, out number))
                {
                    resultDict[first] = number;
                }
                else
                {
                    if (resultDict.ContainsKey(last))
                    {
                        var referencedValue = resultDict[last];
                        resultDict[first] = referencedValue;
                    }
                }

                line = Console.ReadLine();
            }
            foreach (var part in resultDict)
            {
                Console.WriteLine($"{part.Key} === {part.Value}");
            }
        }
    }
}
