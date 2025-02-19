using PokemonApi.Models;

namespace PokemonApi.Repositories;

public interface IPokemonRepository{
    Task<Pokemon> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}