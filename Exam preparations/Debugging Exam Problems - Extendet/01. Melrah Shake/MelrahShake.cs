using System;
using System.Text.RegularExpressions;

public class Program
{
    static string stringOfRandomCharacters;
    static string patern;

    public static void Main()
    {
        var workString = Console.ReadLine();

        var match = Console.ReadLine();

        var regex = new Regex(Regex.Escape(match));

        var matches = regex.Matches(workString);

        while (true)
        {
            if (matches.Count >= 2 && match.Length > 0)
            {
                var count = match.Length;

                var firstIndex = workString.IndexOf(match);

                var lastIndex = workString.LastIndexOf(match);

                workString = workString.Remove(lastIndex, count);

                workString = workString.Remove(firstIndex, count);

                match = match.Remove(count / 2, 1);

                Console.WriteLine("Shaked it.");
            }
            else
            {
                Console.WriteLine("No shake.");

                break;
            }

            regex = new Regex(Regex.Escape(match));

            matches = regex.Matches(workString);
        }

        Console.WriteLine(workString);
    }
}
