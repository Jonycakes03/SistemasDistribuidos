using System.Runtime.Serialization;

namespace PokemonApi.Dtos;

[DataContract(Name = "HobbiesCommonDto", Namespace = "http://pokemon.api/hobbies-service")]
[KnownType(typeof(CreateHobbiesDto))]
[KnownType(typeof(UpdateHobbiesDto))]

public class HobbiesCommonDto{
    [DataMember(Name ="Name", Order =1)]
    public string Name {get; set;}
   [DataMember(Name = "Top", Order = 2)]
   public int Top { get; set; }
}