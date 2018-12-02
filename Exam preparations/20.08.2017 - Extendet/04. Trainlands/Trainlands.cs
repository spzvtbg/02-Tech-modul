using System;
using System.Text.RegularExpressions;

public class Trainlands
{
    public static void Main()
    {
        var pattern = @"^<\[([^a-zA-Z0-9]*)\]\.(\.\[([a-zA-Z0-9]*)\]\.)*$";
        while (true)
        {
            var composition = Console.ReadLine();
            if (composition == "Traincode!")
            {
                return;
            }

            var match = Regex.Match(composition, pattern);
            if (match.Success)
            {
                Console.WriteLine(match.Value);
            }
        }
    }
}
