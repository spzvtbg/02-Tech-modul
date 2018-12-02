using System;
public class SentenceSplit
{
    public static void Main()
    {
        var sentenses = Console.ReadLine();
        var delimiter = Console.ReadLine();

        sentenses = sentenses.Replace(delimiter, ", ");
        Console.WriteLine($"[{sentenses}]");
    }
}
