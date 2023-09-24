using AutoMapper;
using ShiftSoftware.ShiftEntity.EFCore;
using ToDo.Data.Entities;
using ToDo.Shared.DTOs.Project;

namespace ToDo.Data.Repositories;

public class ProjectRepository :ShiftRepository<DB, Project, ProjectListDTO, ProjectDTO>
{
    public ProjectRepository(DB db, IMapper mapper) : base(db, db.Projects, mapper)
    {
    }
}