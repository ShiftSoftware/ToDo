using ShiftSoftware.ShiftEntity.Model.Dtos;


namespace ToDo.Shared.DTOs.Project;

public class ProjectListDTO: ShiftEntityListDTO
{
    public override string? ID { get; set; }
    public string? Name { get; set; }
}
