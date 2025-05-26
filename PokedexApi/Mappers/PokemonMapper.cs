using Microsoft.AspNetCore.Authorization.Infrastructure;
using PokedexApi.Dtos;
using PokedexApi.Infrastructure.Soap.Dtos;
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
            Weakness = pokemon.Weakness,
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
            Weakness = pokemonResponseDto.Weakness,
            Attack = pokemonResponseDto.Stats.Attack,
            Defense = pokemonResponseDto.Stats.Defense,
            Speed = pokemonResponseDto.Stats.Speed
        };
    }

    public static Pokemon ToModel(this CreatePokemonRequest pokemon){
        return new Pokemon{
            Name = pokemon.Name,
            Type = pokemon.Type,
            Level = pokemon.Level,
            Weakness = pokemon.Weakness,
            Attack = pokemon.Attack,
            Defense = pokemon.Defense,
            Speed = pokemon.Speed
        };
    }

    public static CreatePokemonDto ToSoapDto(this Pokemon pokemon){
        return new CreatePokemonDto{
            Name = pokemon.Name,
            Type = pokemon.Type,
            Level = pokemon.Level,
            Weakness = pokemon.Weakness,
            Stats = new StatsDto{
                Attack = pokemon.Attack,
                Defense = pokemon.Defense,
                Speed = pokemon.Speed
            }
        };

    }

    public static Pokemon ToModel(this UpdatePokemonRequest pokemon){
        return new Pokemon{
            Name = pokemon.Name,
            Type = pokemon.Type,
            Level = pokemon.Level,
            Weakness = pokemon.Weakness,
            Attack = pokemon.Attack,
            Defense = pokemon.Defense,
            Speed = pokemon.Speed
        };
    }

    public static UpdatePokemonDto ToUpdateSoapDto(this Pokemon pokemon){
        return new UpdatePokemonDto{
            Id = pokemon.Id,
            Name = pokemon.Name,
            Type = pokemon.Type,
            Level = pokemon.Level,
            Weakness = pokemon.Weakness,
            Stats = new StatsDto{
                Attack = pokemon.Attack,
                Defense = pokemon.Defense,
                Speed = pokemon.Speed
            }
        };
    }
    

}