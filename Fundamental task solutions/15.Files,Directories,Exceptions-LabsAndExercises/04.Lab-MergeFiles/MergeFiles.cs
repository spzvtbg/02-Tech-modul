namespace _04.Lab_MergeFiles
{
    using System;
    using System.IO;
    using System.Linq;

    public class MergeFiles
    {
        public static void Main()
        {
            var first = File.ReadAllLines("../../FileOne.txt").ToList();

            var second = File.ReadAllLines("../../FileTwo.txt").ToList();

            first.AddRange(second);

            first.Sort();

            File.WriteAllLines("../../Result.txt", first);

            var result = File.ReadAllLines("../../Result.txt");

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
