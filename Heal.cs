using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonPocket{
    class Heal
    {
        public PokemonContext PokemonContext {get; set;} 

        public Heal(PokemonContext pokemonContext){
            PokemonContext = pokemonContext;
        }
        
        public void HealPokemon()
        {
            PokemonContext.Pokemons.Where(p=> p.Hp <= 0).ToList().ForEach(Pokemon =>
            {
                Pokemon.Hp += 50; 
                Console.WriteLine($"Pokemon {Pokemon.Name} successfully healed and now with {Pokemon.Hp} HP");
            });
            
            PokemonContext.SaveChanges();
        }   
}
}