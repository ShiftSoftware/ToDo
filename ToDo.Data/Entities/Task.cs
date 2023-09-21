using ShiftSoftware.ShiftEntity.Core;
using ShiftSoftware.ShiftEntity.Model.Dtos;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using ToDo.Shared.DTOs.Task;
using ToDo.Shared.Enums;

namespace ToDo.Data.Entities;

[TemporalShiftEntity]
public class Task : ShiftEntity<Task>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = string.Empty;
    public _TaskStatus Status { get; set; }
    public DateTime? DueDate { get; set; }
    public long? ParentTaskId { get; set; }
    public string? Files { get; set; }
    public long? AssignedToId { get; set; }

    [ForeignKey("ParentTaskId")]
    public virtual Task? ParentTask { get; set; }
    [InverseProperty("ParentTask")]
    public virtual ICollection<Task>? ChildTasks { get; set; }
}
