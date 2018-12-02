using System;
using System.Linq;
using System.Collections.Generic;

public class SpyGram
{ 
    static byte[] keyToByteArray;
        
    public static void Main()
    {
        var allEncryptedMessages = new Dictionary<string, List<string>>();
        var privateKey = Console.ReadLine();
        var indexDivider = privateKey.Length;
        keyToByteArray = ParseToByteArray(privateKey);

        var encryptedMessage = string.Empty;
        for (int infiniatly = 0; ; infiniatly++)
        {
            var inputMessage = Console.ReadLine();
            if (inputMessage == "END") { break; }

            var currentSplitedMessage = inputMessage
                .Split(new string[] { ": ", "; " }, StringSplitOptions.RemoveEmptyEntries);
            var person = currentSplitedMessage[1];
            var toUpper = currentSplitedMessage[1].ToUpper();
            var to = currentSplitedMessage[0];
            var message = currentSplitedMessage[2];

            if (to == "TO" && message == "MESSAGE" && person == toUpper)
            {
                if (!allEncryptedMessages.ContainsKey(person))
                {
                    allEncryptedMessages[person] = new List<string>();
                }
                encryptedMessage = ProcessEncrypting(inputMessage, indexDivider);
                allEncryptedMessages[person].Add(encryptedMessage);
            }
        }
        PrintSortedEncryptedMessagesFrom(allEncryptedMessages);
    }

    static byte[] ParseToByteArray(string privateKey)
    {
        var temporaryByteArray = new byte[privateKey.Length];
        for (int index = 0; index < privateKey.Length; index++)
        {
            var currentSymbolAsNumber = Convert.ToByte(privateKey[index].ToString());
            temporaryByteArray[index] = currentSymbolAsNumber;
        }
        return temporaryByteArray;
    }

    static string ProcessEncrypting(string inputMessage, int divider)
    {
        var encryptedMessage = string.Empty;
        for (int index = 0; index < inputMessage.Length; index++)
        {
            var keyIndex = index == 0 ? 0 : index % divider;
            var keyNumber = keyToByteArray[keyIndex];
            var currentSymbol = inputMessage[index] + keyNumber;
            encryptedMessage += (char)currentSymbol;
        }
        return encryptedMessage;
    }

    private static void PrintSortedEncryptedMessagesFrom(
        Dictionary<string, List<string>> allEncryptedMessages)
    {
        foreach (var person in allEncryptedMessages.OrderBy(x => x.Key))
        {
            foreach (var message in person.Value)
            {
                Console.WriteLine(message);
            }
        }
    }
}
