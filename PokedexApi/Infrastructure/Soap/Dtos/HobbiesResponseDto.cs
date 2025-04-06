using System.Runtime.Serialization;

namespace PokedexApi.Infrastrucure.Soap.Dtos;

[DataContract(Name = "HobbiesResponseDto", Namespace = "http://pokemon-api/hobbies-service")]
public class HobbiesResponseDto
{
    [DataMember(Name = "Id", Order = 1)]
    public Guid Id {get; set;}
    [DataMember(Name = "Name", Order = 2)]
    public string Name {get; set;}
    [DataMember(Name = "Top", Order = 3)]
    public int Top {get; set;}

}