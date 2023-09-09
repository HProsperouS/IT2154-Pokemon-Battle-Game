using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonPocket{
    class Remove
    {
        public PokemonContext pokemonContext {get; set;} 

        public Remove(){
            pokemonContext = new PokemonContext();
        }
        
        public void RemovePokemon()
        {
            if (pokemonContext.Pokemons.ToList().Count() == 0){
                Console.WriteLine("You don't have any pokemon in your bag");
            }
            else{
                Console.WriteLine("Enter Pokemon Name to Remove: ");
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

            List<Pokemon> pokemon = pokemonContext.Pokemons.ToList()
                            .Where(pokemon => pokemon.Name == name)
                            .ToList();

            int count = pokemonContext.Pokemons
                    .Where(pokemon => (pokemon.Name == name))
                    .Count();

            if (count == 1)
            {
                pokemonContext.Pokemons.Remove(pokemon.First());
                Console.WriteLine($"Succsfully removed {name}");

            }
            else if (count > 1)
            {
                pokemonContext.Pokemons.Where(p => p.Name == name).ToList().ForEach(pokemon =>
                {
                    Console.WriteLine($"----------------------");
                    Console.WriteLine($"Name: " + pokemon.Name);
                    Console.WriteLine($"HP: " + pokemon.Hp);
                    Console.WriteLine($"Exp: " + pokemon.Exp);
                    Console.WriteLine($"Skill: " + pokemon.Skill);
                    Console.WriteLine($"----------------------");
                });

                Console.WriteLine($"1.Remove the first {name}");
                Console.WriteLine($"2.Remove the last {name}");
                Console.WriteLine($"3.Remove the lowest hp {name}");
                Console.WriteLine($"4.Remove all {name}");

                Console.WriteLine("Please Enter Your Choice: ");
                string option = Console.ReadLine();

                if (option == "1")
                {
                    pokemonContext.Pokemons.Remove(pokemon.First());
                    Console.WriteLine($"Succsfully removed {name}");
                }
                else if (option == "2")
                {
                    pokemonContext.Pokemons.Remove(pokemon[pokemon.Count - 1]);
                    Console.WriteLine($"Succsfully removed {name}");
                }
                else if (option == "3")
                {
                    pokemonContext.Pokemons.Remove(pokemon.OrderBy(p => p.Hp).First());
                    Console.WriteLine($"Succsfully removed {name}");
                }
                else if (option == "4")
                {
                    pokemonContext.Pokemons.RemoveRange(pokemon);
                }
                else
                {
                    Console.WriteLine("Invalid Input Please Try Again");
                }
            }
            else
            {
                Console.WriteLine($"No pokemon with name {name}");
            }

            pokemonContext.SaveChanges();
            }
        }
    }
}