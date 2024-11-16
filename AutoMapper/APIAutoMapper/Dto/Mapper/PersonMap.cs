using AutoMapper.Entities;

namespace AutoMapper.Dto.Mapper;

public class PersonMap : Profile
{
    public PersonMap()
    {
        CreateMap<Person, PersonDTO>();
    }
}