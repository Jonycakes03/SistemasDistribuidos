using System.Runtime.Serialization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace PokedexApi.Infrastrucure.Soap.Dtos;

[DataContract(Name = "CreatePokemonDto", Namespace ="http://pokemon-api/pokemon-service")]
public class CreatePokemonDto : PokemonCommonDto{

  

    }