using Microsoft.EntityFrameworkCore.Storage.Json;
using PokemonApi.Dtos;
using PokemonApi.Infrastructure.Entities;
using PokemonApi.Models;

namespace PokemonApi.Mappers;

public static class HobbyMapper{
    public static HobbyEntity ToEntity(this Hobby hobby){
        return new HobbyEntity{
            Id= hobby.Id,
            Name = hobby.Name,
            Top = hobby.Top
        };
    }
    public static Hobby ToModel(this HobbyEntity entity){
        if (entity is null){
            return null;
        }
        return new Hobby{
            Id= entity.Id,
            Name = entity.Name,
            Top = entity.Top
                
            };
        }

    public static HobbiesResponseDto ToDto(this Hobby hobby){
        if (hobby is null){
            return null;
        }
        return new HobbiesResponseDto{
            Id = hobby.Id,
            Name = hobby.Name,
            Top = hobby.Top
                
            };
        
    }

    public static List<HobbiesResponseDto> ToDtoList(this List<HobbyEntity> entities)
    {
        if (entities == null) throw new ArgumentNullException(nameof(entities));

        return entities.Select(entity => ToDto(ToModel(entity))).ToList();
    }
    
    public static Hobby ToModel(this CreateHobbiesDto hobby){
        return new Hobby{
            Id = Guid.NewGuid(),
            Name = hobby.Name,
            Top = hobby.Top
           
        };
    }

    
}
