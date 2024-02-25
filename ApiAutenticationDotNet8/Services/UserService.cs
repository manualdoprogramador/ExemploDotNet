using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAutenticationDotNet8.Repositories;

namespace ApiAutenticationDotNet8.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public dynamic GenerateToken(string email, string password)
        {
            var user = _userRepository.GetByEmailAndPassword(email, password);
            if (user == null)
            {
                return new
                {
                    message = "Usuario ou senha inválidos!"
                };
            }
            return new TokenGenerator().Generator(user);
        }
    }
}