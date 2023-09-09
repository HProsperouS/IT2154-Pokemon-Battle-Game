using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonPocket{
    class Check
    {
        public PokemonContext PokemonContext {get; set;} 

        public Check(PokemonContext pokemonContext){
            PokemonContext = pokemonContext;
        }
        
        
        public void CheckEvolvePokemon()
        {   
            int canevolve = 0;
            // Goes through every pokemonMaster in the pokemonmaster dataset
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
                    Console.WriteLine($"{pokemonMaster.Name} -------> {pokemonMaster.EvolveTo}");
                    canevolve += 1;
                }

                
            });
            
            if (canevolve == 0){
                    Console.WriteLine("No pokemon can evolve");
            }
            
            
            
        }
    }
}