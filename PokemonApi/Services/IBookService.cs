using System.ServiceModel;

using PokemonApi.Dtos;

namespace PokemonApi.Services;

[ServiceContract(Name = "BookService", Namespace ="http://pokemon-api/books-service")]


public interface IBookService
{
    
    [OperationContract]
    Task<List<BooksResponseDto>>GetBookByName(String title, CancellationToken cancellationToken);
}