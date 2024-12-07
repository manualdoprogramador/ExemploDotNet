using APIDapper_Customize.DTOs;
using APIDapper_Customize.Helpers;
using Dapper;
using Microsoft.Data.SqlClient;
//using System.Data.SqlClient;


namespace APIDapper_Customize.Repositories
{
    public class PersonRepository : IPersonRepository
    {

        private readonly string _connectionString = string.Empty;
        public PersonRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("SqlServer");
        }

        public async Task<PersonPagedDTO> GetPersonPagedAsync(PersonRequest? request)
        {
            request ??= new PersonRequest();

            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            var count = await connection.QueryFirstOrDefaultAsync<int>(@"SELECT COUNT(1) FROM PESSOACARGA p ");

            var people = await connection.QueryAsync<PersonDTO>(@"SELECT NOME AS [NAME], DOCUMENTO AS [DOCUMENT] FROM PESSOACARGA p 
                                                                  order by nome
                                                                  offset ((@page - 1) * @pageSize) rows
                                                                  fetch next @pageSize rows only;", new { page = request.Page, pageSize = request.PageSize});

            return new PersonPagedDTO
            {
                Data = people,
                TotalLines = count
            };

        }

        public async Task<PagedResultHelper<PersonDTO>> GetPersonPagedCustomizeAsync(PersonRequest? request)
        {
            request ??= new PersonRequest();
            using var connection = new SqlConnection(_connectionString);
            connection.Open();

            return await connection.QueryPagedAsync<PersonDTO>(@"SELECT NOME AS [NAME], DOCUMENTO AS [DOCUMENT] FROM PESSOACARGA p 
                                                                order by nome;
                                                                ", new { page = request.Page, pageSize = request.PageSize });
        }
    }
}
