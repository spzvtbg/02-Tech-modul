using System;
using System.Text.RegularExpressions;

public class Cards
{
    public static void Main()
    {
        var pattern = @"(?<![0-9])(?:([2-9]|10)|(A|K|Q|J))+(S|H|D|C)";
        var regex = new Regex(pattern);
        var validCardsAre = regex.Matches(Console.ReadLine());

        var isFirst = true;
        foreach (var card in validCardsAre)
        {
            if (isFirst)
            {
                Console.Write(card);
                isFirst = false;
                continue;
            }
            Console.Write($", {card}");
        }
        Console.WriteLine();
    }
}
