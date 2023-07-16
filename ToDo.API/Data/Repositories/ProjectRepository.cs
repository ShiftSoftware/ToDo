using ShiftSoftware.EFCore.SqlServer;
using ShiftSoftware.ShiftEntity.Core;
using ToDo.Shared.DTOs.Project;

namespace ToDo.API.Data.Repositories
{
    public class ProjectRepository :
        ShiftRepository<Entities.Project>,
        IShiftRepositoryAsync<Entities.Project, ProjectListDTO, ProjectDTO>
    {
        private DB db;

        public ProjectRepository(DB db) : base(db, db.Projects)
        {
            this.db = db;
        }

        public ValueTask<Entities.Project> CreateAsync(ProjectDTO dto, long? userId = null)
        {
            var entity = new Entities.Project().CreateShiftEntity(userId);

            this.AssignValue(entity, dto);

            return new ValueTask<Entities.Project>(entity);
        }

        public ValueTask<Entities.Project> DeleteAsync(Entities.Project entity, long? userId = null)
        {
            entity.DeleteShiftEntity(userId);

            return new ValueTask<Entities.Project>(entity);
        }

        public async Task<Entities.Project> FindAsync(long id, DateTime? asOf = null, bool ignoreGlobalFilters = false)
        {
            return await base.FindAsync(id, asOf, ignoreGlobalFilters);
        }

        public IQueryable<ProjectListDTO> OdataList(bool ignoreGlobalFilters = false)
        {
            return this.db.Projects.Select(x => (ProjectListDTO)x);
        }

        public ValueTask<Entities.Project> UpdateAsync(Entities.Project entity, ProjectDTO dto, long? userId = null)
        {
            entity.UpdateShiftEntity(userId);

            this.AssignValue(entity, dto);

            return new ValueTask<Entities.Project>(entity);
        }

        public ValueTask<ProjectDTO> ViewAsync(Entities.Project entity)
        {
            return new ValueTask<ProjectDTO>(entity);
        }

        public void AssignValue(Entities.Project entity, ProjectDTO dto)
        {
            entity.Name = dto.Name;
        }
    }
}
