namespace _02.Lab_LineNumber
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class LineNubers
    {
        public static void Main()
        {
            var output = File.ReadAllLines("../../Input.txt");

            var result = new List<string>();

            var count = 1;

            foreach (var line in output)
            {
                result.Add($"{count}. {line}");
                count++;
            }

            File.WriteAllLines("../../Result.txt", result);

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}
