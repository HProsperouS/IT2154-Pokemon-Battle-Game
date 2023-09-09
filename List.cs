using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonPocket{
    class List
    {
       public PokemonContext PokemonContext {get; set;} 

        public List(PokemonContext pokemonContext){
            PokemonContext = pokemonContext;
        }
        
        
        public void ListPokemon()
        {
            // Convert Pokemon Data set into a List<Pokemon>
            PokemonContext.Pokemons.ToList().ForEach(pokemon =>
            {
                Console.WriteLine($"----------------------");
                Console.WriteLine($"Name: " + pokemon.Name);
                Console.WriteLine($"HP: " + pokemon.Hp);
                Console.WriteLine($"Exp: " + pokemon.Exp);
                Console.WriteLine($"Skill: " + pokemon.Skill);
                Console.WriteLine($"----------------------");
            });
        }
}
}