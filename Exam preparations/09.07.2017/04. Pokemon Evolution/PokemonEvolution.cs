using System;
using System.Collections.Generic;
using System.Linq;

public class Evolution
{
    private string evolutionKind;
    private int evolutionPower;

    public Evolution(string evolutionKind, int evolutionPower)
    {
        this.evolutionKind = evolutionKind;
        this.evolutionPower = evolutionPower;
    }

    public string EvolutionKind
    {
        get { return evolutionKind; }
        set { this.evolutionKind = value; }
    }

    public int EvolutionPower
    {
        get { return evolutionPower; }
        set { this.evolutionPower = value; }
    }
}

public class Pokemon
{
    private string name;
    private List<Evolution> evolutions = new List<Evolution>();

    public Pokemon(string name, Evolution newEvolution)
    {
        this.name = name;
        this.Evolutions.Add(newEvolution);
    }

    public string Name
    {
        get { return name; }
        set { this.name = value; }
    }

    public List<Evolution> Evolutions
    {
        get { return evolutions; }
        set { this.evolutions = value; }
    }
}

public class PokemonEvolution
{
    static string pokemonByName;
    static string evolutionByType;
    static int evolutionByPower;

    static List<Pokemon> pokemons = new List<Pokemon>();

    public static void Main()
    {
        ReadFromConsoleNextPokemonData(Console.ReadLine());
        PrintAllPokemonsByGivenOrder();
    }

    private static void PrintAllPokemonsByGivenOrder()
    {
        foreach (var poke in pokemons)
        {
            Console.WriteLine($"# {poke.Name}");
            foreach (var item in poke.Evolutions.OrderByDescending(e => e.EvolutionPower))
            {
                Console.WriteLine($"{item.EvolutionKind} <-> {item.EvolutionPower}");
            }
        }
    }

    public static void ReadFromConsoleNextPokemonData(string input)
    {
        if (input != "wubbalubbadubdub")
        {
            DivideAndRuleThis(input);
            ReadFromConsoleNextPokemonData(Console.ReadLine());
        }
    }

    public static void DivideAndRuleThis(string input)
    {
        var patern = new[] { " -> " };
        var splited = input.Split(patern, StringSplitOptions.RemoveEmptyEntries);

        if (splited.Length > 1)
        {
            pokemonByName = splited[0];
            evolutionByType = splited[1];
            evolutionByPower = Convert.ToInt32(splited[2]);

            AddOrUpdateByCurrentPokemon();
        }
        else PrintGivenPokemonsEvolutions(splited[0]);
    }

    public static void AddOrUpdateByCurrentPokemon()
    {
        if (!pokemons.Any(p => p.Name == pokemonByName))
        {
            AddNewPokemon();
        }
        else UpdatePokemon();
    }

    private static void AddNewPokemon()
    {
        var newEvolution = new Evolution(evolutionByType, evolutionByPower);
        var newPokemon = new Pokemon(pokemonByName, newEvolution);
        pokemons.Add(newPokemon);
    }

    private static void UpdatePokemon()
    {
        var newEvolution = new Evolution(evolutionByType, evolutionByPower);
        var currentPokemon = pokemons.Where(p => p.Name == pokemonByName).FirstOrDefault();
        currentPokemon.Evolutions.Add(newEvolution);
    }

    public static void PrintGivenPokemonsEvolutions(string pokemon)
    {
        if (pokemons.Any(p => p.Name == pokemon))
        {
            var currentPokemon = pokemons.Where(p => p.Name == pokemon).First();

            Console.WriteLine($"# {currentPokemon.Name}");
            foreach (var item in currentPokemon.Evolutions)
            {
                Console.WriteLine($"{item.EvolutionKind} <-> {item.EvolutionPower}");
            }
        }
    }
}
