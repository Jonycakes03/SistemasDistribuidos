using System.ServiceModel;
using PokemonApi.Models;

namespace PokemonApi.Validators;

public static class HobbyValidator {
    public static Hobby ValidateName(this Hobby hobby) =>
        string.IsNullOrEmpty(hobby.Name) ? 
        throw new FaultException("hobby name is required") : hobby;

    public static Hobby ValidateTop(this Hobby hobby) =>
    hobby == null ? throw new ArgumentNullException(nameof(hobby), "Hobby instance cannot be null") :
    hobby.Top == 0 ? throw new FaultException("hobby Top is required") : hobby;


   
}