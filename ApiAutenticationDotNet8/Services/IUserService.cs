using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAutenticationDotNet8.Services
{
    public interface IUserService
    {
        dynamic GenerateToken(string email, string password);
    }
}