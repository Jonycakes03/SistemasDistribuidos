using System.ServiceModel;

using PokemonApi.Dtos;

namespace PokemonApi.Services;

[ServiceContract(Name = "HobbiesService", Namespace ="http://pokemon-api/hobbies-service")]


public interface IHobbiesService
{
    [OperationContract]
    Task<HobbiesResponseDto> GetHobbyById(Guid id, CancellationToken cancellationToken);

    [OperationContract]
    Task<bool> DeleteHobby(Guid id, CancellationToken cancellationToken);
    [OperationContract]
    Task<List<HobbiesResponseDto>>GetHobbyByName(String name, CancellationToken cancellationToken);
    [OperationContract]
    Task<HobbiesResponseDto> CreateHobby(CreateHobbiesDto createHobbiesDto, CancellationToken cancellationToken);
    [OperationContract]
    Task<HobbiesResponseDto> UpdateHobby(UpdateHobbiesDto hobby, CancellationToken cancellationToken);
}