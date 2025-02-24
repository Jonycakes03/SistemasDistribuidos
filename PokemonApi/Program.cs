<<<<<<< HEAD
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
=======
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using PokemonApi.Infrastructure;
using PokemonApi.Repositories;
using PokemonApi.Services;
using SoapCore;

var Builder = WebApplication.CreateBuilder(args);
Builder.Services.AddSoapCore();


Builder.Services.AddScoped<IPokemonService, PokemonService>();
Builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();

Builder.Services.AddDbContext<RelationalDbContext>(options => options.UseMySql(Builder.Configuration.GetConnectionString("DefaultConnection"), 
ServerVersion.AutoDetect(Builder.Configuration.GetConnectionString("DefaultConnection"))));

//Builder.Services.AddTransient<>();
//Builder.Services.AddSingleton<>();

var app = Builder.Build();

app.UseSoapEndpoint<IPokemonService>("/pokemonService.svc",new SoapEncoderOptions());

app.Run();
>>>>>>> 0c6924dcc0b388388b090422146ae7816a619670
