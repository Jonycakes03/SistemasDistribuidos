namespace PokedexApi.Dtos;

public class UpdatePokemonRequest
{
    public required string Name { get; set; }
    public required string Type { get; set; }
    public int Level { get; set; }
    public string Weakness { get; set; }
    public int Attack {get; set;}
    public int Defense {get; set;}
    public int Speed {get; set;}
}