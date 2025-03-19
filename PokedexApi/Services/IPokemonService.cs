using PokedexApi.Models;

namespace PokedexApi.Services;



public interface IPokemonService{
    Task<Pokemon?> GetPokemonByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<List<Pokemon>>GetPokemonByNameAsync(String name, CancellationToken cancellationToken);

}