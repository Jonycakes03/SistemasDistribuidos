using Microsoft.AspNetCore.DataProtection.KeyManagement.Internal;
using Microsoft.EntityFrameworkCore;
using PokemonApi.Dtos;
using PokemonApi.Infrastructure;
using PokemonApi.Mappers;
using PokemonApi.Models;

namespace PokemonApi.Repositories;

public class HobbiesRepository: IHobbiesRepository{
    private readonly RelationalDbContext _context;
    public HobbiesRepository(RelationalDbContext context){
        _context=context;
    }
    public async Task<Hobby> GetByIdAsync(Guid id, CancellationToken cancellationToken){
        var hobby = await _context.Hobbies.AsNoTracking().FirstOrDefaultAsync(s=> s.Id == id, cancellationToken);
        return hobby.ToModel();
    }

    public async Task DeleteAsync(Hobby hobby, CancellationToken cancellationToken){
        _context.Hobbies.Remove(hobby.ToEntity());
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task AddAsync(Hobby hobby, CancellationToken cancellationToken){
        await _context.Hobbies.AddAsync(hobby.ToEntity(), cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Hobby>>GetByNameAsync(String name, CancellationToken cancellationToken){
        string pattern = $"{name}%";
        var hobby = await _context.Hobbies.AsNoTracking().Where(s => EF.Functions.Like(s.Name, pattern)).ToListAsync(cancellationToken);
        return hobby.Select(entity => entity.ToModel()).ToList();
    }
}