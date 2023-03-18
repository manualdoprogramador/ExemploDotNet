using System;
using System.Data;
using System.Data.SqlClient;

namespace BulkInsertSqlServer
{
    public class SqlServerConnection
    {
        private readonly string _connectionString ;
        public SqlServerConnection()
        {
            _connectionString = "Server=192.168.100.117;Database=Curso_Clean_Architecture;User ID=sa;Password=admin123;";
        }

        public SqlConnection GetConnection()
        {
            var connection= new SqlConnection(_connectionString);
            connection.Open();
            if (connection.State == ConnectionState.Closed)
                connection.Open();
            return connection;
        }
    }
}

