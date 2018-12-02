namespace _5.UserLogins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class UserLogins
    {
        public static void Main()
        {
            var users = new Dictionary<string, string>();
            var input = Console.ReadLine();
            while (input != "login")
            {
                var userPaswort = input.Split(' ').ToArray();
                var user = userPaswort[0];
                var paswort = userPaswort[userPaswort.Length - 1];
                users[user] = paswort;
                input = Console.ReadLine();
            }
            int count = 0;
            input = Console.ReadLine();
            while (input != "end")
            {
                var userPaswort = input.Split(' ').ToArray();
                var user = userPaswort[0];
                var paswort = userPaswort[userPaswort.Length - 1];
                if (users.ContainsKey(user) && users[user] == paswort)
                {
                    Console.WriteLine($"{user}: logged in successfully");
                }
                else
                {
                    Console.WriteLine($"{user}: login failed");
                    count++;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"unsuccessful login attempts: {count}");
        }
    }
}
