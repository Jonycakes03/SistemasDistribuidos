using Microsoft.EntityFrameworkCore.Diagnostics;
using Org.BouncyCastle.Asn1.Mozilla;
using PokemonApi.Dtos;

namespace PokemonApi.Models;

public class Hobby{
    public Guid Id{get; set;}
    public String Name {get; set;}
    public int Top {get; set;}
}