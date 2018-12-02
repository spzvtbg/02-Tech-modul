using System;

public class HornetWings
{
    public static void Main()
    {
        var wingFlaps = Convert.ToInt32(Console.ReadLine());
        var distance = Convert.ToDouble(Console.ReadLine());
        var endurance = Convert.ToInt32(Console.ReadLine());

        var flaps = wingFlaps + 0.00;
        Console.WriteLine("{0:F2} m.", flaps / 1000 * distance);

        var seconds = wingFlaps / endurance * 5 + wingFlaps / 100;
        Console.WriteLine("{0} s.", seconds);
    }
}
