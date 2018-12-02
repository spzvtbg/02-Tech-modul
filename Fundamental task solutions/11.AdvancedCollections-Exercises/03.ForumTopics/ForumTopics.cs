namespace _03.ForumTopics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ForumTopics
    {
        public static void Main()
        {
            var forumTopics = new Dictionary<string, HashSet<string>>();

            var entered = Console.ReadLine();
            while (entered != "filter")
            {
                var enterLine = entered.Split(", ->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
                var firstEnter = enterLine[0];
                enterLine.Remove(firstEnter);

                var lastEntered = new List<string>(enterLine);
                if (!forumTopics.ContainsKey(firstEnter))
                {
                    forumTopics[firstEnter] = new HashSet<string>();
                }
                forumTopics[firstEnter] = AddingTags(forumTopics[firstEnter], lastEntered);

                entered = Console.ReadLine();
            }

            var tags = Console.ReadLine().Split(", ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (var topic in forumTopics)
            {
                var contains = true;
                foreach (var item in tags)
                {
                    if (!topic.Value.Contains(item))
                    {
                        contains = false;
                    }
                }
                if (contains)
                {
                    Console.WriteLine($"{topic.Key} | #{string.Join(", #", topic.Value)}");
                }
            }
        }

        private static HashSet<string> AddingTags(HashSet<string> set, List<string> lastEntered)
        {
            foreach (var tag in lastEntered)
            {
                set.Add(tag);
            }
            return set;
        }
    }
}
