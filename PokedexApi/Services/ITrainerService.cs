using PokedexApi.Infrastructure.Grpc;
using PokedexApi.Models;

namespace PokedexApi.Services;

public interface ITrainerService
{
    Task<Trainer?> GetTrainerByIdAsync(string id, CancellationToken cancellationToken);
}