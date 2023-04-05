using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MP.ApiRedis.Controllers
{
    [Route("api/[controller]")]
    public class TestRedisController : ControllerBase
    {
        private IDistributedCache _distributedCache;

        public TestRedisController(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        [HttpGet("{document}")]
        public IActionResult Get(string document)
        {
            var json = _distributedCache.GetString(document);
            Person person;
            if (string.IsNullOrEmpty(json))
            {
                DistributedCacheEntryOptions distributedCacheEntryOptions = new DistributedCacheEntryOptions();
                distributedCacheEntryOptions.SetAbsoluteExpiration(TimeSpan.FromSeconds(120));
                distributedCacheEntryOptions.SetSlidingExpiration(TimeSpan.FromSeconds(30));
                var people = new PersonRepository().GetPeople();
                person = people.FirstOrDefault(x => x.Document == document);
                json = JsonSerializer.Serialize(person);
                _distributedCache.SetString(person.Document, json,distributedCacheEntryOptions);
            }
            else
            {
                person = JsonSerializer.Deserialize<Person>(json);
            }

            return Ok(person);
        }

    }
}

