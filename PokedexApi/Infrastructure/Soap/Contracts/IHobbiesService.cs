using System.ServiceModel;

using PokedexApi.Infrastructure.Soap.Dtos;

namespace PokedexApi.Infrastructure.Soap.Contracts;


[ServiceContract(Name = "HobbiesService", Namespace ="http://pokemon-api/hobbies-service")]


public interface IHobbiesService
{
    [OperationContract]
    Task<HobbiesResponseDto>GetHobbyById(Guid id, CancellationToken cancellationToken);

    [OperationContract]
    Task<bool> DeleteHobby(Guid id, CancellationToken cancellationToken);
    [OperationContract]
    Task<List<HobbiesResponseDto>>GetHobbyByName(String name, CancellationToken cancellationToken);
}