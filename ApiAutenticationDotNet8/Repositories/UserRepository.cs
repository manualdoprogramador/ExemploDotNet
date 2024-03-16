using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAutenticationDotNet8.Entities;
using Dapper;

namespace ApiAutenticationDotNet8.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnectionFactory _db;

        public UserRepository(IDbConnectionFactory db)
        {
            _db = db;
        }

        public User? GetByEmailAndPassword(string email, string password)
        {
            using var connection = _db.GetDbConnection();
            var result = connection.QueryFirstOrDefault<User?>("SELECT nome as name, email, idusuario as id from usuario where email = @email and senha = @password", new {email, password});
            return result;
        }
    }
}