using Microsoft.EntityFrameworkCore.Diagnostics;
using Org.BouncyCastle.Asn1.Mozilla;
using PokemonApi.Dtos;

namespace PokemonApi.Models;

public class Book{
    public Guid Id{get; set;}
    public String Title {get; set;}
    public String Author {get; set;}

    public DateTime PublishedDate {get; set;}
}