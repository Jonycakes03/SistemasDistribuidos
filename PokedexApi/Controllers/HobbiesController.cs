using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PokedexApi.Services;
using PokedexApi.Mappers;
using PokedexApi.Dtos;

namespace PokedexApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")] //versionar por pruta o por metadata
public class HobbiesController: ControllerBase 
{
    private readonly IHobbiesService _hobbiesService;
    public HobbiesController(IHobbiesService hobbiesService)
    {
        _hobbiesService = hobbiesService;
    }
    //lcoalhost/api/v1/hobbies
    [HttpGet("{id}")]
    public async Task<ActionResult<HobbyResponse>> GetHobbyByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var hobby = await _hobbiesService.GetHobbyByIdAsync(id, cancellationToken);
        if (hobby is null){
            return NotFound();
        }
        return Ok(hobby.ToDto());

    }

    [HttpGet("name/{name}")]
    public async Task<ActionResult<List<HobbyResponse>>> GetHobbyByNameAsync(String name, CancellationToken cancellationToken)
    {
    var hobby = await _hobbiesService.GetHobbyByNameAsync(name, cancellationToken);
    if (hobby == null || !hobby.Any()) // Verifica si la lista está vacía o es null
    {
        return NotFound();
    }

    return Ok(hobby.Select(p => p.ToDto()).ToList());
}


}

