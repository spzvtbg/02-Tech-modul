namespace _01.RegisterUsers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Globalization;

    public class RegisterUsers
    {
        public static void Main()
        {
            var userWithDate = Console.ReadLine().Split(" ->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            var data = new Dictionary<string, DateTime>();

            while (userWithDate[0] != "end")
            {
                var user = userWithDate[0];
                var date = new DateTime();

                date = DateTime.ParseExact(userWithDate[1], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                data[user] = date;

                userWithDate = Console.ReadLine().Split(" ->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            var result = data
                .Reverse()
                .OrderBy(d => d.Value)
                .Take(5)
                .OrderByDescending(d => d.Value)
                .ToDictionary(d => d.Key, d => d.Value);

            Console.WriteLine(string.Join(Environment.NewLine, result.Keys));

        }
    }
}
