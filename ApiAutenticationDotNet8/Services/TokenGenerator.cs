using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApiAutenticationDotNet8.Entities;
using Microsoft.IdentityModel.Tokens;

namespace ApiAutenticationDotNet8.Services
{
    public class TokenGenerator
    {
        public dynamic Generator(User user)
        {
			
			var claims = new List<Claim>
			{
				new Claim("Email", user.Email),
                new Claim("Name", user.Name),
				new Claim("ID", user.Id.ToString())				
			};

			var expires = DateTime.Now.AddDays(1);			
			var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("032E2A36-57CD-46A7-A750-3BA98A59F9BA"));
			var tokenData = new JwtSecurityToken(			
				signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256),
				expires: expires,
				claims: claims				
			);

			var token = new JwtSecurityTokenHandler().WriteToken(tokenData);
			return new
			{
				acess_token = token,
				expiration = expires
			};
        }
    }
}