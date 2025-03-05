using PokemonApi.Dtos;
using PokemonApi.Models;

namespace PokemonApi.Repositories;

public interface IHobbiesRepository{
    Task<Hobby> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task DeleteAsync(Hobby hobby, CancellationToken cancellationToken);
    Task AddAsync(Hobby hobby, CancellationToken cancellationToken);
    Task<List<Hobby>>GetByNameAsync(String name, CancellationToken cancellationToken);
    Task UpdateAsync(Hobby hobby, CancellationToken cancellationToken);

}