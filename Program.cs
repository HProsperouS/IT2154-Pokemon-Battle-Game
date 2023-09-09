using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace PokemonPocket
{

    class Game
    {
        // access to database
        // "data handler"
        public PokemonContext pokemonContext = new PokemonContext();
        public void Start()
        {

            // This makes sure that the database is created.
            // If database doesn't exist, it will create it
            // pokemonContext.Database.EnsureDeleted();
            // pokemonContext.Database.EnsureCreated();

            // // This adds the the pokemons to the Pokemon data set
            // pokemonContext.Pokemons.RemoveRange(pokemonContext.Pokemons.ToList());
            // pokemonContext.Pokemons.AddRange(new List<Pokemon>(){
            //     new Pikachu(100, 100),
            //     new Eevee(100,100),
            //     new Charmander(100,100)
            //     // new Pikachu(100, 100),
            //     // new Eevee(100,100),
            //     // new Charmander(100,100),
            //     // new Pikachu(100, 100),
            //     // new Eevee(100,100),
            //     // new Charmander(100,100)
            // });

            // // This adds the PokemonMaster to the PokemonMaster data set
            // pokemonContext.PokemonMasters.RemoveRange(pokemonContext.PokemonMasters.ToList());
            // pokemonContext.PokemonMasters.AddRange(new List<PokemonMaster>(){
            //     new PokemonMaster(){Name = "Pikachu", NoToEvolve= 2, EvolveTo = "Raichu"},
            //     new PokemonMaster(){Name = "Eevee", NoToEvolve = 3, EvolveTo = "Flareon"},
            //     new PokemonMaster(){Name = "Charmander", NoToEvolve = 1, EvolveTo = "Charmeleon"},

            // });

            // pokemonContext.SaveChanges();


            while (true)
            {
                // Game loop
                Menu();
                getChoice();
            }
        }

        public void Menu()
        {
            Console.WriteLine("**************************");
            Console.WriteLine("Welcome to Pokemon Pocket");
            Console.WriteLine("**************************");
            Console.WriteLine("(1) Add Pockemon to my Pocket");
            Console.WriteLine("(2) List Pokemon(s) in my Pocket");
            Console.WriteLine("(3) Check if I can evolve Pokemon");
            Console.WriteLine("(4) Evolve Pokemon");
            Console.WriteLine("(5) Remove Pokemon");
            Console.WriteLine("(6) Start Random Battle");
            Console.WriteLine("(7) Heal all 0 HP pokemon with 50 HP");
            Console.WriteLine("Please only enter [1,2,3,4,5,6,7] or Q to quit: ");
        }

        public void getChoice()
        {
            string option;
            option = Console.ReadLine();
            try
            {
                switch (option)
                {
                    case "1":
                        Add add = new Add(pokemonContext);
                        add.AddPokemon();
                        break;
                    case "2":
                        List list = new List(pokemonContext);
                        list.ListPokemon();
                        break;
                    case "3":
                        Check check = new Check(pokemonContext);
                        check.CheckEvolvePokemon();
                        break;
                    case "4":
                        Evolve evolve = new Evolve(pokemonContext);
                        evolve.EvolvePokemon();
                        break;
                    case "5":
                        Remove remove = new Remove();
                        remove.RemovePokemon();
                        break;
                    case "6":
                        Battle battle = new Battle(pokemonContext);
                        battle.Fight();
                        pokemonContext.SaveChanges();
                        break;

                    case "7":
                        Heal heal = new Heal(pokemonContext);
                        heal.HealPokemon();
                        pokemonContext.SaveChanges();
                        break;
                    case "Q":
                        Console.WriteLine("App Exited");
                        Environment.Exit(0);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Invalid Input Please Try Again");
            }

        }

    }

    class Program
    {
        public static void Main()
        {
            Game game = new Game();
            game.Start();
        }
    }
}
