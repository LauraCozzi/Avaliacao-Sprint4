using Microsoft.AspNetCore.Mvc;
using PokemonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PokemonController : ControllerBase
    {
        private static List<Pokemon> pokemons = new List<Pokemon>();
        private static int id = 1;

        // https://localhost:44302/api/pokemon
        [HttpGet]
        public IActionResult RecuperaPokemons()
        {
            Console.WriteLine("Lista de Pokemons:");
            foreach (Pokemon pokemon in pokemons)
            {
                Console.WriteLine(pokemon.Nome);
            }
            Console.WriteLine("Fim da lista de Pokemons:");

            return Ok(pokemons);
        }

        // https://localhost:44302/api/pokemon
        [HttpPost]
        public IActionResult AdicionaPokemon([FromBody] Pokemon pokemon)
        {
            pokemon.Id = id++;
            pokemons.Add(pokemon);
            return CreatedAtAction(nameof(RecuperaPokemonPorId), new { Id = pokemon.Id }, pokemon);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaPokemonPorId(int id)
        {
            Pokemon pokemon = pokemons.FirstOrDefault(pokemon => pokemon.Id == id);
            if (pokemon == null)
            {
                return NotFound();
            }
            return Ok(pokemon);
        }

        // https://localhost:44302/api/pokemon/1 sendo 1 o id do pokemon 
        [HttpDelete("{id}")]
        public IActionResult DeletaPokemon(int id)
        {
            Pokemon pokemon = pokemons.FirstOrDefault(pokemon => pokemon.Id == id);

            // se diferente de null pokemon de id passado como argumento foi encontrado
            if (pokemon != null)
            {
                pokemons.Remove(pokemon);
            }
            else
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
