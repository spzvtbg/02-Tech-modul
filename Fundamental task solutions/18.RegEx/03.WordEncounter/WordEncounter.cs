namespace _03.WordEncounter
{
    using System;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
   
    public class WordEncounter
    {
        public static void Main()
        {
            var matches = new List<string>();

            var regex = new Regex(@"^[A-Z].*[.!?]$");

            var filter = Console.ReadLine();

            var sentence = Console.ReadLine();

            while (sentence != "end")
            {
                if (regex.IsMatch(sentence))
                {
                    var words = new Regex(@"\w+");

                    var currentWords = words.Matches(sentence);

                    foreach (Match word in currentWords)
                    {
                        var match = new Regex($"{filter[0]}");

                        var nTimesMatch = match.Matches(word.Value).Count;

                        if (nTimesMatch >= int.Parse(filter[1].ToString()))
                        {
                            matches.Add(word.Value);
                        }
                    }
                }

                sentence = Console.ReadLine();
            }

            Console.WriteLine(string.Join(", ", matches));
        }
    }
}
