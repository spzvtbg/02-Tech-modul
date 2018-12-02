namespace Lab2.MatchPhoneNumber
{
    using System;
    using System.Text.RegularExpressions;

    public class MatchPhoneNumber
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var regex = new Regex(@"\+\d{3}(\s|-)2\1\s*\d{3}\1\d{4}");

            var result = regex.Match(input);

            Console.WriteLine(result);
        }
    }
}
