using System;

public class PokeMon
{
    static ulong pokemonPower = 0;
    static ulong distanceToTarget = 0;
    static ulong divideFactor = 0;
    static int targetsCatch = 0;
    static ulong originPower = 0;

    public static void Main()
    {
        pokemonPower = Convert.ToUInt64(Console.ReadLine());
        distanceToTarget = Convert.ToUInt64(Console.ReadLine());
        divideFactor = Convert.ToUInt64(Console.ReadLine());
        originPower = pokemonPower;

        ProcessPoken(targetsCatch);
        Console.WriteLine(pokemonPower);
        Console.WriteLine(targetsCatch);
    }

    static void ProcessPoken(int targetsCatch)
    {
        if (!IsTired())
        {
            SubstractPokemonPower();
            ProcessPoken(targetsCatch);
        }
        else return;
    }

    static void SubstractPokemonPower()
    {
        if (IsMiddelFromHisPower())
        {
            try
            {
                pokemonPower /= divideFactor;
            }
            catch (Exception) { }
        }
        if (!IsTired())
        {
            pokemonPower -= distanceToTarget;
            targetsCatch++;
        }
    }

    static bool IsTired()
    {
        return pokemonPower < distanceToTarget;
    }

    static bool IsMiddelFromHisPower()
    {
        return pokemonPower == originPower / 2.0;
    }
}
