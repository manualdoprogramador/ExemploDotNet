using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace ApiAutenticationDotNet8.Repositories
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IDbConnection connection;
        public DbConnectionFactory(IConfiguration configuration)
        {
            connection = new NpgsqlConnection(configuration.GetConnectionString("DefaultConnection"));
        }

        public void Dispose()
        {
           connection?.Dispose();
        }

        public IDbConnection GetDbConnection()
        {
            if(connection.State != ConnectionState.Open)
                connection.Open();

             return connection;   
        }
    }
}