using PokedexApi.Infrastructure.Grpc;
using PokedexApi.Dtos;
using PokedexApi.Models;

namespace PokedexApi.Mappers;

public static class TrainerMapper
{
    public static TrainerResponseDto ToDto(this Trainer trainer)
    {
        return new TrainerResponseDto
        {
            Id = trainer.Id,
            Name = trainer.Name,
            Age = trainer.Age,
            Birthdate = trainer.Birthdate,
            CreatedAt = trainer.CreatedAt,
            Medals = trainer.Medals.Select(s => new MedalDto
            {
                Region = s.Region,
                Type = s.Type
            }).ToList()
        };
    }

    public static IEnumerable<TrainerResponseDto> ToDto(this IEnumerable<Trainer> trainers)
    {
        return trainers.Select(s => s.ToDto());
    }

    public static Trainer ToModel(this TrainerResponse trainer)
    {
        return new Trainer
        {
            Id = trainer.Id,
            Name = trainer.Name,
            Age = trainer.Age,
            Birthdate = trainer.Birthdate.ToDateTime(),
            CreatedAt = trainer.CreatedAt.ToDateTime(),
            Medals = trainer.Medals.Select(s => new Medal
            {
                Region = s.Region,
                Type = s.Type.ToString()
            }).ToList()
        };
    }

    public static List<Trainer> ToModel(this List<CreateTrainerRequestDto> request)
    {
        return request.Select(s => new Trainer
        {
            Name = s.Name,
            Age = s.Age,
            Birthdate = s.Birthdate,
            Medals = s.Medals.Select(m => new Medal
            {
                Region = m.Region,
                Type = m.Type
            }).ToList()
        }).ToList();
    }

    public static List<Trainer> ToModel(this Google.Protobuf.Collections.RepeatedField<TrainerResponse> trainer)
    {
        return trainer.Select(s => s.ToModel()).ToList();
    }

}