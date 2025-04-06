namespace PokedexApi.Dtos;

public class PokemonResponse{
    public Guid Id{get; set;}
    public required string Name {get; set;}
    public required string Type {get; set;}
    public int Level{get; set;}

    public string Weakness{get; set;}

    public required StatsResponse Stats{get;set;}

}