using System;
using System.Linq;
using System.Collections.Generic;
namespace AverageCharacterDelimiter
{
    public class averageCharacterDelimiter
    {
        public static void Main()
        {
            List<string> input = Console.ReadLine().Split().ToList();
            List<char> charList = new List<char>();
            charList = ToCharList(input, charList);
            int charListSum = CharListSum(charList) / charList.Count;
            string delimeter = string.Empty;
            if (charListSum >= (int)'a' && charListSum <= (int)'z')
            {
                delimeter = ((char)charListSum).ToString().ToUpper();
            }
            else
            {
                delimeter = ((char)charListSum).ToString();
            }
            Console.WriteLine(string.Join($"{delimeter}", input));
        }

        private static int CharListSum(List<char> charList)
        {
            int sum = 0;
            for (int i = 0; i < charList.Count; i++)
            {
                sum += charList[i];
            }
            return sum;
        }

        private static List<char> ToCharList(List<string> input, List<char> charList)
        {
            for (int i = 0; i < input.Count; i++)
            {
                string a = input[i];
                if (a.Length > 1)
                {
                    for (int l = 0; l < a.Length; l++)
                    {
                        charList.Add(a[l]);
                    }
                }
                else
                {
                    charList.Add(char.Parse(input[i]));
                }
            }
            return charList;
        }
    }
}
