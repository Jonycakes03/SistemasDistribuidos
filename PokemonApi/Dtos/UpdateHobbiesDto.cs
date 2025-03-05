using System.Runtime.Serialization;

namespace PokemonApi.Dtos;

[DataContract(Name = "UpdateHobbiesDto", Namespace ="http://pokemon-api/hobbies-service")]
public class UpdateHobbiesDto : HobbiesCommonDto 
{
    [DataMember(Name = "Id", Order = 3)]
    public Guid Id { get; set; }
    
}