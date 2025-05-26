using PokedexApi.Models;

namespace PokedexApi.Repositories;

public interface ITrainerRepository
{
    Task<Trainer>? GetTrainerByIdAsync(string id, CancellationToken cancellationToken);
}