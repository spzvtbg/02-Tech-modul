using System;
using System.Collections.Generic;
using System.Linq;

public class Dog
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int Legs { get; set; }

    public void Sound()
    {
        Console.WriteLine("I'm a Distinguishedog, and I will now produce a distinguished sound! Bau Bau.");
    }
}

public class Cat
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int Inteligence { get; set; }

    public void Sound()
    {
        Console.WriteLine("I'm an Aristocat, and I will now produce an aristocratic sound! Myau Myau.");
    }
}

public class Snake
{
    public string Name { get; set; }
    public int Age { get; set; }
    public int Cruelty { get; set; }

    public void Sound()
    {
        Console.WriteLine(
            "I'm a Sophistisnake, and I will now produce a sophisticated sound! Honey, I'm home.");
    }
}

public class Animals
{
    static string animalKind = string.Empty;
    static string animalName = string.Empty;
    static int animalAge = 0;
    static int animalBehavior = 0;

    static List<Dog> dogs = new List<Dog>();
    static List<Cat> cats = new List<Cat>();
    static List<Snake> snakes = new List<Snake>();

    public static void Main()
    {
        ReadSeveralInformationsFrom(Console.ReadLine());
        PrintAllDogs();
        PrintAllCats();
        PrintAllSnakes();
    }

    static void PrintAllDogs()
    {
        foreach (var dog in dogs)
        {
            Console.WriteLine($"Dog: {dog.Name}, Age: {dog.Age}, Number Of Legs: {dog.Legs}");
        }
    }

    private static void PrintAllCats()
    {
        foreach (var cat in cats)
        {
            Console.WriteLine($"Cat: {cat.Name}, Age: {cat.Age}, IQ: {cat.Inteligence}");
        }
    }

    private static void PrintAllSnakes()
    {
        foreach (var snake in snakes)
        {
            Console.WriteLine($"Snake: {snake.Name}, Age: {snake.Age}, Cruelty: {snake.Cruelty}");
        }
    }

    static void SplitCurent(string input)
    {
        var splited = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        animalKind = splited[0];
        animalName = splited[1];
        if (splited.Length > 2)
        {
            animalAge = Convert.ToInt32(splited[2]);
            animalBehavior = Convert.ToInt32(splited[3]);
        }
    }

    static void ReadSeveralInformationsFrom(string input)
    {
        if (input != "I'm your Huckleberry")
        {
            SplitCurent(input);
            if (animalKind == "Dog")
            {
                AddNewDog();
            }
            else if (animalKind == "Cat")
            {
                AddNewCat();
            }
            else if (animalKind == "Snake")
            {
                AddNewSnake();
            }
            else
            {
                ProduseSound();
            }
            ReadSeveralInformationsFrom(Console.ReadLine());
        }
        else return;
    }

    private static void AddNewDog()
    {
        var newDog = new Dog();
        newDog.Name = animalName;
        newDog.Age = animalAge;
        newDog.Legs = animalBehavior;
        dogs.Add(newDog);
    }

    static void AddNewCat()
    {
        var newCat = new Cat();
        newCat.Name = animalName;
        newCat.Age = animalAge;
        newCat.Inteligence = animalBehavior;
        cats.Add(newCat);
    }

    static void AddNewSnake()
    {
        var newSnake = new Snake();
        newSnake.Name = animalName;
        newSnake.Age = animalAge;
        newSnake.Cruelty = animalBehavior;
        snakes.Add(newSnake);
    }

    static void ProduseSound()
    {
        if (dogs.Any(x => x.Name == animalName))
        {
            var currentAnimal = dogs.Where(x => x.Name == animalName).FirstOrDefault();
            currentAnimal.Sound();
        }
        else if (cats.Any(x => x.Name == animalName))
        {
            var currentAnimal = cats.Where(x => x.Name == animalName).FirstOrDefault();
            currentAnimal.Sound();
        }
        else
        {
            var currentAnimal = snakes.Where(x => x.Name == animalName).FirstOrDefault();
            currentAnimal.Sound();
        }
    }
}
