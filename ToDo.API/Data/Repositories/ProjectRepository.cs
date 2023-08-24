using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShiftSoftware.ShiftEntity.Core;
using ShiftSoftware.ShiftEntity.EFCore;
using ToDo.API.Data.Entities;
using ToDo.Shared.DTOs.Project;

namespace ToDo.API.Data.Repositories
{
    public class ProjectRepository :
        ShiftRepository<DB, Project, ProjectListDTO, ProjectDTO, ProjectDTO>,
        IShiftRepositoryAsync<Project, ProjectListDTO, ProjectDTO>
    {
        public ProjectRepository(DB db, IMapper mapper) : base(db, db.Projects, mapper)
        {
        }
    }
}