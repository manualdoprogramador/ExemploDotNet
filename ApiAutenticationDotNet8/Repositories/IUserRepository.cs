using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAutenticationDotNet8.Entities;

namespace ApiAutenticationDotNet8.Repositories
{
    public interface IUserRepository
    {
        User? GetByEmailAndPassword(string email, string password);
    }
}