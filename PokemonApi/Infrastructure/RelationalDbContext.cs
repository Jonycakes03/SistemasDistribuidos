using PokemonApi.Infrastructure;
using Microsoft.EntityFrameworkCore;
using PokemonApi.Infrastructure.Entities;

namespace PokemonApi.Infrastructure;

public class RelationalDbContext : DbContext
{
    public DbSet<BookEntity> Books {get; set;}
    public DbSet<PokemonEntity> Pokemons {get; set;}
    public DbSet<HobbyEntity> Hobbies {get; set;}
    

    

    public RelationalDbContext(DbContextOptions<RelationalDbContext> options) : base(options){

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PokemonEntity>(entity => {
            entity.HasKey(s => s.Id);
            entity.Property(s => s.Name).IsRequired().HasMaxLength(100);
            entity.Property(s=> s.Type).IsRequired().HasMaxLength(50);
            entity.Property(s=> s.Level).IsRequired();
            entity.Property(s=> s.Weakness).IsRequired();
            entity.Property(s=> s.Attack).IsRequired();
            entity.Property(s=> s.Defense).IsRequired();
            entity.Property(s=> s.Speed).IsRequired();
            

        });

         modelBuilder.Entity<HobbyEntity>(entity => {
            entity.HasKey(s => s.Id);
            entity.Property(s => s.Name).IsRequired().HasMaxLength(100);
            entity.Property(s=> s.Top).IsRequired();
            

        });

         modelBuilder.Entity<BookEntity>(entity => {
            entity.HasKey(s => s.Id);
            entity.Property(s => s.Title).IsRequired().HasMaxLength(100);
            entity.Property(s=> s.Author).IsRequired();
            entity.Property(s=> s.PublishedDate).IsRequired();

            

        });


    }
}
    