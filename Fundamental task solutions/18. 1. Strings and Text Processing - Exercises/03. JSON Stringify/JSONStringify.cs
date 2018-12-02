using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    private string name;
    private string age;
    private string[] grades;

    public Student(string name, string age, string[] grades)
    {
        this.name = name;
        this.age = age;
        this.grades = grades;
    }

    public string Name
    {
        get { return name; } 
        set { this.name = value; }
    }

    public string Age
    {
        get { return age; }
        set { this.age = value; }
    }

    public string[] Grades
    {
        get { return grades; }
        set { this.grades = value; }
    }

    public override string ToString()
    {
        return $"{{name:\"{Name}\",age:{Age},grades:[{string.Join(", ", Grades)}]}}";
    }
}

public class JSONStringify
{
    static string name;
    static string age;
    static string[] grades;

    static List<Student> studentsCollection = new List<Student>();

    public static void Main()
    {
        ReadNextLinesUntillStringifyFrom(Console.ReadLine());
        PrintAllStudentsFromStudentsCollectionByGivenOrder();
    }

    private static void PrintAllStudentsFromStudentsCollectionByGivenOrder()
    {
        var isFirst = true;
        foreach (var item in studentsCollection)
        {
            if (isFirst)
            {
                Console.Write($"[{item.ToString()}");
                isFirst = false;
                continue;
            }
            Console.Write($",{item.ToString()}");
        }
        Console.WriteLine("]");
    }

    static void ReadNextLinesUntillStringifyFrom(string input)
    {
        if (input != "stringify")
        {
            SplitCurrent(input);
            AddNewStudentToCollection();
            ReadNextLinesUntillStringifyFrom(Console.ReadLine());
        }
        else return;
    }

    static void SplitCurrent(string input)
    {
        var patern = new[] { "->", ":", ",", " "};
        var splitedInput = input.Split(patern, StringSplitOptions.RemoveEmptyEntries);

        name = splitedInput.First();
        age = splitedInput.Skip(1).First();
        grades = splitedInput.Skip(2).ToArray();
    }

    static void AddNewStudentToCollection()
    {
        var newStudent = new Student(name, age, grades);
        studentsCollection.Add(newStudent);
    }
}
