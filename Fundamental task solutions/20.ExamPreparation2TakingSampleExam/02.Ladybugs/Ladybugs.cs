namespace _02.Ladybugs
{
    using System;
    using System.Linq;

    public class Ladybugs
    {
        public static void Main()
        {
            var places = new string[long.Parse(Console.ReadLine())];

            var bugsIndexes = Console.ReadLine().Split().Select(long.Parse).ToArray();

            for (int position = 0; position < places.Length; position++)
            {
                places[position] = bugsIndexes.Contains(position) ? "1" : "0";
            }
            
            var command = Console.ReadLine();

            while (command != "end")
            {
                var commandParts = command.Split().ToArray();

                var currentIndex = long.Parse(commandParts[0]);

                var direction = commandParts[1];

                var flyLenght = long.Parse(commandParts[2]);

                if (places.Length - 1 >= currentIndex && currentIndex >= 0 && places[currentIndex] == "1")
                {
                    places[currentIndex] = "0";

                    var newIndex = direction == "left" ? -flyLenght : flyLenght;

                    while (true)
                    {
                        try
                        {
                            currentIndex = currentIndex + newIndex;

                            if (places[currentIndex] == "1")
                            {
                                continue;
                            }
                            else
                            {
                                places[currentIndex] = "1";

                                break;
                            }
                        }
                        catch (Exception)
                        {
                            break;
                        }
                    }
                }
                
                command = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ", places));
        }
    }
}

