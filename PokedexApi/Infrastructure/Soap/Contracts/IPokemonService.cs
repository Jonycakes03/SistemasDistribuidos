using System.ServiceModel;
using PokedexApi.Infrastrucure.Soap.Dtos;


namespace PokedexApi.Infrastrucure.Soap.Contracts;

[ServiceContract(Name = "PokemonService", Namespace ="http://pokemon-api/pokemon-service")]


public interface IPokemonService
{
    [OperationContract]
    Task<PokemonResponseDto> GetPokemonById(Guid id, CancellationToken cancellationToken);

    [OperationContract]
    Task<bool> DeletePokemon(Guid id, CancellationToken cancellationToken);
    [OperationContract]
    Task<PokemonResponseDto> CreatePokemon(CreatePokemonDto createPokemonDto, CancellationToken cancellationToken);

    [OperationContract]
    Task<PokemonResponseDto> UpdatePokemon(UpdatePokemonDto pokemon, CancellationToken cancellationToken);

}