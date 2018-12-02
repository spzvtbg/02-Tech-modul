using System;
using System.Linq;

public class Placeholders
{
    static string sentense;
    static string[] words;
    static int[] placeholders;

    public static void Main()
    {
        ReadNextLinesUntillEndFrom(Console.ReadLine());
    }

    static void ReadNextLinesUntillEndFrom(string input)
    {
        if (input != "end")
        {
            DivideAndRule(input);
            ReadNextLinesUntillEndFrom(Console.ReadLine());
        }
        else return;
    }

    static void DivideAndRule(string input)
    {
        SplitCurrent(input);
        TakeThePlaceHolders();
        UpdateCurrentSentense();
        Console.WriteLine(sentense);
    }

    static void SplitCurrent(string input)
    {
        var patern = new[] { " -> " };
        var splitedInput = input.Split(patern, StringSplitOptions.RemoveEmptyEntries);
        sentense = splitedInput.First();

        var wordsPattern = new[] { ",", " " };
        words = splitedInput.Last().Split(wordsPattern, StringSplitOptions.RemoveEmptyEntries);
    }

    static void TakeThePlaceHolders()
    {
        var indexesAsString = string.Empty;
        var placeHolderIndex = -1; 
        for (int index = 0; index < sentense.Length; index++)
        {
            placeHolderIndex = sentense.IndexOf('{', index);
            index = placeHolderIndex;
            if (index != -1)
            {
                indexesAsString += $" {placeHolderIndex}";
            }
            else break;
        }
        ConvertToIntArray(indexesAsString.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries));
    }

    static void ConvertToIntArray(string[] indexesAsString)
    {
        placeholders = new int[indexesAsString.Length];
        for (int index = 0; index < indexesAsString.Length; index++)
        {
            placeholders[index] = Convert.ToInt32(indexesAsString[index]);
        }
    }

    static void UpdateCurrentSentense()
    {
        for (int index = placeholders.Length - 1; index >= 0; index--)
        {
            var currentPlaceholder = Convert.ToInt32(sentense[placeholders[index] + 1].ToString());
            sentense = sentense.Remove(placeholders[index], 3);
            var word = currentPlaceholder > words.Length - 1 ? 
                $"{{{currentPlaceholder}}}" : 
                words[currentPlaceholder];
            sentense = sentense.Insert(placeholders[index], word);
        }
    }
}
