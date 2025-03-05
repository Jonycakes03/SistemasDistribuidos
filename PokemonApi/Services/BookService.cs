using System.Formats.Asn1;
using System.ServiceModel;
using PokemonApi.Dtos;
using PokemonApi.Mappers;
using PokemonApi.Repositories;

namespace PokemonApi.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    public BookService(IBookRepository bookRepository){
        _bookRepository = bookRepository;
    }

    public async Task<List<BooksResponseDto>>GetBookByName(String title, CancellationToken cancellationToken){
        var book = await _bookRepository.GetByNameAsync(title, cancellationToken);
        if (book is null || book.Count == 0){
            return new List<BooksResponseDto>();
        }
        return book.Select(book => book.ToDto()).ToList();
    }
}