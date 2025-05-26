namespace PokedexApi.Services;
using PokedexApi.Infrastructure.Soap.Dtos;
using PokedexApi.Models;
using PokedexApi.Repositories;

public class HobbiesService : IHobbiesService
{
    private readonly IHobbiesRepository _hobbiesRepostiory;
    public HobbiesService(IHobbiesRepository hobbiesRepository)
    {
        _hobbiesRepostiory = hobbiesRepository;
    }
    public async Task<Hobby?> GetHobbyByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _hobbiesRepostiory.GetHobbyByIdAsync(id, cancellationToken);
    }

    public async Task<List<Hobby>> GetHobbyByNameAsync(string name, CancellationToken cancellationToken)
    {
        var hobbies = await _hobbiesRepostiory.GetHobbyByNameAsync(name, cancellationToken);
    return hobbies ?? new List<Hobby>();
    }

    public async Task<bool> DeleteHobbyByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _hobbiesRepostiory.DeleteHobbyByIdAsync(id, cancellationToken);
    }
}