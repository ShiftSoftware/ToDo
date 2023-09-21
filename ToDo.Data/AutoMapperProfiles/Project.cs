using AutoMapper;
using ToDo.Data.Entities;
using ToDo.Shared.DTOs.Project;

namespace ToDo.Data.AutoMapperProfiles;

public class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<Project, ProjectDTO>().ReverseMap().IgnoreAllPropertiesWithAnInaccessibleSetter();
        CreateMap<Project, ProjectListDTO>();
    }
}