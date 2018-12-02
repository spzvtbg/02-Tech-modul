using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        var line = "1abc2abv3wer4wer5sfg6slkdf7orig8dfkg9rlekmg0";
        var regex = new Regex(@"[0-9]+");
        var result = regex.Match(line);
        for (int i = 0; ; i++)
        {
            if (result.Success)
            {
                Console.WriteLine(result.NextMatch());
            }
            else
            {
                break;
            }
        }
    }
}
