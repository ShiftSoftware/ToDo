using AutoMapper;
using ShiftSoftware.ShiftEntity.Core;
using ShiftSoftware.ShiftEntity.EFCore;
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

        public override async Task<Entities.ToDo> FindAsync(long id, DateTime? asOf = null)
        {
            return await base.FindAsync(id, asOf, x => x.Include(y => y.Project));
        }
    }
}
