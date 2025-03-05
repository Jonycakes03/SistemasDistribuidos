using System.Runtime.Serialization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace PokemonApi.Dtos;

[DataContract(Name = "CreateHobbiesDto", Namespace ="http://pokemon-api/hobbies-service")]
public class CreateHobbiesDto : HobbiesCommonDto{

  

    }