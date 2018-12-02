using System;
using System.Collections.Generic;
using System.Linq;

public class DefaultValues
{
    static string key = string.Empty;
    static string value = string.Empty;
    static Dictionary<string, string> keyValuePairs = 
        new Dictionary<string, string>();

    public static void Main()
    {
        ReadingWhileNotEnd(Console.ReadLine());
        PrintAllKeysWithValidValues();
        PrintAllKeysWithoutValidValues(Console.ReadLine());
    }

    static void ReadingWhileNotEnd(string entered)
    {
        if (entered != "end")
        {
            ParseKeysValuesFrom(entered);
            AddToCollectionKeysValuesPairs();
            ReadingWhileNotEnd(Console.ReadLine());
        }
        else return;
    }

    static void ParseKeysValuesFrom(string entered)
    {
        var splited = entered.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
        key = splited[0];
        value = splited[1];
    }

    static void AddToCollectionKeysValuesPairs()
    {
        if (!keyValuePairs.ContainsKey(key))
        {
            keyValuePairs[key] = string.Empty;
        }
        keyValuePairs[key] = value;
    }

    static void PrintAllKeysWithValidValues()
    {
        foreach (var item in keyValuePairs
            .Where(x => x.Value != "null").OrderByDescending(x => x.Value.Length))
        {
            Console.WriteLine($"{item.Key} <-> {item.Value}");
        }
    }

    static void PrintAllKeysWithoutValidValues(string replace)
    {
        foreach (var item in keyValuePairs
            .Where(x => x.Value == "null").OrderByDescending(x => x.Value.Length))
        {
            Console.WriteLine($"{item.Key} <-> {replace}");
        }
    }
}
