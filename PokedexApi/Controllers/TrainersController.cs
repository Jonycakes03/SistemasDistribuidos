using System.CodeDom;
using System.Drawing;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using PokedexApi.Dtos;
using PokedexApi.Exceptions;
using PokedexApi.Mappers;
using PokedexApi.Models;
using PokedexApi.Services;

namespace PokedexApi.Controllers;

[ApiController]
[Microsoft.AspNetCore.Mvc.Route("api/v1/[controller]")] //versionar por ruta o por metadata  

public class TrainersController : ControllerBase
{
    private readonly ITrainerService _trainerService;

    public TrainersController(ITrainerService trainerService)
    {
        _trainerService = trainerService;
    }
    [HttpGet("{id}")]
    public async Task<ActionResult<TrainerResponseDto>> GetTrainerByIdAsync(string id, CancellationToken cancellationToken)
    {
        var trainer = await _trainerService.GetTrainerByIdAsync(id, cancellationToken);
        if (trainer is null)
        {
            return NotFound();
        }
        return Ok(trainer.ToDto());
    }
    //api/v1/trainers?name=Ash
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TrainerResponseDto>>> GetAllTrainersAsync([FromQuery] string name, CancellationToken cancellationToken)
    {
        try
        {
            var trainers = await _trainerService.GetAllByNameAsync(name, cancellationToken);
            return Ok(trainers.ToDto());

        }
        catch (TrainerValidationException ex)
        {
            return BadRequest(new { message = ex.Message });
        }

    }

    [HttpPost]
    public async Task<ActionResult<TrainerResponseDto>> CreateTrainerAsync([FromBody] List<CreateTrainerRequestDto> request, CancellationToken cancellationToken)
    {
        var trainers = request.ToModel();
        var (createdTrainers, successCount) = await _trainerService.CreateTrainerAsync(trainers, cancellationToken);
        return Ok(new { SuccessCount = successCount, CreatedTrainers = createdTrainers });
    }

}