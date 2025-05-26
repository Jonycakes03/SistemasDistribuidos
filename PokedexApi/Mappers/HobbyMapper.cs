using PokedexApi.Dtos;
using PokedexApi.Infrastructure.Soap.Dtos;
using PokedexApi.Models;

namespace PokedexApi.Mappers;

public static class HobbyMapper
{
    public static HobbyResponse ToDto(this Hobby hobby){
        return new HobbyResponse{
            Id = hobby.Id,
            Name = hobby.Name,
            Top = hobby.Top 
        };
    }

    public static Hobby ToModel(this HobbiesResponseDto hobbyResponseDto){
        return new Hobby{
            Id = hobbyResponseDto.Id,
            Name = hobbyResponseDto.Name,
            Top = hobbyResponseDto.Top
    };

    }
    

}