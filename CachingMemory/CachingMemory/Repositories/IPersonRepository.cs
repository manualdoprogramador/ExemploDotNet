using CachingMemory.Repositories.DTOs;

namespace CachingMemory.Repositories;

public interface IPersonRepository
{
    Task<IEnumerable<PersonDTO>> GetAllAsync();
    Task<IEnumerable<PersonDTO>> GetAllWithCachingAsync();
}