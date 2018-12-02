namespace _01.LetterRepetition
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LetterRepetition
    {
        public static void Main()
        {
            string inputString = Console.ReadLine();
            Dictionary<char, int> exportedChars = new Dictionary<char, int>();

            foreach (var character in inputString)
            {
                if (!exportedChars.ContainsKey(character))
                {
                    exportedChars[character] = 0;
                }
                exportedChars[character]++;
            }
            foreach (var character in exportedChars)
            {
                char fromChars = character.Key;
                int value = character.Value;
                Console.WriteLine($"{fromChars} -> {value}");
            }
        }
    }
}
