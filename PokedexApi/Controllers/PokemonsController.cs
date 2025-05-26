using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PokedexApi.Services;
using PokedexApi.Mappers;
using PokedexApi.Dtos;
using PokedexApi.Infrastructure.Soap.Dtos;
using PokedexApi.Exceptions;

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
    public async Task<ActionResult<PokemonResponse>> GetPokemonById(Guid id, CancellationToken cancellationToken)
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

    //200 - ok (se creo el pokemon de manera correcta)
    //201 - Created (se creo el pokemon de manera correcta, en header regresa la url del recurso creado)
    [HttpPost] //400- Bad request(usuario ingreso un valor incorrecto ) 409 - Conflict (el recurso ya existe)
    public async Task<ActionResult<PokemonResponse>> CreatePokemon([FromBody] CreatePokemonRequest pokemon, CancellationToken cancellationToken){
        try{
            var createdPokemon = await _pokemonService.CreatePokemonAsync(pokemon.ToModel(), cancellationToken);
        return CreatedAtAction(nameof(GetPokemonById), new{id = createdPokemon.Id},createdPokemon.ToDto());
        }
        catch(PokemonValidationException ex)
        {
            return BadRequest(new{message = ex.Message});
        }
        catch(NameValidationException ex)
    {
        return Conflict(new {message = "Pokemon {Name}already exists", pokemon.Name});
    }
        
    }
    //put - actualiza todo el recurso
    //404 - Not found (no se encontro el recurso)
    //400 - Bad request (usuario ingreso un valor incorrecto)
    //200 - Ok (se actualizo el pokemon de manera correcta)
    //409 - Conflict (el recurso ya existe)
    //204 - No content (se elimino el pokemon de manera correcta pero no regresa nada)
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePokemon(Guid id, [FromBody] UpdatePokemonRequest pokemon, CancellationToken cancellationToken){
        try{
            await _pokemonService.UpdatePokemonAsync(id, pokemon.ToModel(), cancellationToken);
            return NoContent();
        }
        catch(NameValidationException)
        {
        return Conflict(new {message = "Pokemon {Name}already exists", pokemon.Name});

        }
        catch (PokemonValidationException ex)
        {
            return BadRequest(new {message =ex.Message});
        }
        catch(PokemonNotFoundException)
        {
            return NotFound();

        }
    }
//patch - actualiza solo los campos que se envian
//[httppatch]
}

