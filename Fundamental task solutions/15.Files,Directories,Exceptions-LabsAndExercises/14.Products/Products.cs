namespace _14.Products
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Collections.Generic;

    public class Products
    {
        public static void Main()
        {
            if (!Directory.Exists("../../Store"))
            {
                Directory.CreateDirectory("../../Store");
            }

            var active = new List<Product>();

            var files = new List<string>();

            var input = Console.ReadLine();

            while (input != "exit")
            {

                var content = input.Split(' ');

                if (content[0] != "sales" && content[0] != "stock" && content[0] != "analyze")
                {
                    for (int i = 0; i < active.Count; i++)
                    {
                        if (active[i].Name == content[0])
                        {
                            active.Remove(active[i]);
                            i--;
                        }
                    }
                    var product = Product.Parse(content);

                    active.Add(product);
                }

                if (content[0] == "stock")
                {
                    foreach (var item in active)
                    {
                        if (!Directory.Exists($"../../Store/{item.Type}"))
                        {
                            Directory.CreateDirectory($"../../Store/{item.Type}");
                        }

                        File.WriteAllText($"../../Store/{item.Type}/{item.Name}.txt", $"{item.Price} {item.Quantity}");
                    }

                    for (int i = 0; i < active.Count; i++)
                    {
                            active.Remove(active[i]);
                            i--;
                    }
                }

                if (content[0] == "analyze")
                {
                    var directories = Directory.GetDirectories("../../Store").ToList().OrderBy(x => x);

                    var currend = new List<string>();

                    foreach (var directory in directories)
                    {
                        var temp = Directory.GetFiles(directory).ToList();

                        currend.AddRange(temp);
                    }

                    var fileContent = string.Empty;

                    foreach (var item in currend)
                    {
                        var str = item.Split(new[] { '.', '/', '\\' },StringSplitOptions.RemoveEmptyEntries).ToList();

                        fileContent = string.Join(" ", str);

                        files.Add(fileContent);
                    }

                    foreach (var item in files)
                    {
                        var output = item.Split(' ');

                        Console.WriteLine($"{output[1]}, Product: {output[2]}");

                        var numbers = File.ReadAllText($"../../{output[0]}/{output[1]}/{output[2]}.{output[3]}").Split(' ');

                        Console.WriteLine($"Price: {double.Parse(numbers[0]):f2}, Amount left: {int.Parse(numbers[1])}");
                    }
                }

                if (content[0] == "sales")
                {
                    var currentType = new Dictionary<string, double>();

                    foreach (var item in active)
                    {
                        if (!currentType.Keys.Contains(item.Type))
                        {
                            currentType[item.Type] = 0;
                        }
                    }

                    foreach (var item in currentType)
                    {
                        foreach (var type in active)
                        {
                            if (item.Key == type.Type)
                            {
                                currentType[item.Key] += type.Price * type.Quantity;
                            } 
                        }
                    }

                    foreach (var item in currentType)
                    {
                        Console.WriteLine($"{item.Key}: ${item.Value}");
                    }
                }

                input = Console.ReadLine();
            }

        }
    }
}
