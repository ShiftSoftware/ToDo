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
                    opt => opt.MapFrom(src => src.ProjectID == null ? null : new ShiftEntitySelectDTO { Value = src.ProjectID.ToString()!, Text = null })
                );

        CreateMap<ToDoDTO, Entities.ToDo>()
            .ForMember(dest => dest.Project, opt => opt.Ignore())
            .ForMember(
                    dest => dest.ProjectID,
                    opt => opt.MapFrom(src => src.Project == null ? new Nullable<long>() : src.Project.Value.ToLong())
                );

        CreateMap<Entities.ToDo, ToDoListDTO>()
            .ForMember(
                    dest => dest.Project,
                    opt => opt.MapFrom(src => src.Project == null ? null : src.Project.Name)
                );
    }
}