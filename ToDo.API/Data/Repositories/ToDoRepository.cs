using Microsoft.EntityFrameworkCore;
using ShiftSoftware.ShiftEntity.Core;
using ToDo.API.Data.Entities;
using ToDo.Shared.DTOs.ToDo;

namespace ToDo.API.Data.Repositories
{
    public class ToDoRepository :
        ShiftRepository<Entities.ToDo>,
        IShiftRepositoryAsync<Entities.ToDo, ToDoListDTO, ToDoDTO>
    {
        private DB db;

        public ToDoRepository(DB db) : base(db, db.ToDos)
        {
            this.db = db;
        }

        public async Task<Entities.ToDo> CreateAsync(ToDoDTO dto, long? userId = null)
        {
            var entity = new Entities.ToDo().CreateShiftEntity(userId);

            await this.AssignValue(entity, dto);

            return entity;
        }

        public async Task<Entities.ToDo> DeleteAsync(Entities.ToDo entity, long? userId = null)
        {
            entity.DeleteShiftEntity(userId);

            return entity;
        }

        public async Task<Entities.ToDo> FindAsync(long id, DateTime? asOf = null, bool ignoreGlobalFilters = false)
        {
            return await base.FindAsync(id, asOf, ignoreGlobalFilters);
        }

        public IQueryable<ToDoListDTO> OdataList(bool ignoreGlobalFilters = false)
        {
            return this.db.ToDos.Select(x => (ToDoListDTO)x);
        }

        public async Task<Entities.ToDo> UpdateAsync(Entities.ToDo entity, ToDoDTO dto, long? userId = null)
        {
            entity.UpdateShiftEntity(userId);

            await this.AssignValue(entity, dto);

            return entity;
        }

        public async Task<ToDoDTO> ViewAsync(Entities.ToDo entity)
        {
            return entity;
        }

        public async Task AssignValue(Entities.ToDo entity, ToDoDTO dto)
        {
            entity.Title = dto.Title;
            entity.Description = dto.Description;
            entity.Status = dto.Status;
        }
    }
}
