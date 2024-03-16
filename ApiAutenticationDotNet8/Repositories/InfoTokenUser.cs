using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAutenticationDotNet8.Repositories
{
    public class InfoTokenUser : IInfoTokenUser
    {
        public InfoTokenUser(IHttpContextAccessor httpContextAccessor)
        {
            var httpContext = httpContextAccessor.HttpContext;
            var claims = httpContext.User.Claims;

            if (claims.Any(c => c.Type == "ID"))
            {
                var id = Convert.ToInt32(claims.First(c => c.Type == "ID").Value);
                Id = id;
            }

            if (claims.Any(c => c.Type == "Email"))
                Email = claims.First(c => c.Type == "Email").Value;

            if (claims.Any(c => c.Type == "Name"))
                Name = claims.First(c => c.Type == "Name").Value;

            
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Email { get; set; }
        
    }
}