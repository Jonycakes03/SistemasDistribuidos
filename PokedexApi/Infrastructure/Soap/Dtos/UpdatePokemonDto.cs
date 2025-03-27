using System.Runtime.Serialization;

namespace PokedexApi.Infrastrucure.Soap.Dtos;

[DataContract(Name = "UpdatePokemonDto", Namespace ="http://pokemon-api/pokemon-service")]
public class UpdatePokemonDto : PokemonCommonDto 
{
    [DataMember(Name = "Id", Order = 6)]
    public Guid Id { get; set; }
    
}