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
}

public class JSONParse
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
        foreach (var item in studentsCollection)
        {
            Console.Write($"{item.Name} : {item.Age} -> ");
            Console.WriteLine(item.Grades.Count() > 0 ? string.Join(", ", item.Grades) : "None");
        }
    }

    static void ReadNextLinesUntillStringifyFrom(string input)
    {
            SplitCurrent(input);
    }

    static void SplitCurrent(string input)
    {
        var studentPatern = new[] { "},{" };
        var students = input.Split(studentPatern, StringSplitOptions.RemoveEmptyEntries);

        foreach (var item in students)
        {
            var patern = new[] { "name", "age", "grades", "[", "]", "{", "}", ",", "\"", ":", " " };
            var splitedInput = item.Split(patern, StringSplitOptions.RemoveEmptyEntries);

            name = splitedInput.First();
            age = splitedInput.Skip(1).First();
            grades = splitedInput.Skip(2).ToArray();

            AddNewStudentToCollection();
        }
    }

    static void AddNewStudentToCollection()
    {
        var newStudent = new Student(name, age, grades);
        studentsCollection.Add(newStudent);
    }
}
