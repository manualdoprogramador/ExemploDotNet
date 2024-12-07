using APIDapper_Customize.DTOs;
using APIDapper_Customize.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIDapper_Customize.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }


        // GET
        [Route("api/people/paged"), HttpGet]
        public async Task<IActionResult> GetPersonPagedAsync([FromQuery] PersonRequest? request)
        {
            var people = await _personRepository.GetPersonPagedAsync(request);
            return Ok(people);
        }

        [Route("api/people/paged/customize"), HttpGet]
        public async Task<IActionResult> GetPersonPagedCustomizeAsync([FromQuery] PersonRequest? request)
        {
            var people = await _personRepository.GetPersonPagedCustomizeAsync(request);
            return Ok(people);
        }
    }
}
