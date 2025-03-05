using PokemonApi.Dtos;
using PokemonApi.Models;

namespace PokemonApi.Repositories;

public interface IBookRepository{
    Task<List<Book>>GetByNameAsync(String title, CancellationToken cancellationToken);

}