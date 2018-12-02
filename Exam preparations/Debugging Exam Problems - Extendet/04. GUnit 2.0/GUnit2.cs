namespace _04.GUnit_2._0
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Class
    {
        public string Name { get; set; }

        public List<Method> Methods { get; set; }

        public int TestCount { get; set; }

        public Class()
        {
            this.Methods = new List<Method>();
        }
    }

    public class Method
    {
        public string Name { get; set; }

        public List<string> UnitTests { get; set; }

        public Method()
        {
            this.UnitTests = new List<string>();
        }
    }

    public class GUnit2
    {
        static string input;
        static string clas;
        static string method;
        static string unitTest;
        static string[] splitedInput;
        static string[] delimiter = new string[] { " | " };

        static List<Class> classes = new List<Class>();

        public static void Main()
        {
            input = Console.ReadLine();
            while (input != "It's testing time!")
            {
                try
                {
                    SplitCurrentInput();
                    ValidateCurrentInput();
                    ParsSplitedInput();
                }
                catch (Exception) { input = Console.ReadLine(); continue; }
                input = Console.ReadLine();
            }
            PrintOrderedData();
        }

        public static void SplitCurrentInput()
        {
            splitedInput = input.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        }

        public static void ValidateCurrentInput()
        {
            if (splitedInput.Length != 3)
            {
                throw new Exception();
            }
            ValidateUpperCase();
        }

        public static void ValidateUpperCase()
        {
            foreach (var item in splitedInput)
            {
                if (item[0] < 'A' || item[0] > 'Z' || item.Length < 2)
                {
                    throw new Exception();
                }
                ValidateContent(item);
            }
        }

        public static void ValidateContent(string item)
        {
            if (item.Any(x => (x < 'a' || x > 'z') && (x < 'A' || x > 'Z') && (x < '0' || x > '9')))
            {
                throw new Exception();
            }
        }

        public static void ParsSplitedInput()
        {
            clas = splitedInput[0];
            method = splitedInput[1];
            unitTest = splitedInput[2];
            AddOrUpdateClassesInfo();
        }

        public static void AddOrUpdateClassesInfo()
        {
            if (!classes.Any(c => c.Name == clas))
            {
                var newMethod = new Method();
                newMethod.Name = method;
                newMethod.UnitTests.Add(unitTest);
                var newClass = new Class();
                newClass.Name = clas;
                newClass.Methods.Add(newMethod);
                classes.Add(newClass);
            }
            else AddOrUpdteMethod();
        }

        public static void AddOrUpdteMethod()
        {
            var currentClass = classes.First(c => c.Name == clas);
            if (!currentClass.Methods.Any(m => m.Name == method))
            {
                var newMethod = new Method();
                newMethod.Name = method;
                newMethod.UnitTests.Add(unitTest);
                currentClass.Methods.Add(newMethod);
            }
            else AddOrUpdateTest(currentClass);
        }

        public static void AddOrUpdateTest(Class currentClass)
        {
            var currentMeethod = currentClass.Methods.First(m => m.Name == method);
            if (!currentMeethod.UnitTests.Any(t => t == unitTest))
            {
                currentMeethod.UnitTests.Add(unitTest);
            }
        }

        private static void PrintOrderedData()
        {
            if (classes.Count < 1)
            {
                return;
            }

            foreach (var clas in classes)
            {
                foreach (var method in clas.Methods)
                {
                    foreach (var test in method.UnitTests)
                    {
                        clas.TestCount++;
                    }
                }
            }

            var orderedClasses = classes
                .OrderByDescending(c => c.TestCount)
                .ThenBy(c => c.Methods.Count).ThenBy(c => c.Name);

            foreach (var orderedClas in orderedClasses)
            {
                Console.WriteLine($"{orderedClas.Name}:");

                var orderedMethods = orderedClas.Methods
                    .OrderByDescending(m => m.UnitTests.Count).ThenBy(m => m.Name);

                foreach (var orderedMethod in orderedMethods)
                {
                    Console.WriteLine($"##{orderedMethod.Name}");

                    var orderedTests = orderedMethod.UnitTests
                        .OrderBy(t => t.Length).ThenBy(t => t);

                    foreach (var orderedTest in orderedTests)
                    {
                        Console.WriteLine($"####{orderedTest}");
                    }
                }
            }
        }
    }
}
