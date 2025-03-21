using PokedexApi.Dtos;
using PokedexApi.Infrastrucure.Soap.Dtos;
using PokedexApi.Models;

namespace PokedexApi.Mappers;

public static class PokemonMapper
{
    public static PokemonResponse ToDto(this Pokemon pokemon){
        return new PokemonResponse{
            Id = pokemon.Id,
            Name = pokemon.Name,
            Type = pokemon.Type,
            Level = pokemon.Level,
            Stats = new StatsResponse{
                Attack = pokemon.Attack,
                Defense = pokemon.Defense,
                Speed = pokemon.Speed
            }
        };
    }

    public static Pokemon ToModel(this PokemonResponseDto pokemonResponseDto){
        return new Pokemon{
            Id = pokemonResponseDto.Id,
            Name = pokemonResponseDto.Name,
            Type = pokemonResponseDto.Type,
            Level = pokemonResponseDto.Level,
            Attack = pokemonResponseDto.Stats.Attack,
            Defense = pokemonResponseDto.Stats.Defense,
            Speed = pokemonResponseDto.Stats.Speed
        };
    }
    

}