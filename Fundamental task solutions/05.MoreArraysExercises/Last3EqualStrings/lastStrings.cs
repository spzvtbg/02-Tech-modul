using System;
using System.Linq;
namespace Last3EqualStrings
{
    public class lastStrings
    {
        public static void Main()
        {
            string[] words = Console.ReadLine().Split(' ').ToArray();

            int ctr = 0;
            string str = string.Empty;

            for (int i = words.Length - 1; i >= 1; i--)
            {
                if (words[i] == words[i - 1])
                {
                    str = words[i];
                    ctr++;
                    if (ctr == 2)
                    {
                        break;
                    }
                }
                else
                {
                    ctr = 0;
                }
            }
            Console.WriteLine(str + ' ' + str + ' ' + str);
        }
    }
}
