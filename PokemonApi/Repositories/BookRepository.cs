using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.EntityFrameworkCore;
using PokemonApi.Dtos;
using PokemonApi.Infrastructure;
using PokemonApi.Mappers;
using PokemonApi.Models;

namespace PokemonApi.Repositories;

public class BookRepository: IBookRepository{
    private readonly RelationalDbContext _context;
    public BookRepository(RelationalDbContext context){
        _context=context;
    }
    public async Task<List<Book>>GetByNameAsync(String title, CancellationToken cancellationToken){
        string pattern = $"{title}%";
        var book = await _context.Books.AsNoTracking().Where(s => EF.Functions.Like(s.Title, pattern)).ToListAsync(cancellationToken);
        return book.Select(entity => entity.ToModel()).ToList();
    }
}