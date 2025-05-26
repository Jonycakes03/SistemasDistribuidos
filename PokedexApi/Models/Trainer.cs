namespace PokedexApi.Models;

public class Trainer
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public DateTime Birthdate { get; set; }
    public DateTime CreatedAt { get; set; }
    public IReadOnlyList<Medal> Medals { get; set; }
}

public class Medal
{
    public string Region { get; set; }
    public string Type { get; set; }
}
