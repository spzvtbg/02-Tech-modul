using System;
using System.Collections.Generic;
using System.Linq;

class Root
{
    private string root;
    private List<File> files;

    public Root(string root)
    {
        this.root = root;
    }

    public string CurrentRoot
    {
        get { return root; }
        set { this.root = value; }
    }

    public List<File> Files
    {
        get { return files; }
        set { this.files = value; }
    }
}

class File
{
    private string fileName;
    private long size;

    public File(string fileName, long size)
    {
        this.fileName = fileName;
        this.size = size;
    }

    public string FileName
    {
        get { return fileName; }
        set { this.fileName = value; }
    }

    public long Size
    {
        get { return size; }
        set { this.size = value; }
    }
}

public class ProgramFiles
{
    static string currentRoot;
    static string currentFile;
    static long currentSize;
 
    static List<Root> fileCollection = new List<Root>();

    public static void Main()
    {
        ReadNextLinesFrom(Convert.ToInt32(Console.ReadLine()));
        PrintResultByGivenExtentionFrom(Console.ReadLine());
    }

    static void PrintResultByGivenExtentionFrom(string extentionWithRoot)
    {
        var splited = extentionWithRoot.Split(' ');
        var extention = splited[0];
        var root = splited[2];

        var resultCollection = fileCollection.Where(x => x.CurrentRoot == root).FirstOrDefault();
        if (fileCollection.Count == 0 || resultCollection == null)
        {
            Console.WriteLine("No");
        }
        else
        {
            resultCollection.Files.Where(x => x.FileName.EndsWith($".{extention}")).ToList()
                .OrderByDescending(x => x.Size).ThenBy(x => x.FileName).ToList()
                .ForEach(x => Console.WriteLine($"{x.FileName} - {x.Size} KB"));
        }
    }

    static void ReadNextLinesFrom(int linesCounter)
    {
        for (int index = 0; index < linesCounter; index++)
        {
            DivideAndRule(Console.ReadLine());
        }
    }

    static void DivideAndRule(string currentLine)
    {
        Split(currentLine);
        if (!fileCollection.Any(x => x.CurrentRoot == currentRoot))
        {
            AddNewRoot();
        }
        else if (fileCollection.Any(x => x.CurrentRoot == currentRoot))
        {
            AddNewFile();
        }
    }

    static void Split(string currentLine)
    {
        var patern = new string[] { "\\", ";"};
        var splited = currentLine.Split(patern, StringSplitOptions.RemoveEmptyEntries);
        currentRoot = splited[0];
        currentFile = splited[splited.Length - 2];
        currentSize = Convert.ToInt64(splited[splited.Length - 1]);
    }

    static void AddNewRoot()
    {
        var newRoot = new Root(currentRoot);
        newRoot.Files = new List<File>();
        var newFile = new File(currentFile, currentSize);
        newRoot.Files.Add(newFile);
        fileCollection.Add(newRoot);
    }

    static void AddNewFile()
    {
        var root = fileCollection.Where(x => x.CurrentRoot == currentRoot).FirstOrDefault();
        if (!root.Files.Any(x => x.FileName == currentFile))
        {
            var newFile = new File(currentFile, currentSize);
            root.Files.Add(newFile);
        }
        else UpdateCurrentFile(root);
    }

    static void UpdateCurrentFile(Root root)
    {
        var tokenFile = root.Files.Where(x => x.FileName == currentFile).FirstOrDefault();
        tokenFile.Size = currentSize;
    }
}

