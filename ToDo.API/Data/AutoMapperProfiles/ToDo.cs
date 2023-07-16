using AutoMapper;
using ToDo.Shared.DTOs.ToDo;
using ShiftSoftware.ShiftEntity.Model.Dtos;

namespace ToDo.API.Data.AutoMapperProfiles;

public class ToDoProfile : Profile
{
    public ToDoProfile()
    {
        CreateMap<Entities.ToDo, ToDoDTO>()
            .ForMember(
                    dest => dest.Project,
                    opt => opt.MapFrom(src => src.Project == null ? null : new ShiftEntitySelectDTO { Value = src.ProjectID.ToString()!, Text = src.Project!.Name })
                );

        CreateMap<Entities.ToDo, ToDoListDTO>()
            .ForMember(
                    dest => dest.Project,
                    opt => opt.MapFrom(src => src.Project == null ? null : src.Project.Name)
                );
    }
}