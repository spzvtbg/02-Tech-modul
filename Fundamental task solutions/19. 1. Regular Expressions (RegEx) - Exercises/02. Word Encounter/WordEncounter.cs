using System;
using System.Text;
using System.Text.RegularExpressions;

public class WordEncounter
{
    static string symbol;
    static int count;

    static string sentencePattern = @"^[A-Z].+[.!?]$";
    static string wordPattern = @"\w+";

    static bool isFirst = true;
    static StringBuilder result = new StringBuilder();
       
    public static void Main()
    {
        var wordKey = Console.ReadLine();
        symbol = $"{wordKey[0]}";
        count = Convert.ToInt32($"{wordKey[1]}");

        ReadNextSentencesFrom(Console.ReadLine());
        Console.WriteLine(result);
    }

    static void ReadNextSentencesFrom(string inputSentence)
    {
        if (inputSentence != "end")
        {
            Match(inputSentence);
            ReadNextSentencesFrom(Console.ReadLine());
        }
    }

    static void Match(string inputSentence)
    {
        if (Regex.IsMatch(inputSentence, sentencePattern))
        {
            var allMatchedWords = Regex.Matches(inputSentence, wordPattern);
            Append(allMatchedWords);
        }
    }

    static void Append(MatchCollection allMatchedWords)
    {
        foreach (Match word in allMatchedWords)
        {
            var matches = Regex.Matches(word.Value, symbol);
            if (matches.Count >= count)
            {
                if (isFirst)
                {
                    result.Append(word);
                    isFirst = false;
                    continue;
                }
                result.Append($", {word}");
            }
        }
    }
}
