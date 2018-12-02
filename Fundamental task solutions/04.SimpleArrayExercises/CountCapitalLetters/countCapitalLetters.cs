using System;
using System.Linq;
namespace CountLargerNumbersArray
{
    public class counting
    {
        public static void Main()
        {
            string[] arr = Console.ReadLine().Split(' ').ToArray();

            int ctr = 0;
            int res = 1;

            string word = string.Empty;

            for (int a = 0; a < arr.Length; a++)
            {
                word = arr[a];
                for (int b = 0; b < word.Length; b++)
                {
                   res = word[b].ToString() == word[b].ToString().ToUpper() ? ctr++ : ctr = ctr;
                }

            }
            Console.WriteLine(ctr);
        }
    }
}
