using System;
using System.Text.RegularExpressions;

public class MatchPhoneNumber
{
    public static void Main()
    {
        var pattern = @"\+359(\s|-)2\1\d{3}\1\d{4}";
        var regex = new Regex(pattern);
        var phoneNumbers = regex.Matches(Console.ReadLine());

        var isFirst = true;
        foreach (var number in phoneNumbers)
        {
            if (isFirst)
            {
                Console.Write(number);
                isFirst = false;
                continue;
            }
            Console.Write($", {number}");
        }
        Console.WriteLine();
    }
}
