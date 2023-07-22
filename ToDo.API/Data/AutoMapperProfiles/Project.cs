using AutoMapper;
using ToDo.API.Data.Entities;
using ToDo.Shared.DTOs.Project;

namespace ToDo.API.Data.AutoMapperProfiles;

public class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<Project, ProjectDTO>().ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
        CreateMap<Project, ProjectListDTO>();
    }
}