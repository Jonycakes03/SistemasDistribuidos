using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.EntityFrameworkCore;
using PokemonApi.Infrastructure;
using PokemonApi.Mappers;
using PokemonApi.Models;

namespace PokemonApi.Repositories;

public class PokemonRepository: IPokemonRepository{
    private readonly RelationalDbContext _context;
    public PokemonRepository(RelationalDbContext context){
        _context=context;
    }
    public async Task<Pokemon> GetByIdAsync(Guid id, CancellationToken cancellationToken){
        var pokemon = await _context.Pokemons.AsNoTracking().FirstOrDefaultAsync(s=> s.Id == id, cancellationToken);
        return pokemon.ToModel();
    }
}