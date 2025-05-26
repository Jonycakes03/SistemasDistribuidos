using Grpc.Net.Client;
using PokedexApi.Infrastructure.Grpc;
using PokedexApi.Repositories;
using PokedexApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IPokemonService, PokemonService>();
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
builder.Services.AddScoped<IHobbiesService, HobbiesService>();
builder.Services.AddScoped<IHobbiesRepository, HobbiesRepository>();
builder.Services.AddScoped<ITrainerRepository, TrainerRepository>();
builder.Services.AddScoped<ITrainerService, PokedexApi.Services.TrainerService>();
builder.Services.AddSingleton(s =>
{
    var channel = GrpcChannel.ForAddress(builder.Configuration.GetValue<string>("TrainersApiUrl")!);

    return new PokedexApi.Infrastructure.Grpc.TrainerService.TrainerServiceClient(channel);
});


var app = builder.Build();

if (app.Environment.IsDevelopment()){
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();