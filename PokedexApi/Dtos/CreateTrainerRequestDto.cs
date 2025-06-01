namespace PokedexApi.Dtos;

public class CreateTrainerRequestDto
{
    public string Name { get; set; }
    public int Age { get; set; }
    public DateTime Birthdate { get; set; }
    public IList<MedalDto> Medals { get; set; }

}