using System;
using System.Text.RegularExpressions;

public class Regexmon
{
    public static void Main()
    {
        var stringLine = Console.ReadLine();

        var didimonPatern = @"(?<didimon>[^-a-zA-Z]+)";
        var didimonRegex = new Regex(didimonPatern);

        var bojomonPatern = @"(?<bojomon>[a-zA-Z]+-[a-zA-Z]+)";
        var bojomonRegex = new Regex(bojomonPatern);

        for (int infiniatly = 0; ; infiniatly++)
        {
            if (stringLine.Length == 0)
            {
                return;
            }
            if (infiniatly % 2 == 0)
            {
                var didimonMatch = didimonRegex.Match(stringLine).Groups["didimon"].Value;
                if (didimonMatch.Length > 0)
                {
                    Console.WriteLine(didimonMatch);
                    var index = stringLine.IndexOf(didimonMatch);
                    stringLine = stringLine.Remove(0, didimonMatch.Length + index);
                }
                else return;
            }
            else
            {
                var bojomonMatch = bojomonRegex.Match(stringLine).Groups["bojomon"].Value;
                if (bojomonMatch.Length > 0)
                {
                    Console.WriteLine(bojomonMatch);
                    var index = stringLine.IndexOf(bojomonMatch);
                    stringLine = stringLine.Remove(0, bojomonMatch.Length + index);
                }
                else return;
            }
        }
    }
}
