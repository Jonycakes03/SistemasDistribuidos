using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PokedexApi.Services;
using PokedexApi.Mappers;
using PokedexApi.Dtos;

namespace PokedexApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")] //versionar por pruta o por metadata
public class PokemonsController: ControllerBase 
{
    private readonly IPokemonService _pokemonService;
    public PokemonsController(IPokemonService pokemonService)
    {
        _pokemonService = pokemonService;
    }
    //lcoalhost/api/v1/pokemons 
    [HttpGet("{id}")]
    public async Task<ActionResult<PokemonResponse>> GetPokemonByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var pokemon = await _pokemonService.GetPokemonByIdAsync(id, cancellationToken);
        if (pokemon is null){
            return NotFound();
        }
        return Ok(pokemon.ToDto());

    }

    //[HttpGet("/name/{name})]
    //

    [HttpGet]
    public async Task<ActionResult<List<PokemonResponse>>> GetPokemonByNameAsync([FromQuery] String? name, CancellationToken cancellationToken)
    {
        if (String.IsNullOrWhiteSpace(name))
        {
            return BadRequest("Name is required");
        }
    var pokemons = await _pokemonService.GetPokemonByNameAsync(name, cancellationToken);
    if (pokemons == null || !pokemons.Any()) // Verifica si la lista está vacía o es null
    {
        return Ok(new List<PokemonResponse>());
    }

    return Ok(pokemons.Select(p => p.ToDto()).ToList());
    }
    //404 not found
    //204 NOContent (se enconttro y se eelimon el pokemon de manera correcta pero no regresa nada)
    //200 ok (se encontro y regresa el pokemon)
    //{status succes}

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePokemonById(Guid id, CancellationToken cancellationToken){
        var deleted = await _pokemonService.DeletePokemonByIdAsync(id, cancellationToken);
        if (deleted){
            return NoContent(); //204
        }
        return NotFound(); //404
    }


}

