namespace _01.CharityMarathon
{
    using System;
   
    public class CharityMarathon
    {
        public static void Main()
        {
            var marathonDauerInDays = double.Parse(Console.ReadLine());

            var runners = double.Parse(Console.ReadLine());

            var averageLapsNumber = double.Parse(Console.ReadLine());

            var trackLenght = double.Parse(Console.ReadLine());

            var trackCapacity = double.Parse(Console.ReadLine());

            var moneyPerKM = double.Parse(Console.ReadLine());

            var maxRunners = trackCapacity * marathonDauerInDays;

            if (maxRunners >= runners)
            {
                Console.WriteLine($"Money raised: {((runners * averageLapsNumber * trackLenght / 1000) * moneyPerKM):f2}");
            }
            else
            {
                Console.WriteLine($"Money raised: {((maxRunners * trackLenght * averageLapsNumber / 1000) * moneyPerKM):f2}");
            }
        }
    }
}
