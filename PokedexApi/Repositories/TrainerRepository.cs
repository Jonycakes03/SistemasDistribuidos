using Grpc.Core;
using PokedexApi.Infrastructure.Grpc;
using PokedexApi.Mappers;
using PokedexApi.Models;

namespace PokedexApi.Repositories;

public class TrainerRepository : ITrainerRepository
{
    private readonly TrainerService.TrainerServiceClient _client;
    public TrainerRepository(TrainerService.TrainerServiceClient client)
    {
        _client = client;
    }

    public async Task<Trainer?> GetTrainerByIdAsync(string id, CancellationToken cancellationToken)
    {
        try
        {
            Console.WriteLine($"gRPC Request: GetTrainerByIdAsync with id: {id}");
            var trainer = await _client.GetTrainerAsync(new TrainerByIdRequest { Id = id }, cancellationToken: cancellationToken);
            return trainer.ToModel();

        }
        catch (RpcException ex) when (ex.StatusCode == StatusCode.NotFound)
        {
            Console.WriteLine($"gRPC Error: Trainer with id {id} not found.");
            return null;

        }
        catch (RpcException ex)
    {
        Console.WriteLine($"gRPC Error: {ex.Status.Detail}");
        // Optionally: log ex.StatusCode
        return null; // or throw new custom exception if needed
    }

    }
}