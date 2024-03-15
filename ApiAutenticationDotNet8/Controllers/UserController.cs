using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAutenticationDotNet8.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiAutenticationDotNet8.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("token")]
        public ActionResult GenerateToken([FromForm] string email, [FromForm] string password)
        {
            var result =  _userService.GenerateToken(email, password);
            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        [Route("autenticado")]
        public ActionResult GetAuthenticated([FromForm] string email, [FromForm] string password)
        {
            
            return Ok("Autenticacao validada");
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("naoautenticado")]
        public ActionResult GetNotAuthenticated([FromForm] string email, [FromForm] string password)
        {
            
            return Ok("Não precisa de autenticação");
        }
    }
}