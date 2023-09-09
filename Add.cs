using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonPocket{
    class Add
    {
        public PokemonContext PokemonContext {get; set;} 

        public Add(PokemonContext pokemonContext){
            PokemonContext = pokemonContext;
        }
        
        public void AddPokemon()
        {
            int baglimit = 10;
            int count = PokemonContext.Pokemons.Count();

            if (count >= baglimit)
            {
                Console.WriteLine("Your backpack is full, please remove some Pokémon first");
                return;
            }

            // Asks user for pokemon attributes
            Console.WriteLine("Enter Name of Pokemon: ");
            string name = Console.ReadLine().ToLower();  // pIkacHu -> pikachu
            // Captialize the first letter
            name = char.ToUpper(name[0]) + name.Substring(1); // pikachu -> Pikachu
            // Checks if the value of `name` is inside Species Enum
            while (!(Enum.IsDefined(typeof(Pokemon.Species), name)))
            {
                Console.WriteLine("That is not a valid pokemon");
                name = Console.ReadLine().ToLower();
                if (name.Length == 0) { continue; }
                name = char.ToUpper(name[0]) + name.Substring(1);
            }

            int hp = 0;
            int exp = 0;
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter HP of Pokemon: ");
                    hp = int.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("That is not a number!!");
                    continue;
                }
            }
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter Exp of Pokemon: ");
                    exp = int.Parse(Console.ReadLine());
                    break;
                }
                catch
                {
                    Console.WriteLine("That is not a number!!");
                    continue;
                }
            }

            // Gets the Class Type inside of the Namespace PokemonPocket
            Type pokemonSpecies = Type.GetType($"PokemonPocket.{name}");
            // Creates an instance of the Type `pokemonSpecies` and cast from `object` to `Pokemon`
            Pokemon newPokemon = (Pokemon)Activator.CreateInstance(pokemonSpecies, hp, exp);
            Console.WriteLine($"{name} Added Successfully");
            // Add pokemon to database
            PokemonContext.Pokemons.Add(newPokemon);
            PokemonContext.SaveChanges();
    }
}
}