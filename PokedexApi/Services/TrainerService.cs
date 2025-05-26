using PokedexApi.Models;
using PokedexApi.Repositories;

namespace PokedexApi.Services;

public class TrainerService : ITrainerService
{
    private readonly ITrainerRepository _trainerRepository;

    public TrainerService(ITrainerRepository trainerRepository)
    {
        _trainerRepository = trainerRepository;
    }
    public async Task<Trainer?> GetTrainerByIdAsync(string id, CancellationToken cancellationToken)
    {
        return await _trainerRepository.GetTrainerByIdAsync(id, cancellationToken);
    }
}