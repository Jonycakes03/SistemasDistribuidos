using PokedexApi.Models;

namespace PokedexApi.Services;



public interface IHobbiesService{
    Task<Hobby?> GetHobbyByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<List<Hobby>>GetHobbyByNameAsync(String name, CancellationToken cancellationToken);

    Task<bool> DeleteHobbyByIdAsync(Guid id, CancellationToken cancellationToken);
}