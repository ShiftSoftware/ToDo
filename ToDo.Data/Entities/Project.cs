using ShiftSoftware.ShiftEntity.Core;
using ShiftSoftware.ShiftEntity.Model.Replication;
using ToDo.Shared.DTOs.Project;

namespace ToDo.Data.Entities
{
    [TemporalShiftEntity]
    [ShiftEntityReplication<ProjectDTO>(ContainerName = "Projects")]
    public class Project : ShiftEntity<Project>
    {
        public string Name { get; set; } = default!;
    }
}