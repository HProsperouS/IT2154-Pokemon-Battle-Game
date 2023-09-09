using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // allows data annotation
using Microsoft.EntityFrameworkCore;

namespace PokemonPocket
{

    public class PokemonMaster
    {
        [Key] // sets name as primary key
        public string Name { get; set; }
        public int NoToEvolve { get; set; }
        public string EvolveTo { get; set; }
    }

    public class Pokemon
    {
        public enum Species
        {
            Pikachu,
            Raichu,
            Charmander,
            Charmeleon,
            Eevee,
            Flareon
        }
        // For entity framework
        public Pokemon() { }
        public Pokemon(int hp, int exp)
        {
            Name = GetType().Name;  // Gets `Type` of the current instance
            Hp = hp;
            Exp = exp;
        }

        [Key]
        public int PokemonID { get; set; }
        public string Name { get; set; }
        public int Hp { get; set; }
        public int Exp { get; set; }
        public string Skill { get; set; }
        public int SkillDamage { get; set; }
    }

    public class Pikachu : Pokemon
    {
        public Pikachu(int hp, int exp) : base(hp, exp)
        {
            Skill = "Lightning Bolt";
            Random rnd = new Random();
            SkillDamage = rnd.Next(20,30);
        }
    }

    public class Eevee : Pokemon
    {
        public Eevee(int hp, int exp) : base(hp, exp)
        {
            Skill = "Run Away";
            SkillDamage = 10;
        }
    }

    public class Charmander : Pokemon
    {
        public Charmander(int hp, int exp) : base(hp, exp)
        {
            Skill = "Solar Power";
            Random rnd = new Random();
            SkillDamage = rnd.Next(10,20);
        }

    }

    public class Raichu : Pikachu
    {
        public Raichu(int hp, int exp) : base(hp, exp)
        {
            Skill = "Lightning Bolt";
            Random rnd = new Random();
            SkillDamage = rnd.Next(20,40);            
        }

    }

    public class Charmeleon : Charmander
    {
        public Charmeleon(int hp, int exp) : base(hp, exp)
        {
            Skill = "Run Away";
            SkillDamage = 20;
        }

    }

    public class Flareon : Eevee
    {
        public Flareon(int hp, int exp) : base(hp, exp)
        {
            Skill = "Solar Power";
            Random rnd = new Random();
            SkillDamage = rnd.Next(15,30);
        }

    }

    // Connects the application to the database
    // Allows read / write to database
    public class PokemonContext : DbContext
    {
        // Variable Pokemons is a DbSet of Pokemons
        public DbSet<Pokemon> Pokemons { get; set; }
        // Variable PokemonMaster is a DbSet of PokemonMaster
        public DbSet<PokemonMaster> PokemonMasters { get; set; }

        // Sets path to Pokemon.db
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Pokemon.db");
        }
    }
}