using ShiftSoftware.ShiftEntity.Core;
using ToDo.Shared.DTOs.Project;

namespace ToDo.API.Data.Entities
{
    [TemporalShiftEntity]
    public class Project : ShiftEntity<Project>
    {
        public string Name { get; set; } = default!;

        public static implicit operator ProjectDTO(Project entity)
        {
            if (entity == null)
                return default!;

            return new ProjectDTO
            {
                CreateDate = entity.CreateDate,
                CreatedByUserID = entity.CreatedByUserID?.ToString(),
                IsDeleted = entity.IsDeleted,
                LastSaveDate = entity.LastSaveDate,
                LastSavedByUserID = entity.LastSavedByUserID?.ToString(),
                ID = entity.ID.ToString(),

                Name = entity.Name,
            };
        }

        public static implicit operator ProjectListDTO(Project entity)
        {
            if (entity == null)
                return default!;

            return new ProjectListDTO
            {
                ID = entity.ID.ToString(),

                Name = entity.Name
            };
        }
    }
}
