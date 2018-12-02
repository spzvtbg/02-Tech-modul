using System;
using System.Text.RegularExpressions;

public class MatchHexadecimalNumbers
{
    public static void Main()
    {
        var pattern = @"\b(?:0x)?[0-9A-F]+\b";
        var regex = new Regex(pattern);
        var hexidecimalNumbers = regex.Matches(Console.ReadLine());

        foreach (var match in hexidecimalNumbers)
        {
            Console.Write($"{match} ");
        }
    }
}
