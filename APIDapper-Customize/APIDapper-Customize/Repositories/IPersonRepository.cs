using APIDapper_Customize.DTOs;
using APIDapper_Customize.Helpers;

namespace APIDapper_Customize.Repositories
{
    public interface IPersonRepository
    {
        Task<PersonPagedDTO> GetPersonPagedAsync(PersonRequest? request);

        Task<PagedResultHelper<PersonDTO>> GetPersonPagedCustomizeAsync(PersonRequest? request);
    }
}
