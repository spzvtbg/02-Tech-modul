namespace _13._5.Re_Directory
{
    using System;
    using System.IO;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            var files = Directory.GetFiles("../../input").ToList();

            if (!Directory.Exists("../../SortedFiles"))
            {
                Directory.CreateDirectory("../../SortedFiles");
            }

            foreach (var file in files)
            {
                var content = file.Split(new[] { '.', '/', '\\' }, StringSplitOptions.RemoveEmptyEntries).ToList();

                var extension = content[content.Count - 1];

                var fileName = string.Join(".", content.Skip(1));

                if (!File.Exists($"../../SortedFiles/{extension}s.txt"))
                {
                    File.WriteAllText($"../../SortedFiles/{extension}s.txt", fileName + "\r\n");
                }
                else
                {
                    File.AppendAllText($"../../SortedFiles/{extension}s.txt", fileName + "\r\n");
                }
            }
        }
    }
}
