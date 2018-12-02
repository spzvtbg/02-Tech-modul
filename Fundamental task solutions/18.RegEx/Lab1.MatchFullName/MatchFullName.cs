namespace Lab1.MatchFullName
{
    using System;
    using System.Text.RegularExpressions;

    public class MatchFullName
    {
        public static void Main()
        {
            var regex = new Regex(@"[A-Z][a-z]+\s[A-Z][a-z]+");

            var input = Console.ReadLine();

            var result = regex.Matches(input);

            foreach (Match item in result)
            {
                Console.WriteLine(item.Value);
            }
        }
    }
}
