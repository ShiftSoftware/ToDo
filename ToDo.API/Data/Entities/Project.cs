using ShiftSoftware.ShiftEntity.Core;
using ShiftSoftware.ShiftEntity.CosmosDbSync;
using ToDo.Shared.DTOs.Project;

namespace ToDo.API.Data.Entities
{
    [TemporalShiftEntity]
    [ShiftEntitySync(CosmosDbItemType = typeof(ProjectDTO),ContainerName = "Projects")]
    public class Project : ShiftEntity<Project>
    {
        public string Name { get; set; } = default!;
    }
}