using AutoMapper;
using ShiftSoftware.ShiftEntity.Model.Dtos;
using System.Text.Json;
using ToDo.Shared.DTOs.Task;

namespace ToDo.Data.AutoMapperProfiles;

public class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<Entities.Task, TaskDTO>()
            .ForMember(
                    dest => dest.Files,
                    opt => opt.MapFrom(src => serializer<List<ShiftFileDTO>>(src.Files))
                )
            .ForMember(
                    dest => dest.AssignedTo,
                    opt => opt.MapFrom(src => src.AssignedToId == null ? null : new ShiftEntitySelectDTO { Value = src.AssignedToId.ToString()!, Text = null })
                );

        CreateMap<TaskDTO, Entities.Task>()
            .ForMember(
                dest => dest.Files,
                opt => opt.MapFrom(src => JsonSerializer.Serialize(src.Files, new JsonSerializerOptions()))
            )
            .ForMember(
                dest => dest.AssignedToId,
                opt => opt.MapFrom(src => src.AssignedTo == null ? new long?() : src.AssignedTo.Value.ToLong())
            );

        CreateMap<Entities.Task, TaskListDTO>();
    }

    private T serializer<T>(string? text) where T : class, new()
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return new T();
        }

        return JsonSerializer.Deserialize<T>(text) ?? new T();
    }
}