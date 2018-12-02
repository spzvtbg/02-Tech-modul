namespace _04.Files
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
  
    public class EndFiles
    {
        public string Folder { get; set; }

        public string File { get; set; }

        public long Size { get; set; }
    }

    public class program
    {
        public static void Main()
        {
            var nLines = int.Parse(Console.ReadLine());

            var currentFilePats = new List<EndFiles>();

            for (int i = 0; i < nLines; i++)
            {
                var filePaths = Console.ReadLine().Split(new[] { '\\', ';' }, StringSplitOptions.RemoveEmptyEntries);

                var folderName = filePaths.First();

                var file = filePaths[filePaths.Length - 2];

                var size = long.Parse(filePaths.Last());

                var currentFile = new EndFiles()
                {
                    Folder = folderName,

                    File = file,

                    Size = size
                };

                currentFilePats.Add(currentFile);
            }

            var search = Console.ReadLine().Split(' ').ToArray();

            var folder = search.Last();

            var extention = search.First();

            var outputFiles = new Dictionary<string, long>();

            foreach (var file in currentFilePats)
            {
                if (file.Folder.Equals(folder) && file.File.EndsWith(extention))
                {
                    outputFiles[file.File] = file.Size;
                }
            }

            if (outputFiles.Count == 0)
            {
                Console.WriteLine("No");
            }
            else
            {
                foreach (var file in outputFiles.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    Console.WriteLine($"{file.Key} - {file.Value} KB");
                }

            }
        }
    }
}
