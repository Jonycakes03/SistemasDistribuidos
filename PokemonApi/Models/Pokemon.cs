using Microsoft.EntityFrameworkCore.Diagnostics;
using Org.BouncyCastle.Asn1.Mozilla;
using PokemonApi.Dtos;

namespace PokemonApi.Models;

public class Pokemon{
    public Guid Id{get; set;}
    public String Name {get; set;}
    public String Type{get; set;}
    public int Level {get; set;}
    public String Weakness{get; set;}
    public Stats Stats{get; set;}
}