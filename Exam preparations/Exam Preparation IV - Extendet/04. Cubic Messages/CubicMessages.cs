using System;
using System.Text;

public class CubicMessages
{
    static string firstPart;
    static string midlePart;
    static string lastPart;
    static string lastPartDigits;
    static int[] indexes;
    static int index;

    static StringBuilder outputMessage;

    public static void Main()
    {
        ReadEncryptedMessagesUntillOverFrom($@"{Console.ReadLine()}");
    }

    static void ReadEncryptedMessagesUntillOverFrom(string input)
    {
        if (input != "Over!")
        {
            var lettersInValidMessage = Convert.ToInt32(Console.ReadLine());

            index = 0;
            DigitsAtStart(input);
            LettersInTheMidle(input, lettersInValidMessage);
            NoLettersAtEnd(input);

            if (IsValidMessage(input, lettersInValidMessage))
            {
                ConvertAllDigitsAsIndexes();
                DecryptToOutputMessage();
                Console.WriteLine($"{midlePart} == {outputMessage}");
            }
            ReadEncryptedMessagesUntillOverFrom($@"{Console.ReadLine()}");
        }
    }

    static void DigitsAtStart(string input)
    {
        firstPart = string.Empty;
        for (int i = index; i < input.Length; i++)
        {
            if (input[i] >= '0' && input[i] <= '9')
            {
                firstPart += input[i];
            }
            else
            {
                index = i; break;
            }
        }
    }

    static void LettersInTheMidle(string input, int lettersInValidMessage)
    {
        midlePart = string.Empty;
        for (int i = index; i < input.Length; i++)
        {
            if ((input[i] >= 'a' && input[i] <= 'z') || (input[i] >= 'A' && input[i] <= 'Z'))
            {
                midlePart += input[i];
            }
            else
            {
                index = i; break;
            }
        }
    }

    static void NoLettersAtEnd(string input)
    {
        lastPart = string.Empty;
        lastPartDigits = string.Empty;
        for (int i = index; i < input.Length; i++)
        {
            if ((input[i] < 'a' || input[i] > 'z') && (input[i] < 'A' || input[i] > 'Z'))
            {
                lastPart += input[i];
                if (input[i] >= '0' && input[i] <= '9')
                {
                    lastPartDigits += input[i];
                }
            }
            else
            {
                index = i; break;
            }
        }
    }

    static bool IsValidMessage(string input, int lettersInValidMessage)
    {
        var partsLength = (firstPart + midlePart + lastPart).Length;
        return midlePart.Length == lettersInValidMessage && partsLength == input.Length;
    }

    static void ConvertAllDigitsAsIndexes()
    {
        var indexesAsString = firstPart + lastPartDigits;
        indexes = new int[(firstPart + lastPartDigits).Length];

        for (int i = 0; i < indexesAsString.Length; i++)
        {
            indexes[i] = Convert.ToInt32(indexesAsString[i].ToString());
        }
    }

    static void DecryptToOutputMessage()
    {
        outputMessage = new StringBuilder();
        for (int i = 0; i < indexes.Length; i++)
        {
            if (midlePart.Length - 1 >= indexes[i])
            {
                outputMessage = outputMessage.Append(midlePart[indexes[i]]);
            }
            else
            {
                outputMessage = outputMessage.Append(' ');
            }
        }
    }
}
