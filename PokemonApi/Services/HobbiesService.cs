using System.Formats.Asn1;
using System.ServiceModel;
using PokemonApi.Dtos;
using PokemonApi.Mappers;
using PokemonApi.Repositories;
using PokemonApi.Validators;

namespace PokemonApi.Services;

public class HobbiesService : IHobbiesService
{
    private readonly IHobbiesRepository _hobbiesRepository;
    public HobbiesService(IHobbiesRepository hobbiesRepository){
        _hobbiesRepository = hobbiesRepository;
    }
    public async Task<HobbiesResponseDto> GetHobbyById(Guid id, CancellationToken cancellationToken){
        var hobby = await _hobbiesRepository.GetByIdAsync(id, cancellationToken);
        if (hobby is null){
            throw new FaultException("Hobby Not Found :(");
        }
        return hobby.ToDto();
    }

    public async Task<bool> DeleteHobby(Guid id, CancellationToken cancellationToken){
        var hobby = await _hobbiesRepository.GetByIdAsync(id, cancellationToken);
        if (hobby is null){
        throw new FaultException("Hobby not found ");
    }
        await _hobbiesRepository.DeleteAsync(hobby, cancellationToken);
        return true;
    }

    public async Task<List<HobbiesResponseDto>>GetHobbyByName(String name, CancellationToken cancellationToken){
        var hobby = await _hobbiesRepository.GetByNameAsync(name, cancellationToken);
        if (hobby is null || hobby.Count == 0){
            return new List<HobbiesResponseDto>();
        }
        return hobby.Select(hobby => hobby.ToDto()).ToList();
    }

    public async Task<HobbiesResponseDto> CreateHobby(CreateHobbiesDto hobby, CancellationToken cancellationToken){
        var hobbyToCreate = hobby.ToModel();

        hobbyToCreate.ValidateName().ValidateTop();
        await _hobbiesRepository.AddAsync(hobbyToCreate, cancellationToken);
        return hobbyToCreate.ToDto();
    }

    public async Task<HobbiesResponseDto> UpdateHobby(UpdateHobbiesDto hobby, CancellationToken cancellationToken){
        var hobbyToUpdate = await _hobbiesRepository.GetByIdAsync(hobby.Id, cancellationToken);
        if (hobbyToUpdate is null){
            throw new FaultException("Hobby not found");
        }
        hobbyToUpdate.Name = hobby.Name;
        hobbyToUpdate.Top = hobby.Top;

        await _hobbiesRepository.UpdateAsync(hobbyToUpdate, cancellationToken);
        return hobbyToUpdate.ToDto();
    }

}