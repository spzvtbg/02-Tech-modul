namespace _01.Lab_OddLines
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
  
    public class OddLines
    {
        public static void Main()
        {
            string[] fileLines = File.ReadAllLines("../../Resources.txt");

            List<string> oddLines = new List<string>();

            for (int i = 0; i < fileLines.Length; i++)
            {
                if (i % 2 != 0)
                {
                    //oddLines.Add(fileLines[i]); // 1.First Solutions
                    File.AppendAllText("../../Result.txt", fileLines[i] + "\r\n");
                }
            }

            oddLines = File.ReadAllLines("../../Result.txt").ToList();

            Console.WriteLine(string.Join(Environment.NewLine, oddLines));

            //Console.WriteLine(string.Join(Environment.NewLine, oddLines)); // 1.First Solutions
        }
    }
}
