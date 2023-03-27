using ShiftSoftware.ShiftEntity.Core;
using ToDo.Shared.DTOs.ToDo;
using ToDo.Shared.Enums;

namespace ToDo.API.Data.Entities;

[TemporalShiftEntity]
public class ToDo : ShiftEntity<ToDo>
{
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public ToDoStatus Status { get; set; }


    public static implicit operator ToDoDTO(ToDo entity)
    {
        if (entity == null)
            return default!;

        return new ToDoDTO {
            CreateDate = entity.CreateDate,
            CreatedByUserID = entity.CreatedByUserID,
            IsDeleted = entity.IsDeleted,
            LastSaveDate = entity.LastSaveDate,
            LastSavedByUserID = entity.LastSavedByUserID,
            ID = entity.ID,

            Description = entity.Description,
            Status = entity.Status,
            Title = entity.Title,
        };
    }

    public static implicit operator ToDoListDTO(ToDo entity)
    {
        if (entity == null)
            return default!;

        return new ToDoListDTO
        {
            ID = entity.ID,

            Description = entity.Description,
            Status = entity.Status,
            Title = entity.Title,
        };
    }
}
