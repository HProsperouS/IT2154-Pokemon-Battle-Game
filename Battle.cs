using System;
using System.Collections.Generic;
using System.Linq;
namespace PokemonPocket
{
    class Battle
    {

        private List<Pokemon> Pokemons { get; set; }
        private List<Pokemon> EnemyPokemonPool { get; set; } = new List<Pokemon>(){
            new Pikachu(30,0), 
            new Eevee(30,0), 
            new Raichu(30,30)
        };
        public Battle(PokemonContext pokemonContext) { 
            Pokemons = pokemonContext.Pokemons.ToList(); 
        }

        public void Fight()
        {
            int pokemonwith0hp = Pokemons.Where(pokemon => pokemon.Hp == 0).ToList().Count();
            
            if (pokemonwith0hp == Pokemons.Count()){
                Console.WriteLine("All pokemons are 0 hp, please heal them first");
            }
            else{
                Console.WriteLine("Choose your pokemon: ");
                for (int i = 0; i < Pokemons.Count; i++)
                {
                    Pokemon p = Pokemons[i];
                    Console.WriteLine($"({i+1}) {p.Name} HP: {p.Hp}");
                }
                // Get Index
                while (true){
                    try{
                        int response = Int32.Parse(Console.ReadLine());
                        Pokemon pokemon = Pokemons[response-1];
                        // GET ENEMY POKEMON
                        // random number from 0 to EnemyPokemonPool.Count
                        Random rnd = new Random();
                        int num = rnd.Next(0,EnemyPokemonPool.Count);
                            
                        Pokemon enemyPokemon = EnemyPokemonPool[num];

                        while (enemyPokemon.Hp > 0 && pokemon.Hp > 0)
                        {
                            enemyPokemon.Hp -= pokemon.SkillDamage;
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(pokemon.Name);
                            Console.ResetColor();
                            Console.WriteLine($" used {pokemon.Skill} and causes {pokemon.SkillDamage} damages!");
                            if (enemyPokemon.Hp <= 0) {
                                Console.WriteLine("You won!!");
                                break;
                            }

                            pokemon.Hp -= enemyPokemon.SkillDamage;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(enemyPokemon.Name);
                            Console.ResetColor();
                            Console.WriteLine($" used {enemyPokemon.Skill} and causes {enemyPokemon.SkillDamage}! damages");
                            if (pokemon.Hp <= 0) {
                                Console.WriteLine("You Loss!!");
                                pokemon.Hp = 0;
                                break;
                            }
                        }
                                break;
                    }
                    catch(Exception){
                        Console.WriteLine("Please enter correct number!!");
                        continue;
                    }
                }
            }
        }
    }
}