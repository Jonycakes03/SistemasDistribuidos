namespace PokedexApi.Services;
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
}