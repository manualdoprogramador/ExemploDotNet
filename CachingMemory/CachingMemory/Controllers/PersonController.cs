using CachingMemory.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CachingMemory.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    private readonly IPersonRepository _personRepository;

    public PersonController(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }
    
    [Route("api/people"), HttpGet]
    public async Task<IActionResult> GetPersonAsync()
    {
        var people = await _personRepository.GetAllAsync();
        return Ok(people);
    }
    
    [Route("api/people/cache"), HttpGet]
    public async Task<IActionResult> GetAllWithCachingAsync()
    {
        var people = await _personRepository.GetAllWithCachingAsync();
        return Ok(people);
    }
}