using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public class Program
{
    //public static void Main()
    //{
    //    var patern = @"\w+";
    //    var regex = Regex.Matches("How about... No...", patern);

    //    foreach (var item in regex)
    //    {
    //        Console.WriteLine(item);
    //    }
    //}

    public static void Main()
    {
        var result = Regex.Match("201masrt347", @"^(?<first>\d+)(?<string>[a-zA-Z]*)(?<last>\d+)$");
        Console.WriteLine(result.Groups["string"].Value);
        Console.WriteLine(result.Groups["first"].Value);
        Console.WriteLine(result.Groups["last"].Value);
    }
}
