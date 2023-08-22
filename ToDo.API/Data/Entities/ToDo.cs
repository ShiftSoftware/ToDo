using ShiftSoftware.ShiftEntity.Core;
using ShiftSoftware.ShiftEntity.CosmosDbSync;
using ToDo.Shared.DTOs.Project;
using ToDo.Shared.DTOs.ToDo;
using ToDo.Shared.Enums;

namespace ToDo.API.Data.Entities;

[TemporalShiftEntity]
[ShiftEntitySync<ToDoDTO>(ContainerName = "ToDo")]
public class ToDo : ShiftEntity<ToDo>
{
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public ToDoStatus Status { get; set; }

    public long? ProjectID { get; set; }

    public virtual Project? Project { get; set; }
}
