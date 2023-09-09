using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonPocket{
    class Evolve
    {
        public PokemonContext PokemonContext {get; set;} 

        public Evolve(PokemonContext pokemonContext){
            PokemonContext = pokemonContext;
        }
        
        public void EvolvePokemon()
        {
            PokemonContext.PokemonMasters.ToList().ForEach(pokemonMaster =>
            {
                string name = pokemonMaster.Name;

                // Goes through every pokemon and counts
                // every pokemon with the same name
                int count = PokemonContext.Pokemons
                    .Where(pokemon => (pokemon.Name == name))
                    .Count();

                if (count >= pokemonMaster.NoToEvolve)
                {
                    // set hp and exp to 0
                    int hp = 0;
                    int exp = 0;
                    Type pokemonSpecies = Type.GetType($"PokemonPocket.{pokemonMaster.EvolveTo}");
                    // Console.WriteLine(pokemonSpecies.ToString());
                    Pokemon newPokemon = (Pokemon)Activator.CreateInstance(pokemonSpecies, hp, exp);

                    // Console.WriteLine("Evolved Successfully");
                    Console.WriteLine($"{name} evolved into {newPokemon.Name}!!");

                    // Add pokemon to database
                    PokemonContext.Pokemons.Add(newPokemon);

                    // Keeps track of the number of existing pokemon
                    int noPokeToDelete = pokemonMaster.NoToEvolve;
                    while (noPokeToDelete > 0)
                    {
                        Pokemon pokemon = PokemonContext.Pokemons
                            .Where(pokemon => (pokemon.Name == name))
                            .First();
                        PokemonContext.Pokemons.Remove(pokemon);
                        noPokeToDelete -= 1;
                        PokemonContext.SaveChanges();
                    }

                }
            });
            PokemonContext.SaveChanges();
        }
    }
}