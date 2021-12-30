using Microsoft.EntityFrameworkCore;
using PokemonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonAPI.Data
{
    public class PokemonContext : DbContext
    {
        public PokemonContext(DbContextOptions<PokemonContext> opt) : base(opt)
        {

        }

        public DbSet<Pokemon> Pokemons { get; set; }
    }
}
