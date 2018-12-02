using System;
using System.Collections.Generic;
using System.Linq;

public class Broadcast
{
    public string Message { get; set; }
    public string Frequency { get; set; }
}

public class PrivateMessage
{
    public string Recipient { get; set; }
    public string Message { get; set; }
}

public class HornetComm
{
    static List<Broadcast> broadcasts = new List<Broadcast>();
    static List<PrivateMessage> privateMessages = new List<PrivateMessage>();

    static string first = string.Empty;
    static string second = string.Empty;

    public static void Main()
    {
        ReadNextLinesUntilHornetIsGreen(Console.ReadLine());
        PrintBroadCasts();
        PrintMessages();
    }

    static void PrintBroadCasts()
    {
        Console.WriteLine("Broadcasts:");
        if (broadcasts.Count == 0)
        {
            Console.WriteLine("None"); return;
        }
        broadcasts.ForEach(x => Console.WriteLine($"{x.Frequency} -> {x.Message}"));
    }

    static void PrintMessages()
    {
        Console.WriteLine("Messages:");
        if (privateMessages.Count == 0)
        {
            Console.WriteLine("None"); return;
        }
        privateMessages.ForEach(x => Console.WriteLine($"{x.Recipient} -> {x.Message}"));
    }

    static void ReadNextLinesUntilHornetIsGreen(string input)
    {
        if (input != "Hornet is Green")
        {
            var length = SplitCurrent(input);
            if (length == 2)
            {
                if (!IsPrivateMessage())
                {
                    ParseInPrivatMessages();
                }
                else if (!IsBroadCast())
                {
                    ParseInBroadcast();
                }
            }
            ReadNextLinesUntilHornetIsGreen(Console.ReadLine());
        }
        else return;
    }

    static int SplitCurrent(string input)
    {
        var splited = input.Split(new[] { " <-> " }, StringSplitOptions.RemoveEmptyEntries);
        if (splited.Length == 1)
        {
            return 1;
        }
        first = splited[0];
        second = splited[1];
        return splited.Length;
    }

    static bool IsPrivateMessage()
    {
        return first.ToList().Any(x => x < '0' || x > '9') ||
            second.ToList().Any(x => (x < '0' || x > '9') && (x < 'a' || x > 'z') && (x < 'A' || x > 'Z'));
    }

    static void ParseInPrivatMessages()
    {
        var newPrivateMessage = new PrivateMessage();
        newPrivateMessage.Recipient = string.Join("", first.Reverse());
        newPrivateMessage.Message = second;
        privateMessages.Add(newPrivateMessage);
    }

    static bool IsBroadCast()
    {
        return first.ToList().Any(x => x >= '0' && x <= '9') ||
            second.ToList().Any(x => (x < '0' || x > '9') && (x < 'a' || x > 'z') && (x < 'A' || x > 'Z'));
    }

    static void ParseInBroadcast()
    {
        second = ReplaceSecond();
        var newBroadcast = new Broadcast();
        newBroadcast.Message = first;
        newBroadcast.Frequency = second;
        broadcasts.Add(newBroadcast);
    }

    static string ReplaceSecond()
    {
        var returnedString = string.Empty;
        foreach (var symbol in second)
        {
            returnedString += 
                symbol >= 'a' && symbol <= 'z' ?
                symbol.ToString().ToUpper() : 
                symbol.ToString().ToLower();
        }
        return returnedString;
    }
}