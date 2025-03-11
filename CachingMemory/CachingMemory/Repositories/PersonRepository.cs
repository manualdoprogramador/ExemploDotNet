using System.Text.Json;
using CachingMemory.Repositories.Cache.Memory;
using CachingMemory.Repositories.DTOs;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CachingMemory.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly string _connectionString = string.Empty;
    private readonly ICacheMemory _cacheMemory;
    
    public PersonRepository(ICacheMemory cacheMemory, IConfiguration configuration)
    {
        _cacheMemory = cacheMemory;
        _connectionString = configuration.GetConnectionString("SqlServer");
    }
    
    public async Task<IEnumerable<PersonDTO>> GetAllAsync()
    {
        await using var connection = new SqlConnection(_connectionString);
        connection.Open();
        return await connection.QueryAsync<PersonDTO>(@"SELECT NOME AS [Name], Documento AS [Document] FROM PESSOACARGA p");
    }

    public async Task<IEnumerable<PersonDTO>> GetAllWithCachingAsync()
    {
        var key  = "PESSOACARGA";
        IEnumerable<PersonDTO> people = new List<PersonDTO>();
        var json = _cacheMemory.Get(key);
        if (string.IsNullOrEmpty(json))
        {
            await using var connection = new SqlConnection(_connectionString);
            connection.Open();
            people = await connection.QueryAsync<PersonDTO>(@"SELECT NOME AS [Name], Documento AS Document FROM PESSOACARGA p");
           _cacheMemory.Set(key, JsonSerializer.Serialize(people)); 
        }
        else
        {
            people = JsonSerializer.Deserialize<IEnumerable<PersonDTO>>(json);
        }

        return people;
    }
}