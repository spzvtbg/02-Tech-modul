namespace _03.MixedPhones
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MixedPhones
    {
        public static void Main()
        {
            var phoneBook = new SortedDictionary<string, long>();

            var input = Console.ReadLine();
            while (input != "Over")
            {
                var data = input.Split(' ').ToArray();
                var name = data[0];
                var number = data[data.Length - 1];

                var value = 0l;
                if (long.TryParse(number, out value))
                {
                    phoneBook[name] = value;
                }
                else if (long.TryParse(name, out value))
                {
                    phoneBook[number] = value;
                }
                input = Console.ReadLine();
            }
            //var ordered = phoneBook.OrderBy(name => name.Key);
            foreach (var item in phoneBook)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
