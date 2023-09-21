using ShiftSoftware.ShiftEntity.Core;
using ShiftSoftware.ShiftEntity.Model.Replication;
using ToDo.Shared.DTOs.ToDo;
using ToDo.Shared.Enums;

namespace ToDo.Data.Entities;

[TemporalShiftEntity]
[ShiftEntityReplication<ToDoDTO>(ContainerName = "ToDo")]
public class ToDo : ShiftEntity<ToDo>
{
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public ToDoStatus Status { get; set; }

    public long? ProjectID { get; set; }

    public virtual Project? Project { get; set; }
}
