using Microsoft.AspNetCore.SignalR;

namespace PokedexApi.Dtos;

public class TrainerResponseDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public DateTime Birthdate { get; set; }
    public DateTime CreatedAt { get; set; }
    public IReadOnlyList<MedalDto> Medals { get; set; }
}

public class MedalDto
{
    public string Region { get; set; }
    public string Type { get; set; }
}