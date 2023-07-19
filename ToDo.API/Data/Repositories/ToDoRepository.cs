using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ShiftSoftware.EFCore.SqlServer;
using ShiftSoftware.ShiftEntity.Core;
using ToDo.Shared.DTOs.ToDo;

namespace ToDo.API.Data.Repositories
{
    public class ToDoRepository :
        ShiftRepository<DB, Entities.ToDo>,
        IShiftRepositoryAsync<Entities.ToDo, ToDoListDTO, ToDoDTO>
    {
        public ToDoRepository(DB db, IMapper mapper) : base(db, db.ToDos, mapper)
        {
        }

        public ValueTask<Entities.ToDo> CreateAsync(ToDoDTO dto, long? userId = null)
        {
            var entity = new Entities.ToDo();

            this.AssignValue(entity, dto);

            return new ValueTask<Entities.ToDo>(entity);
        }

        public ValueTask<Entities.ToDo> DeleteAsync(Entities.ToDo entity, long? userId = null)
        {
            entity.DeleteShiftEntity(userId);

            return new ValueTask<Entities.ToDo>(entity);
        }

        public async Task<Entities.ToDo> FindAsync(long id, DateTime? asOf = null, bool ignoreGlobalFilters = false)
        {
            return await base.FindAsync(id, asOf, ignoreGlobalFilters, x => x.Include(y => y.Project));
        }

        public IQueryable<ToDoListDTO> OdataList(bool ignoreGlobalFilters = false)
        {
            return mapper.ProjectTo<ToDoListDTO>(db.ToDos.AsNoTracking());
        }

        public ValueTask<Entities.ToDo> UpdateAsync(Entities.ToDo entity, ToDoDTO dto, long? userId = null)
        {
            this.AssignValue(entity, dto);

            return new ValueTask<Entities.ToDo>(entity);
        }

        public ValueTask<ToDoDTO> ViewAsync(Entities.ToDo entity)
        {
            return new ValueTask<ToDoDTO>(mapper.Map<ToDoDTO>(entity));
        }

        public void AssignValue(Entities.ToDo entity, ToDoDTO dto)
        {
            entity.Title = dto.Title;
            entity.Description = dto.Description;
            entity.Status = dto.Status;

            entity.ProjectID = null;

            if (dto.Project is not null)
            {
                entity.ProjectID = dto.Project.Value.ToLong();
                entity.ReloadAfterSave = true;
            }
        }
    }
}
