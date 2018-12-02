using System;
using System.Text.RegularExpressions;

public class MatchNumbers
{
    public static void Main()
    {
        var regex = new Regex(@"(^|(?<=\s))-?\d+(\.\d+)?($|(?=\s))");
        var currentNumbers = regex.Matches(Console.ReadLine());

        foreach (var number in currentNumbers)
        {
            Console.Write(number + " ");
        }
        Console.WriteLine();
    }
}
