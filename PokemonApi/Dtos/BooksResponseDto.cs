namespace PokemonApi.Dtos;

public class BooksResponseDto
{
    public Guid Id {get; set;}
    public string Title {get; set;}
    public string Author {get; set;}

    public DateTime PublishedDate {get; set;}

}