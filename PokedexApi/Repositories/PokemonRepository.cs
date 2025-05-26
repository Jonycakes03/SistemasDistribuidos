using System.ServiceModel;
using PokedexApi.Infrastructure.Soap.Contracts;
using PokedexApi.Infrastructure.Soap.Dtos;
using PokedexApi.Models;
using PokedexApi.Mappers;
using PokedexApi.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;


namespace PokedexApi.Repositories;

public class PokemonRepository: IPokemonRepository {
    private readonly ILogger<PokemonRepository> _logger;
    private readonly IPokemonService _pokemonService;

    public PokemonRepository(ILogger<PokemonRepository> logger, IConfiguration configuration){
        _logger = logger;
        var endpoint = new EndpointAddress(configuration.GetValue<string>("PokemonServiceEndpoint"));
        var binding = new BasicHttpBinding();
        _pokemonService = new ChannelFactory<IPokemonService>(binding, endpoint).CreateChannel();
    }

    public async Task<Pokemon?>GetPokemonByIdAsync(Guid id, CancellationToken cancellationToken){
        try 
        {
            var pokemon = await _pokemonService.GetPokemonById(id, cancellationToken);
            return pokemon.ToModel();
        }
        catch(FaultException ex) when (ex.Message == "Pokemon Not Found :(") 
        {
            _logger.LogWarning(ex, "Failed to get pokemon with id {id}", id);
            return null;
        }
    }

    public async Task<List<Pokemon>>GetPokemonByNameAsync(String name, CancellationToken cancellationToken){
        try{
            var pokemon = await _pokemonService.GetPokemonByName(name, cancellationToken);
            return pokemon.Select(entity =>entity.ToModel()).ToList();
        }
        catch{
            _logger.LogWarning("Failed to get pokemon with name {name}", name);
            return new List<Pokemon>();
        }
    }

    public async Task<bool>DeletePokemonByIdAsync(Guid id, CancellationToken cancellationToken){
        try{
            await _pokemonService.DeletePokemon(id, cancellationToken);
            return true;
        }
        catch(FaultException ex)when (ex.Message == "Pokemon not found "){
            return false;
        }
        catch(Exception ex){
            _logger.LogError(ex, "Failed to delete pokemon with id {id}", id);
            throw;
        }
    }

    public async Task<Pokemon>CreatePokemonAsync(Pokemon pokemon, CancellationToken cancellationToken){
        try{
            var pokemonCreated = await _pokemonService.CreatePokemon(pokemon.ToSoapDto(), cancellationToken);
            return pokemonCreated.ToModel();
    }
    catch(FaultException ex) when(ex.Message.Contains("Pokemon"))
    {
        throw new PokemonValidationException(ex.Message);
    }
    catch(FaultException ex)
    {
        _logger.LogError(ex, "Error creating pokemon");
        throw;
    }
        
    }

    public async Task UpdatePokemonAsync(Pokemon pokemon, CancellationToken cancellationToken){
        try{
            await _pokemonService.UpdatePokemon(pokemon.ToUpdateSoapDto(), cancellationToken);
        }
        catch(FaultException ex) when (ex.Message.Contains("Pokemon not found"))
        {
            throw new PokemonNotFoundException(ex.Message);
        }
        catch(FaultException ex)
        {
            _logger.LogError(ex, "Error updating pokemon");
            throw;

        }
    }


}