namespace PokedexApi.Exceptions;

public class NameValidationException : Exception{
    public NameValidationException(string message) : base(message){
        
    }
}