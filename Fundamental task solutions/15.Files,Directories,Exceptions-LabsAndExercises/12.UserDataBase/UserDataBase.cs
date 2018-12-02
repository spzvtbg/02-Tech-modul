namespace _12.UserDataBase
{
    using System;
    using System.IO;
    using System.Linq;
    
    public class UserDataBase
    {
        private static bool IsSomeoneLogedIn = false;

        private static string userDirectory = "../../Users";

        public static void Main()
        {
            if (!Directory.Exists(userDirectory))
            {
                Directory.CreateDirectory(userDirectory);
            }

            var inputLine = Console.ReadLine();

            while (inputLine != "exit")
            {
                var parameters = inputLine.Split(' ');

                var command = parameters[0];

                if (command == "register")
                {
                    var name = parameters[1];

                    var passwort = parameters[2];

                    var confirmPaswort = parameters[3];

                    var files = Directory.GetFiles(userDirectory);

                    if (files.Contains($"{userDirectory}\\{name}.txt"))
                    {
                        Console.WriteLine("The given username already exists.");

                        inputLine = Console.ReadLine();

                        continue;
                    }

                    if (passwort != confirmPaswort)
                    {
                        Console.WriteLine("The two passwords must match.");

                        inputLine = Console.ReadLine();

                        continue;
                    }

                    File.WriteAllText($"{userDirectory}/{name}.txt", passwort);
                }

                if (command == "login")
                {
                    var name = parameters[1];

                    var passwort = parameters[2];

                    var users = Directory.GetFiles(userDirectory);

                    if (users.Contains($"{userDirectory}\\{name}.txt"))
                    {
                        var content = File.ReadAllText($"{userDirectory}/{name}.txt");

                        if (!content.Contains(passwort))
                        {
                            Console.WriteLine("The password you entered is incorrect.");

                            inputLine = Console.ReadLine();

                            continue;
                        }

                        if (content.Contains(passwort) && content.Contains("loged"))
                        {
                            Console.WriteLine("There is already a logged in user.");

                            inputLine = Console.ReadLine();

                            continue;
                        }

                        File.AppendAllText($"{userDirectory}/{name}.txt", " loged");

                        IsSomeoneLogedIn = true;
                    }
                    else
                    {
                        Console.WriteLine("There is no user with the given username.");

                        inputLine = Console.ReadLine();

                        continue;
                    }
                }

                if (command == "logout")
                {
                    if (IsSomeoneLogedIn == false)
                    {
                        Console.WriteLine("There is no currently logged in user.");

                        inputLine = Console.ReadLine();

                        continue;
                    }

                    var files = Directory.GetFiles(userDirectory);

                    foreach (var file in files)
                    {
                        var content = File.ReadAllText($"{file}");

                        if (content.Contains("loged"))
                        {
                           content = content.Replace("loged", string.Empty);
                        }

                        File.WriteAllText($"{file}", content);
                    }

                    IsSomeoneLogedIn = false;
                }

                inputLine = Console.ReadLine();
            }
        }
    }
}

