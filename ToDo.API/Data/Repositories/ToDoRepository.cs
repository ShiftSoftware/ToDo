using AutoMapper;
using ShiftSoftware.ShiftEntity.Core;
using ShiftSoftware.ShiftEntity.EFCore;
using System.Linq.Expressions;
using ToDo.Shared.DTOs.ToDo;

namespace ToDo.API.Data.Repositories
{
    public class ToDoRepository :
        ShiftRepository<DB, Entities.ToDo, ToDoListDTO, ToDoDTO, ToDoDTO>,
        IShiftRepositoryAsync<Entities.ToDo, ToDoListDTO, ToDoDTO>
    {
        public ToDoRepository(DB db, IMapper mapper) : base(db, db.ToDos, mapper)
        {
        }

        public override async Task<Entities.ToDo> FindAsync(long id, DateTime? asOf = null, Expression<Func<Entities.ToDo, bool>>? where = null)
        {
            return await base.FindAsync(id, asOf, where, x => x.Include(y => y.Project));
        }

        public override async ValueTask<Entities.ToDo> UpsertAsync(Entities.ToDo entity, ToDoDTO dto, ActionTypes actionType, long? userId = null)
        {
            entity.ReloadAfterSave = true;

            return await base.UpsertAsync(entity, dto, actionType, userId);
        }
    }
}
