using AutoMapper.Dto;
using AutoMapper.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AutoMapper.Controller;


public class PersonController : ControllerBase
{
    private readonly IMapper _mapper;

    public PersonController(IMapper mapper)
    {
        _mapper = mapper;
    }

    // GET
    [Route("api/person"), HttpGet]
    public IActionResult Get()
    {
        var person = GetPerson();
        var dto = _mapper.Map<PersonDTO>(person);
        return Ok(dto); 
    }

    private Person GetPerson()
    {
        return new Person()
        {
            Id = 1,
            Name = "Maria",
            Phone = "99999999"
        };
    }
    
    // GET
    [Route("api/people"), HttpGet]
    public IActionResult GetAll()
    {
        var people = GetPeople();
        var dto = _mapper.Map<List<PersonDTO>>(people);
        return Ok(dto); 
    }

    private List<Person> GetPeople()
    {
        return new List<Person>()
        {
            new Person()
            {
                Id = 1,
                Name = "Maria",
                Phone = "99999999"
            },
            new Person()
            {
                Id = 2,
                Name = "Paulo",
                Phone = "7777777"
            }
        };
    }
}