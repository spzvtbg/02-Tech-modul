namespace _04.SentenceSplit
{
    using System;
    using System.Text;

    public class SentenceSplit
    {
        public static void Main()
        {
            var sentense = Console.ReadLine();

            var delimiter = Console.ReadLine();

            var currentPartsOfSentens = sentense.Replace(delimiter, ", ").ToString();

            Console.WriteLine($"[{currentPartsOfSentens}]");
        }
    }
}
