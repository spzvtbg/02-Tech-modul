using System;

public class PokemonDontGo
{
    static long[] pokemons;
    static int pokemonAtIndex;
    static long pokemonsSum;
    static int tokenPokemons;
    static long token;

    public static void Main()
    {
        pokemons = ConvertToLong(Console.ReadLine().Split(' '));
        tokenPokemons = 0;
        TakeAllPokemons();
        Console.WriteLine(pokemonsSum);
    }

    static long[] ConvertToLong(string[] pokemons)
    {
        var temporaryPocemons = new long[pokemons.Length];
        for (int index = 0; index < pokemons.Length; index++)
        {
            temporaryPocemons[index] = Convert.ToInt64(pokemons[index]);
        }
        return temporaryPocemons;
    }

    static void TakeAllPokemons()
    {
        if (!AreAllPokemonsToken())
        {
            pokemonAtIndex = Convert.ToInt32(Console.ReadLine());
            var temporaryIndex = pokemonAtIndex;
            pokemonAtIndex = CurrentIndex(pokemonAtIndex);

            token = pokemons[pokemonAtIndex];
            if (pokemonAtIndex != temporaryIndex)
            {
                CopyFirstLast(temporaryIndex);
            }
            else
            {
                ReplaceToken();
                tokenPokemons++;
            }
            pokemonsSum += token;

            InDeCreasasing();
            TakeAllPokemons();
        }
    }

    static bool AreAllPokemonsToken()
    {
        return tokenPokemons == pokemons.Length;
    }

    static int CurrentIndex(int index)
    {
        if (index < 0)
        {
            return 0;
        }
        else if (index > pokemons.Length - tokenPokemons - 1)
        {
            return pokemons.Length - tokenPokemons - 1;
        }
        return index;
    }

    static void ReplaceToken()
    {
        for (int index = pokemonAtIndex; index < pokemons.Length - 1; index++)
        {
            var current = pokemons[index];
            pokemons[index] = pokemons[index + 1];
            pokemons[index + 1] = current;
        }
    }

    static void CopyFirstLast(int temporaryIndex)
    {
        if (temporaryIndex < 0)
        {
            pokemons[0] = pokemons[pokemons.Length - tokenPokemons - 1];
        }
        else if (temporaryIndex > pokemons.Length - tokenPokemons - 1)
        {
            pokemons[pokemons.Length - tokenPokemons - 1] = pokemons[0];
        }
    }

    static void InDeCreasasing()
    {
        for (int index = 0; index < pokemons.Length - tokenPokemons; index++)
        {
            if (pokemons[index] <= token)
                pokemons[index] += token;
            else
                pokemons[index] -= token;
        }
    }
}
