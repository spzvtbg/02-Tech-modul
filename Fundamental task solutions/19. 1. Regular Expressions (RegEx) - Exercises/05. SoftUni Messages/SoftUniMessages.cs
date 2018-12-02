using System;
using System.Text;
using System.Text.RegularExpressions;

public class SoftUniMessages
{
    static StringBuilder encryptedMessage;
    static string message;
    static int[] indexes;

    static string pattern = @"^(?<first>\d+)(?<string>[a-zA-Z]*.*?)(?<last>\d+)$";
    static string letterPattern = @"\b(?<letters>[a-zA-Z]*)\b";

    public static void Main()
    {
        ReadNextMessagesFrom(Console.ReadLine());
    }

    static void ReadNextMessagesFrom(string decryptedMessage)
    {
        if (decryptedMessage != "Decrypt!")
        {
            var mustSymbols = Convert.ToInt32(Console.ReadLine());

            if (Regex.IsMatch(decryptedMessage, pattern))
            {
                ConvertAndPrint(decryptedMessage, mustSymbols);
            }

            ReadNextMessagesFrom(Console.ReadLine());
        }
    }

    static void ConvertAndPrint(string decryptedMessage, int mustSymbols)
    {
        var match = Regex.Match(decryptedMessage, pattern);
        var matched = match.Groups["string"].Value;
        if (!Regex.IsMatch(matched, letterPattern))
        {
            message = Regex.Match(matched, letterPattern).Groups["letters"].Value;
        }

        if (message.Length == mustSymbols)
        {
            var digits = match.Groups["first"].Value + match.Groups["last"].Value;
            ConvertToIntegerArray(digits);
            EncryptThatDecryptedMessage();
            Console.WriteLine($"{message} = {encryptedMessage}");
        }
    }

    static void ConvertToIntegerArray(string digits)
    {
        indexes = new int[digits.Length];
        for (int count = 0; count < digits.Length; count++)
        {
            indexes[count] = digits[count] - '0';
        }
    }

    static void EncryptThatDecryptedMessage()
    {
        encryptedMessage = new StringBuilder();
        var messageLength = message.Length - 1;
        for (int count = 0; count < indexes.Length; count++)
        {
            var index = indexes[count];
            if (index >= 0 && index <= messageLength)
            {
                encryptedMessage.Append(message[index]);
            }
        }
    }
}
