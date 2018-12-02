using System;
using System.Collections.Generic;
using System.Linq;

public class Website
{
    public string Host { get; set; }
    public string Domain { get; set; }
    public string[] Queries { get; set; }
}

public class Websites
{
    static string currentHost = string.Empty;
    static string currentDomain = string.Empty;
    static string[] currentQueries;

    static List<Website> websites = new List<Website>();

    public static void Main()
    {
        ReadSeveralInputLinesFrom(Console.ReadLine());
        PrintAllWebsites();
    }

    static void PrintAllWebsites()
    {
        foreach (var website in websites)
        {
            Console.Write($"https://www.{website.Host}.{website.Domain}");
            if (website.Queries.Length > 0)
                PrintAllQueries(website.Queries);
            Console.WriteLine();
        }
    }

    static void PrintAllQueries(string[] queries)
    {
        Console.Write("/query?=");
        var isFirst = true;
        foreach (var item in queries)
        {
            if (isFirst)
            {
                Console.Write($"[{item}]");
                isFirst = false;
                continue;
            }
            Console.Write($"&[{item}]");
        }
    }

    static void SplitCurrent(string input)
    {
        var splited = input.Split(new[] { " | ", "," }, StringSplitOptions.RemoveEmptyEntries);
        currentHost = splited[0];
        currentDomain = splited[1];
        currentQueries = new string[splited.Length - 2];
        if (splited.Length > 2)
        {
            currentQueries = splited.Skip(2).ToArray();
        }
    }

    static void ReadSeveralInputLinesFrom(string input)
    {
        if (input != "end")
        {
            SplitCurrent(input);
            AddCurentSplitedInput();
            ReadSeveralInputLinesFrom(Console.ReadLine());
        }
        else return;
    }

    static void AddCurentSplitedInput()
    {
        var newWebsite = new Website();
        newWebsite.Host = currentHost;
        newWebsite.Domain = currentDomain;
        newWebsite.Queries = currentQueries;
        websites.Add(newWebsite);
    }
}
