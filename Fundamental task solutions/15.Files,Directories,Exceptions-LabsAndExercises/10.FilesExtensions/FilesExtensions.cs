namespace _10.FilesExtensions
{
    using System;
    using System.IO;
    using System.Linq;
   
    public class FilesExtensions
    {
        public static void Main()
        {
            var extension = Console.ReadLine();

            var files = Directory.GetFiles("../../input").ToList();

            foreach (var file in files)
            {
                var newFile = file.Replace("../../input\\", string.Empty);

                var temp = newFile.Split('.').ToList().Last();

                if (temp == extension)
                {
                    Console.WriteLine(newFile);
                }
            }
        }
    }
}
