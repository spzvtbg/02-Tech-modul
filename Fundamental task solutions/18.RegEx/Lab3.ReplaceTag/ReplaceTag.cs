﻿namespace Lab3.ReplaceTag
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class ReplaceTag
    {
        public static void Main()
        {
            var stringBuilder = new StringBuilder();

            var inputString = Console.ReadLine();

            var currentString = string.Empty;

            while (inputString != "end")
            {
                currentString = stringBuilder.AppendLine(inputString).ToString();

                inputString = Console.ReadLine();
            }

            var regex = new Regex(@"<a\s*href=(.+?)>(.+?)<\/a>");

            var textToReplace = regex.Match(currentString);

            var replacement = "[URL href=$1]$2[/URL]";

            var replaced = regex.Replace(textToReplace.Value, replacement);

            var result = currentString.Replace(textToReplace.Value, replaced);

            Console.WriteLine(result);
        }
    }
}
