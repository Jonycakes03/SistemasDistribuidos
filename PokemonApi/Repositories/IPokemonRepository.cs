using PokemonApi.Models;

namespace PokemonApi.Repositories;

public interface IPokemonRepository{
    Task<Pokemon> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task DeleteAsync(Pokemon pokemon, CancellationToken cancellationToken);
    Task AddAsync(Pokemon pokemon, CancellationToken cancellationToken);

    Task UpdateAsync(Pokemon pokemon, CancellationToken cancellationToken);

    Task<List<Pokemon>>GetByNameAsync(String name, CancellationToken cancellationToken);    
}