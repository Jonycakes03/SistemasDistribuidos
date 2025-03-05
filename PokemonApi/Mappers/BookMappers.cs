using Microsoft.EntityFrameworkCore.Storage.Json;
using PokemonApi.Dtos;
using PokemonApi.Infrastructure.Entities;
using PokemonApi.Models;

namespace PokemonApi.Mappers;

public static class BookMapper{
    public static BookEntity ToEntity(this Book book){
        return new BookEntity{
            Id= book.Id,
            Title = book.Title,
            Author = book.Author,
            PublishedDate = book.PublishedDate
        };
    }
    public static Book ToModel(this BookEntity entity){
        if (entity is null){
            return null;
        }
        return new Book{
            Id= entity.Id,
            Title = entity.Title,
            Author = entity.Author,
            PublishedDate = entity.PublishedDate
                
            };
        }

    public static BooksResponseDto ToDto(this Book book){
        if (book is null){
            return null;
        }
        return new BooksResponseDto{
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            PublishedDate = book.PublishedDate
                
            };
        
    }
/*
    public static List<HobbiesResponseDto> ToDtoList(this List<HobbyEntity> entities)
    {
        if (entities == null) throw new ArgumentNullException(nameof(entities));

        return entities.Select(entity => ToDto(ToModel(entity))).ToList();
    }
    */
}
