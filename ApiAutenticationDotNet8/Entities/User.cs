using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAutenticationDotNet8.Entities
{
    public class User
    {
        private User(){}
        public User(string name, string email, string password, int id = 0)
        {
            if(id > 0)
                Id = id;

            Name = name;
            Email = email;
            Password = password;
        }

        public int Id  { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
    }
}