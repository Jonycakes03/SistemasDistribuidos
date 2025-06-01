using Grpc.Core;
using PokedexApi.Controllers;
using PokedexApi.Exceptions;
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

    public async Task<IEnumerable<Trainer>> GetAllByNameAsync(string name, CancellationToken cancellationToken)
    {
        var trainers = new List<Trainer>();
        try
        {
            await foreach (var trainer in _trainerRepository.GetAllByNameAsync(name, cancellationToken))
            {
                trainers.Add(trainer);
            }
        }
        catch (RpcException ex) when (ex.StatusCode == StatusCode.InvalidArgument)
        {
            throw new TrainerValidationException("Se requiere ingresar minimo dos caracteres");
        }
        return trainers;
    }

    public async Task<(int SuccessCount, List<Trainer> CreatedTrainers)> CreateTrainerAsync(List<Trainer> trainers, CancellationToken cancellationToken)
    {
        return await _trainerRepository.CreateTrainersAsync(trainers, cancellationToken);
    }
}