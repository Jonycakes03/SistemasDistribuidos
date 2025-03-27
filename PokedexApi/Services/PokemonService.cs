namespace PokedexApi.Services;

using PokedexApi.Exceptions;
using PokedexApi.Infrastrucure.Soap.Dtos;
using PokedexApi.Models;
using PokedexApi.Repositories;

public class PokemonService : IPokemonService
{
    private readonly IPokemonRepository _pokemonRepository;
    public PokemonService(IPokemonRepository pokemonRepository)
    {
        _pokemonRepository = pokemonRepository;
    }
    public async Task<Pokemon?> GetPokemonByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _pokemonRepository.GetPokemonByIdAsync(id, cancellationToken);
    }

    public async Task<List<Pokemon>> GetPokemonByNameAsync(string name, CancellationToken cancellationToken)
    {
        var pokemons = await _pokemonRepository.GetPokemonByNameAsync(name, cancellationToken);
    return pokemons ?? new List<Pokemon>();
    }

    public async Task<bool> DeletePokemonByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _pokemonRepository.DeletePokemonByIdAsync(id, cancellationToken);
    }

    public async Task<Pokemon> CreatePokemonAsync(Pokemon pokemon, CancellationToken cancellationToken)
    {
        var existing = await GetPokemonByNameAsync(pokemon.Name, cancellationToken);
        if (existing.Any())
        {
            throw new NameValidationException(pokemon.Name);
        }
        return await _pokemonRepository.CreatePokemonAsync(pokemon, cancellationToken);
    }

    public async Task UpdatePokemonAsync(Guid id, Pokemon pokemon, CancellationToken cancellationToken)
    {
        var pokemons = await _pokemonRepository.GetPokemonByNameAsync(pokemon.Name, cancellationToken);
        if(pokemons.Any(s => s.Name.ToLower() == pokemon.Name.ToLower() && s.Id != id)){
            throw new NameValidationException(pokemon.Name);

        }
        if(pokemon.Level <= 0 ){
            throw new PokemonValidationException("Level must be greater than 0");
        }
        pokemon.Id = id;
        await _pokemonRepository.UpdatePokemonAsync(pokemon, cancellationToken);
    }
}