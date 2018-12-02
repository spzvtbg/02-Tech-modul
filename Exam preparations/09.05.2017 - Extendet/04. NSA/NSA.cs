using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class NSA
{
    public static void Main()
    {
        var spysByCountryAndDaysAway = new Dictionary<string, Dictionary<string, int>>();
        for (int infiniatly = 0; ; infiniatly++)
        {
            var countrySpyDaysAway = Console.ReadLine();
            if (countrySpyDaysAway == "quit") { break; }

            var patern = @"^(?<country>[a-zA-Z0-9-_]+)\s->\s(?<spy>[a-zA-Z0-9-_]+)\s->\s(?<days>[0-9]+)$";
            var splittedData = new Regex(patern);
            var matches = splittedData.Match(countrySpyDaysAway);

            var country = matches.Groups["country"].Value;
            var spyName = matches.Groups["spy"].Value;
            var daysAway = Convert.ToInt32(matches.Groups["days"].Value);

            if (!spysByCountryAndDaysAway.ContainsKey(country))
            {
                spysByCountryAndDaysAway[country] = new Dictionary<string, int>();
            }
            if (!spysByCountryAndDaysAway[country].ContainsKey(spyName))
            {
                spysByCountryAndDaysAway[country][spyName] = 0;
            }
            spysByCountryAndDaysAway[country][spyName] = daysAway;
        }

        foreach (var country in spysByCountryAndDaysAway.OrderByDescending(x => x.Value.Count))
        {
            Console.WriteLine($"Country: {country.Key}");
            foreach (var spyDaysAway in country.Value.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"**{spyDaysAway.Key} : {spyDaysAway.Value}");
            }
        }
    }
}
