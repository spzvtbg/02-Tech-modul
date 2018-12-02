using System;
using System.Linq;
using System.Globalization;
namespace Phone
{
    public class phone
    {
         public static void Main()
        {
            string[] numbers = Console.ReadLine().Split(' ').ToArray();
            string[] names = Console.ReadLine().Split(' ').ToArray();

            string[] action = Console.ReadLine().Split(' ').ToArray();
        
            while (action[0] != "done")
            {
                string comand = action[0];
                string data = action[1];
                string[] compilated = comand == "call" ? GetInfo(data, names, numbers) : GetInfo(data, names, numbers);

                string name =  compilated[0];
                string number = compilated[1];
                string who = data == name ? number : name;
                Console.WriteLine(comand == "call"? $"calling {who}..." : $"sending sms to {who}...");

                int digitsResult = DigitsSum(number);
                string callResult = digitsResult % 2 == 0 ? $"call ended.duration: {GetTime(digitsResult)}": "no answer";
                string messageResult = digitsResult % 2 == 0 ? "meet me there": "busy" ;
                Console.WriteLine(comand == "call" ? callResult : messageResult);

                action = Console.ReadLine().Split(' ').ToArray();
            }
        }

        private static string GetTime(int s)
        {
            DateTime dur = new DateTime(1, 1, 1).AddSeconds(s);
            string duration = dur.ToString("mm:ss");
            return duration;
        }

        private static int DigitsSum(string number)
        {
            int sum = 0;
           
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] >= 48 && number[i] <= 57)
                {
                    sum += int.Parse(number[i].ToString());
                }
            }
            return sum;
        }

        private static string[] GetInfo(string data, string[] names, string[] numbers)
        {
            string name = string.Empty;
            string number = string.Empty;
     
            for (int i = 0; i < names.Length; i++)
            {
                if (data == names[i])
                {
                    name = names[i];
                    number = numbers[i];
                    break;
                }
                if (data == numbers[i])
                {
                    name = names[i];
                    number = numbers[i];
                    break;
                }
            }
            string[] info = { name, number };
            return info;
        }
    }
}
