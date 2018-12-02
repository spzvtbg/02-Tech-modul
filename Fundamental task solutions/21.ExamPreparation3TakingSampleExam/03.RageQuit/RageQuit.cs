namespace _03.RageQuit
{
    using System;
    using System.Text.RegularExpressions;
    using System.Linq;
    using System.Text;
  
    public class RageQuit
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var regex = new Regex(@"(\D+)(\d+)");

            var matches = regex.Matches(input);

            var stringBuilder = new StringBuilder();

            foreach (Match item in matches)
            { 
                var strings = item.Groups[1].Value.ToString();

                var numbers = int.Parse(item.Groups[2].Value);

                for (int i = 0; i < numbers; i++)
                {
                   stringBuilder.Append(strings.ToUpper());
                }          
            }

            Console.WriteLine($"Unique symbols used: {stringBuilder.ToString().Distinct().Count()}");

            Console.WriteLine(stringBuilder);
        }
    }
}
