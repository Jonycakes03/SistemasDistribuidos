namespace PokedexApi.Exceptions;

public class PokemonNotFoundException : Exception
{
    public PokemonNotFoundException(string message) : base(message){
        
    }
}