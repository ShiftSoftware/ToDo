using ShiftSoftware.ShiftEntity.Model.Dtos;
using System.ComponentModel.DataAnnotations;

namespace ToDo.Shared.DTOs.Project;

public class ProjectDTO : ShiftEntityDTO
{
    public override string? ID { get; set; }
    [Required]
    public string Name { get; set; } = default!;
}
