using System.Runtime.Serialization;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Net.Http.Headers;

namespace PokemonApi.Dtos;

[DataContract(Name = "CreatePokemonDto", Namespace ="http://pokemon-api/pokemon-service")]
public class CreatePokemonDto{

    [DataMember(Name ="Name", Order =1)]
    public string Name {get; set;}
    [DataMember(Name ="Type", Order =2)]

    public string Type {get; set;}
    [DataMember(Name ="Level", Order =3)]

    public int Level {get; set;}
    [DataMember(Name ="Weakness", Order =4)]

    public string Weakness {get; set;}
    [DataMember(Name ="Stats", Order =5)]

    public StatsDto Stats {get; set;}

    }