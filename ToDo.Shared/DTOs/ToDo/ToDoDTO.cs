using ShiftSoftware.ShiftEntity.Model.Dtos;
using System.Text.Json.Serialization;
using ToDo.Shared.Enums;

namespace ToDo.Shared.DTOs.ToDo;

public class ToDoDTO : ShiftEntityDTO
{
    [_ToDoHashId]
    public override string? ID { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ToDoStatus Status { get; set; }

    public ShiftEntitySelectDTO? Project { get; set; }
}
