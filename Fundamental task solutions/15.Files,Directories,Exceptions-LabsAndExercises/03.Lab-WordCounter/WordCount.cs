namespace _03.Lab_WordCounter
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
 
    public class WordCount
    {
        public static void Main()
        {
            var file = File.ReadAllText("../../text.txt").ToLower();

            var wordsInText = file.Split(new[] { ' ', ',', '-', '.', '!', '?', '_', '(', ')' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var words = new FileInfo("../../words.txt");

            var wordsInWordsAsString = File.ReadAllText("../../words.txt").ToLower().Split(' ').ToList();

            var wordsInWords = new int[wordsInWordsAsString.Count];

            var count = 0;

            foreach (var word in wordsInWordsAsString)
            {
                foreach (var item in wordsInText)
                {
                    if (word == item)
                    {
                        count++;
                    }
                }
                var index = wordsInWordsAsString.IndexOf(word);
                wordsInWords[index] = count;
                count = 0;
            }

            var result = new Dictionary<string, int>();

            foreach (var item in wordsInWordsAsString)
            {
                result[item] = wordsInWords[wordsInWordsAsString.IndexOf(item)];
            }

            result = result.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
