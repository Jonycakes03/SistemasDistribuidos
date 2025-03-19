using System.ServiceModel;
using PokedexApi.Infrastrucure.Soap.Contracts;
using PokedexApi.Models;
using PokedexApi.Mappers;



namespace PokedexApi.Repositories;

public class HobbiesRepository: IHobbiesRepository {
    private readonly ILogger<HobbiesRepository> _logger;
    private readonly IHobbiesService _hobbiesService;

    public HobbiesRepository(ILogger<HobbiesRepository> logger, IConfiguration configuration){
        _logger = logger;
        var endpoint = new EndpointAddress(configuration.GetValue<string>("HobbiesServiceEndpoint"));
        var binding = new BasicHttpBinding();
        _hobbiesService = new ChannelFactory<IHobbiesService>(binding, endpoint).CreateChannel();
    }

    public async Task<Hobby?>GetHobbyByIdAsync(Guid id, CancellationToken cancellationToken){
        try 
        {
            var hobbies = await _hobbiesService.GetHobbyById(id, cancellationToken);
            return hobbies.ToModel();
        }
        catch(FaultException ex) when (ex.Message == "Hobby Not Found :(") 
        {
            _logger.LogWarning(ex, "Failed to get Hobby with id {id}", id);
            return null;
        }
    }

    public async Task<List<Hobby>>GetHobbyByNameAsync(String name, CancellationToken cancellationToken){
        try{
            var hobbies = await _hobbiesService.GetHobbyByName(name, cancellationToken);
            return hobbies.Select(entity =>entity.ToModel()).ToList();
        }
        catch{
            _logger.LogWarning("Failed to get hobby with name {name}", name);
            return new List<Hobby?>();
        }
    }
}