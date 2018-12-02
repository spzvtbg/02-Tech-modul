using System;
using System.Linq;
using System.Collections.Generic;
namespace TrackDownloader
{
    public class trackDownloader
    {
        public static void Main()
        {
            List<string> blackList = Console.ReadLine().Split().ToList();
            List<string> trackList = new List<string>();

            string input = Console.ReadLine();
            while (input != "end")
            {
                bool inList = CheckTrue(blackList, input);
                if (inList)
                {
                    trackList.Add(input);
                }
                input = Console.ReadLine();
            }
            trackList.Sort();
            Console.WriteLine(string.Join(Environment.NewLine, trackList));
        }

        private static bool CheckTrue(List<string> blackList, string input)
        {
            bool isTrue = true;
            for (int i = 0; i < blackList.Count; i++)
            {
                isTrue = input.Contains(blackList[i])? false : true;
                if (!isTrue)
                {
                    break;
                }
            }
            return isTrue;
        }
    }
}
