using System;

public class WormIpsum
{
    static string[] words;

    public static void Main()
    {
        ReadCurrentInput(Console.ReadLine());
    }

    static void ReadCurrentInput(string givenSentence)
    {
        if (givenSentence != "Worm Ipsum" && givenSentence.Split(new[] { ". " }, 
            StringSplitOptions.RemoveEmptyEntries).Length > 1)
        {
            ReadCurrentInput(Console.ReadLine());
        }
        else if (givenSentence != "Worm Ipsum" && givenSentence.Split(new[] { ". " },
            StringSplitOptions.RemoveEmptyEntries).Length == 1)
        {
            Process(givenSentence);
            words[words.Length - 1] = ReplaceWithDot(words[words.Length - 1]);
            Console.WriteLine(PrintSentenceWithReplacedWords());
            ReadCurrentInput(Console.ReadLine());
        }
        else return;
    }

    static void Process(string givenSentence)
    {
        words = givenSentence.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        for (int index = 0; index < words.Length; index++)
        {
            words[index] = ReplaceSymbols(words[index]);
        }
    }

    static string ReplaceSymbols(string word)
    {
        var symbol = ' ';
        var charCounter = 0;
        for (int i = 0; i < word.Length; i++)
        {
            var tempCounter = 1;
            for (int l = i + 1; l < word.Length; l++)
            {
                if (word[i] == word[l])
                {
                    tempCounter++;
                }
            }
            if (tempCounter > charCounter)
            {
                charCounter = tempCounter;
                symbol = word[i];
            }
        }
        var newWord = string.Empty;
        if (charCounter > 1)
        {
            return newWord = ReplaceWithSymbol(symbol, word);
        }
        return word;
    }

    static string ReplaceWithSymbol(char symbol, string word)
    {
        var wordToReturn = string.Empty;
        for (int index = 0; index < word.Length; index++)
        {
            if (isAlphaNumericSymbol(word[index]))
            {
                wordToReturn += symbol;
            }
            else
            {
                wordToReturn += word[index];
            }
        }
        return wordToReturn;
    }

    static bool isAlphaNumericSymbol(char s)
    {
        return s >= 'a' && s <= 'z' || s >= 'A' && s <= 'Z' || s >= '0' && s <= '9';
    }

    private static string ReplaceWithDot(string lastWord)
    {
        var word = string.Empty;
        for (int index = 0; index < lastWord.Length - 1; index++)
        {
            word += lastWord[index];
        }
        return word += ".";
    }

    static string PrintSentenceWithReplacedWords()
    {
        var isFirst = true;
        var resultString = string.Empty;
        foreach (var word in words)
        {
            if (isFirst)
            {
                resultString += word;
                isFirst = false;
                continue;
            }
            resultString += $" {word}";
        }
        return resultString;
    }
}
