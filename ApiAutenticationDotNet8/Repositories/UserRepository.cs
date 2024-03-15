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
            var result = connection.QueryFirstOrDefault<User?>("select * from usuario");
            var users = GetUsers();
            return users.FirstOrDefault(x => x.Email == email && x.Password == password);
        }

        private List<User> GetUsers()
        {
            var users = new List<User>();
            users.Add(new User("Maria", "maria@maria.com", "maria123",1));
            users.Add(new User("Paulo", "paulo@paulo.com", "paulo123",1));
            users.Add(new User("Carlos", "carlos@carlos.com", "carlos123",1));
            return users;
        }
    }
}