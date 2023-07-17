using ShiftSoftware.ShiftEntity.Core;
using ShiftSoftware.ShiftEntity.Model.Dtos;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using ToDo.Shared.DTOs.Task;
using ToDo.Shared.Enums;

namespace ToDo.API.Data.Entities;

[TemporalShiftEntity]
public class Task : ShiftEntity<Task>
{
    public string Name { get; set; } = default!;
    public string Description { get; set; } = string.Empty;
    public _TaskStatus Status { get; set; }
    public DateTime? DueDate { get; set; }
    public long? ParentTaskId { get; set; }
    public string? Files { get; set; }

    [ForeignKey("ParentTaskId")]
    public virtual Task? ParentTask { get; set; }
    [InverseProperty("ParentTask")]
    public virtual ICollection<Task>? ChildTasks { get; set; }

    public static implicit operator TaskDTO(Task entity)
    {
        if (entity == null)
            return default!;

        var dto = new TaskDTO
        {
            CreateDate = entity.CreateDate,
            CreatedByUserID = entity.CreatedByUserID?.ToString(),
            IsDeleted = entity.IsDeleted,
            LastSaveDate = entity.LastSaveDate,
            LastSavedByUserID = entity.LastSavedByUserID?.ToString(),
            ID = entity.ID.ToString(),

            Description = entity.Description,
            Status = entity.Status,
            Name = entity.Name,
            DueDate = entity.DueDate,
        };

        if (!string.IsNullOrWhiteSpace(entity.Files))
        {
            dto.Files = JsonSerializer.Deserialize<List<ShiftFileDTO>>(entity.Files) ?? new();
        }


        return dto;
    }

    public static implicit operator TaskListDTO(Task entity)
    {
        if (entity == null)
            return default!;

        return new TaskListDTO
        {
            ID = entity.ID.ToString(),
            Status = entity.Status,
            Name = entity.Name,
            ParentTaskId = entity.ParentTaskId?.ToString(),
        };
    }
}
