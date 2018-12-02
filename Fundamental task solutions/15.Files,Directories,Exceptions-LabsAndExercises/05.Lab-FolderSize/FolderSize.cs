namespace _05.Lab_FolderSize
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class FolderSize
    {
        public static void Main()
        {
            var filenames = Directory.GetFiles("../../TestFolder");

            var filesSize = 0.0;

            foreach (var item in filenames)
            {
                FileInfo file = new FileInfo(item);
                filesSize += file.Length;
            }

            Console.WriteLine(filesSize / 1024 / 1024 + " MB");

            File.WriteAllText("../../Result.txt", (filesSize / 1024 / 1024).ToString() + " MB");
        }
    }
}
