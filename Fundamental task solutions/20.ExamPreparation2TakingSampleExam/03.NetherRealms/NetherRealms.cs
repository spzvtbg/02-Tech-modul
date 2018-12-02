namespace _03.NetherRealms
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class NetherRealms
    {
        public static void Main()
        {
            var demons = Console.ReadLine().Split(',').Select(x => x.Trim()).ToList();

            demons.Sort();

            var regex = new Regex(@"(\d+\.\d+)|(-\d+\.\d+)|(\d+)|(-\d+)");

            var listOfDemons = new List<string>();

            foreach (var demon in demons)
            {
                var demage = 0.0;

                foreach (Match n in regex.Matches(demon))
                {
                    demage += double.Parse(n.Value);
                }

                foreach (var item in demon)
                {
                    if (item == '/') { demage /= 2; }

                    if (item == '*') { demage *= 2; }
                }

                var currentDemon = demon;

                var symbols = new Regex(@"[0-9\+\-\*\/\.]");

                foreach (Match item in symbols.Matches(currentDemon))
                {
                    currentDemon = currentDemon.Replace(item.Value, "0");
                }
             
                var healthSum = 0;

                foreach (var x in currentDemon)
                {
                    if (x.ToString() != "0")
                    {
                        healthSum += x;
                    }
                }

                listOfDemons.Add($"{demon} - {healthSum} health, {demage:F2} damage");
            }

            Console.WriteLine(string.Join(Environment.NewLine, listOfDemons));
        }
    }
}